//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2013 by Autodesk Inc.

// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.

// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api;

using WF = System.Windows.Forms;

namespace ClashDetective
{
    static class ClashMarkersUtils
    {
        /// <summary>
        /// Stores the preset clash group color schemes.
        /// </summary>
        private static List<Tuple<Color,Color>> ClashGroupColorSchemes;
        private static int ColorSchemeIndex;

        public static event EventHandler CollectionChanged;
        /// <summary>
        /// Prevents the clash markers dock window from updating. The window must be up to date before attempting to render.
        /// </summary>
        public static bool UpdatesSuppressed = false;

        //Settings
        /// <summary>
        /// Whether to draw any kind of box around result groups.
        /// </summary>
        public static bool DrawGroupBoxes = true;
        /// <summary>
        /// Whether to draw 3D boxes around groups. If false, 2D rectangles are drawn instead.
        /// </summary>
        public static bool Draw3DGroupBoxes = true;
        /// <summary>
        /// Opacity with which clash markers are filled.
        /// </summary>
        public static decimal ClashMarkerAlpha = 0.7m;
        /// <summary>
        /// Opacity of 3D result group bounding boxes.
        /// </summary>
        public static decimal GroupBox3DAlpha = 0.3m;
        /// <summary>
        /// Whether markers respond to and intercept any mouse events.
        /// </summary>
        public static bool EnableMouseInteractions = true;
        /// <summary>
        /// Size of the filled area of clash markers.
        /// </summary>
        public static int MarkerRadius = 7;
        /// <summary>
        /// Thickness of the clash marker outline.
        /// </summary>
        public static int MarkerOutlineThickness = 2;

        private static Guid _SelectedMarker;
        /// <summary>
        /// The GUID of the clash result of the currently selected clash marker. To clear the selection, set equal to Guid.Empty.
        /// </summary>
        public static Guid SelectedMarker
        {
            get
            {
                return _SelectedMarker;
            }
        }

        /// <summary>
        /// Whether the selection is locked. When locked, markers cannot be selected or deselected with the LMB.
        /// </summary>
        public static bool SelectionLocked = false;

        public static void TriggerMarkerVisibilityChanged()
        {
            if (MarkerVisibilityChanged != null) MarkerVisibilityChanged();
        }

        public delegate void SelectedMarkerChangedHandler(Guid Marker);
        /// <summary>
        /// Called just after the selected marker changes. Passes the clash GUID for the new marker.
        /// </summary>
        public static event SelectedMarkerChangedHandler SelectedMarkerChanged;

        public delegate void MarkerVisibilityChangedHandler();
        /// <summary>
        /// Called just after the visibility of any marker changes. Passes the GUID of the group that changed.
        /// </summary>
        public static event MarkerVisibilityChangedHandler MarkerVisibilityChanged;

        /// <summary>
        /// Holds information about how a clash result is to be drawn.
        /// </summary>
        public class ResultDrawInformation
        {
            public readonly ProjectionResult Projection;
            public readonly Guid GroupGuid;
            public readonly Guid TestGuid;
            public readonly ClashResult Result;

            public ResultDrawInformation(ProjectionResult Projection, ClashResult Result)
            {
                this.Projection = Projection;
                if (!(Result.Parent is ClashTest))
                {
                    this.GroupGuid = Result.Parent.Guid;
                    this.TestGuid = Result.Parent.Parent.Guid;
                }
                else
                {
                    //For ungrouped results, we use the test GUID as the group GUID
                    this.GroupGuid = Result.Parent.Guid;
                    this.TestGuid = GroupGuid;
                }
                this.Result = Result;
            }
        }

        /// <summary>
        /// Stores the result of projecting each result onto the view along with its group and test GUID
        /// </summary>
        public static List<ResultDrawInformation> ResultDrawList;

        public static List<Tuple<BoundingBox3D, Guid>> GroupBoundingBoxes;

        /// <summary>
        /// Holds information about how the clash markers for a result group are to be drawn.
        /// </summary>
        public class GroupDrawInformation
        {
            public Color FillColor;
            public Color OutlineColor;
            public Guid GroupGuid;

            private bool _DrawGroup = true;
            public bool DrawGroup
            {
                get
                {
                    return _DrawGroup;
                }
                set
                {
                    if (_DrawGroup == value) return;
                    _DrawGroup = value;
                    CheckSelectedMarkerVisibility();
                }
            }
            public bool IsUngroupedResults;

            public GroupDrawInformation(bool GetColorScheme, bool IsUngroupedResults, Guid GroupGuid)
            {
                this.GroupGuid = GroupGuid;
                this.IsUngroupedResults = IsUngroupedResults;
                if (!GetColorScheme) return;
                FillColor = ClashGroupColorSchemes[ColorSchemeIndex].Item1;
                OutlineColor = ClashGroupColorSchemes[ColorSchemeIndex].Item2;
                ColorSchemeIndex++;
                if (ColorSchemeIndex == ClashGroupColorSchemes.Count) ColorSchemeIndex = 0;
            }
        }

        /// <summary>
        /// Stores draw information for each group by GUID, and for a test's ungrouped results by the test GUID
        /// </summary>
        public static Dictionary<Guid, GroupDrawInformation> GroupsInfo;

        /// <summary>
        /// Holds information about how the clash markers for a test are to be drawn.
        /// </summary>
        public class TestDrawInformation
        {
            public Guid TestGuid;

            private bool _DrawTest = true;
            public bool DrawTest
            {
                get
                {
                    return _DrawTest;
                }
                set
                {
                    if (_DrawTest == value) return;
                    _DrawTest = value;
                    CheckSelectedMarkerVisibility();
                }
            }


            public TestDrawInformation(Guid TestGuid)
            {
                this.TestGuid = TestGuid;
            }
        }

        /// <summary>
        /// Records whether the drawing of each test is enabled or not by test GUID
        /// </summary>
        public static Dictionary<Guid, TestDrawInformation> TestsInfo;

        private static Tuple<Color, Color> MakeColorTuple(byte R1, byte G1, byte B1, byte R2, byte G2, byte B2)
        {
            return new Tuple<Color, Color>(Color.FromByteRGB(R1, G1, B1), Color.FromByteRGB(R2, G2, B2));
        }

        /// <summary>
        /// Initialises the static class. Should be called before any other part of clash markers.
        /// </summary>
        public static void Init()
        {
            MarkerVisibilityChanged += new MarkerVisibilityChangedHandler(ClashMarkersUtils_MarkerVisibilityChanged);

            GroupsInfo = new Dictionary<Guid, GroupDrawInformation>();

            //Preset color schemes
            ClashGroupColorSchemes = new List<Tuple<Color,Color>>();
            //1: Red and orange
            ClashGroupColorSchemes.Add(MakeColorTuple(225, 0, 0, 225, 110, 10));
            //2: Blue and cyan
            ClashGroupColorSchemes.Add(MakeColorTuple(0, 0, 225, 0, 225, 225));
            //3: Green and lime green
            ClashGroupColorSchemes.Add(MakeColorTuple(0, 225, 0, 170, 225, 0));
            //4: Purple and pink
            ClashGroupColorSchemes.Add(MakeColorTuple(150, 0, 150, 225, 0, 225));
            //5: Orange and yellow
            ClashGroupColorSchemes.Add(MakeColorTuple(225, 110, 10, 225, 225, 0));

            ColorSchemeIndex = 0;
        }

        static void ClashMarkersUtils_MarkerVisibilityChanged()
        {
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.All);
        }

        public static void CheckSelectedMarkerVisibility()
        {
            if (SelectedMarker != Guid.Empty)
            {
                ClashResult theResult = (ClashResult)Application.MainDocument.GetClash().TestsData.ResolveGuid(SelectedMarker);

                if (GroupsInfo[theResult.Parent.Guid].DrawGroup == false) SetSelectedMarkerAndSyncPanel(Guid.Empty);
                else if (theResult.Parent.Parent is ClashTest) //If the selected result is in a group
                {
                    if (TestsInfo[theResult.Parent.Parent.Guid].DrawTest == false) SetSelectedMarkerAndSyncPanel(Guid.Empty);
                }
                else //If it isn't
                {
                    if (TestsInfo[theResult.Parent.Guid].DrawTest == false) SetSelectedMarkerAndSyncPanel(Guid.Empty);
                }
            }
        }

        public static void SetSelectedMarkerAndSyncPanel(Guid Value)
        {
            if (SelectedMarker == Value) return;
            _SelectedMarker = Value;
            if (SelectedMarkerChanged != null)
            {
                SelectedMarkerChanged(Value);
            }
        }

        public static void SetSelectedMarker(Guid Value)
        {
            if (SelectedMarker == Value) return;
            _SelectedMarker = Value;
            Application.ActiveDocument.ActiveView.RequestDelayedRedraw(ViewRedrawRequests.OverlayRender);
        }

        /// <summary>
        /// Updates groups list from TestsData.
        /// </summary>
        public static void UpdateGroupsList()
        {
            if (UpdatesSuppressed) return; //Suppress updates during transactions, which are batches of consecutive edits.
            Dictionary<Guid, GroupDrawInformation> NewColors = new Dictionary<Guid, GroupDrawInformation>();
            Dictionary<Guid, ClashMarkersUtils.TestDrawInformation> NewTests = new Dictionary<Guid, ClashMarkersUtils.TestDrawInformation>();

            foreach (ClashTest theTest in Application.ActiveDocument.GetClash().TestsData.Tests)
            {
                ClashMarkersUtils.TestDrawInformation theTestInfo;
                if (TestsInfo.TryGetValue(theTest.Guid, out theTestInfo)) NewTests.Add(theTest.Guid, theTestInfo);
                else
                {
                    NewTests.Add(theTest.Guid, new TestDrawInformation(theTest.Guid));
                }

                //Use the test GUID for ungrouped results
                GroupDrawInformation theInfo;
                if (GroupsInfo.TryGetValue(theTest.Guid, out theInfo)) NewColors.Add(theTest.Guid, theInfo);
                else
                {
                    GroupDrawInformation UngroupedDrawInformation = new GroupDrawInformation(false, true, theTest.Guid);
                    UngroupedDrawInformation.FillColor = Color.FromByteRGB(150, 150, 150);
                    UngroupedDrawInformation.OutlineColor = Color.FromByteRGB(225, 225, 225);
                    NewColors.Add(theTest.Guid, UngroupedDrawInformation);
                }

                foreach (SavedItem theResult in theTest.Children)
                {
                    if (!theResult.IsGroup) continue;

                    if (GroupsInfo.TryGetValue(theResult.Guid, out theInfo)) NewColors.Add(theResult.Guid, theInfo);
                    else
                    {
                        NewColors.Add(theResult.Guid, new GroupDrawInformation(true, false, theResult.Guid));
                    }
                }
            }
            GroupsInfo = NewColors;
            TestsInfo = NewTests;

            //Tells pane to sync to ClashMarkerUtils
            if (CollectionChanged != null)
            {
                CollectionChanged(null, null);
            }
        }

        public static void DrawAllMarkers(Graphics theGraphics, View theView)
        {
            //There should not be draw events during transactions, but in case this does occur, there would be an error as the groups list is not up to date
            if (UpdatesSuppressed) return;
            ResultDrawList = new List<ResultDrawInformation>();
            foreach (ClashTest theTest in Application.ActiveDocument.GetClash().TestsData.Tests)
            {
                if (!TestsInfo[theTest.Guid].DrawTest) continue;
                DrawTestMarkers(theTest, theGraphics, theView);
            }
            foreach(ResultDrawInformation theInfo in ResultDrawList.OrderByDescending(x => x.Projection.Depth))
            {
                DrawResult(theInfo, theGraphics, theView);
            }
        }

        /// <summary>
        /// Recurses through the children of result, drawing a marker for each ClashResult.
        /// </summary>
        /// <param name="Result"></param>
        /// <param name="theGraphics"></param>
        /// <param name="theView"></param>
        private static void DrawTestMarkers(ClashTest Test, Graphics theGraphics, View theView)
        {
            foreach (SavedItem Child in Test.Children)
            {
                DrawResultGroupMarkers(Child, theGraphics, theView);
            }
        }

        private static void DrawResultGroupMarkers(SavedItem Result, Graphics theGraphics, View theView)
        {
            if (!Result.IsGroup)
            {
                AddResultToDrawList((ClashResult) Result, theView);
            }
            else
            {
                if (!GroupsInfo[Result.Guid].DrawGroup || ((GroupItem) Result).Children.Count == 0) return; //If this group is disabled or empty
                //If we don't have a stored colorscheme for the group, assign it one of the presets
                System.Diagnostics.Debug.Assert(GroupsInfo.ContainsKey(Result.Guid), "Unknown group encountered in render code. There may be an error or unexpected rendering behavior.");

                foreach (SavedItem theChild in ((GroupItem)Result).Children)
                {
                    AddResultToDrawList((ClashResult)theChild, theView);
                }
                if (!DrawGroupBoxes) return;
                if (Draw3DGroupBoxes) return; //This must be done in the main render
                
                List<Point2D> Centers = new List<Point2D>();
                foreach (SavedItem theChild in ((GroupItem)Result).Children)
                {
                    //For the purposes of drawing the rectangle, project ignoring all clipping.
                    ProjectionResult theProjectionResult = theView.ProjectPoint(((ClashResult)theChild).Center, false, false);
                    if (theProjectionResult == null) continue;
                    Point2D OnScreenPosition = new Point2D(theProjectionResult.X, theProjectionResult.Y);
                    Centers.Add(OnScreenPosition);
                }
                //Draw a rectangle around the group
                Point2D BottomLeft = new Point2D(Centers.Min(p => p.X), Centers.Min(p => p.Y));
                Point2D TopRight = new Point2D(Centers.Max(p => p.X), Centers.Max(p => p.Y));

                theGraphics.Color(Color.FromByteRGB(0, 0, 0), 1);
                DrawCorrectedRectangle(BottomLeft, TopRight, 3, theGraphics);

                theGraphics.Color(GroupsInfo[Result.Guid].OutlineColor, 1);
                DrawCorrectedRectangle(BottomLeft, TopRight, 1, theGraphics);
            }
        }

        private static BoundingBox3D CombinedGroupBoundingBox = new BoundingBox3D();

        public static void MainRenderDrawing(Graphics theGraphics)
        {
            if (!DrawGroupBoxes) return;
            if (!Draw3DGroupBoxes) return;

            foreach (Tuple<BoundingBox3D, Guid> theTuple in GroupBoundingBoxes)
            {
                BoundingBox3D BoundingBox = theTuple.Item1;

                Vector3D xVector = new Vector3D(BoundingBox.Max.X - BoundingBox.Min.X, 0, 0);
                Vector3D yVector = new Vector3D(0, BoundingBox.Max.Y - BoundingBox.Min.Y, 0);
                Vector3D zVector = new Vector3D(0, 0, BoundingBox.Max.Z - BoundingBox.Min.Z);

                theGraphics.Color(GroupsInfo[theTuple.Item2].OutlineColor, (double)GroupBox3DAlpha);
                theGraphics.Cuboid(BoundingBox.Min, xVector, yVector, zVector, true);

                theGraphics.LineWidth(3);
                theGraphics.Color(GroupsInfo[theTuple.Item2].OutlineColor, 1);
                theGraphics.Cuboid(BoundingBox.Min, xVector, yVector, zVector, false);
            }
        }

        /// <summary>
        /// Gets the combined bounding box of all 3D graphics to be drawn. Used to prevent clipping of 3D graphics.
        /// </summary>
        /// <returns></returns>
        public static BoundingBox3D GetCombinedBoundingBox()
        {
            GroupBoundingBoxes = new List<Tuple<BoundingBox3D, Guid>>();
            CombinedGroupBoundingBox = new BoundingBox3D();

            foreach (ClashTest theTest in Application.ActiveDocument.GetClash().TestsData.Tests)
            {
                if (!TestsInfo[theTest.Guid].DrawTest) continue;
                foreach (SavedItem Child in theTest.Children)
                {
                    if (!Child.IsGroup) continue;
                    if (!GroupsInfo[Child.Guid].DrawGroup || ((GroupItem)Child).Children.Count == 0) continue; //If this group is disabled or empty

                    BoundingBox3D BoundingBox = new BoundingBox3D();
                    foreach (SavedItem theResult in ((GroupItem)Child).Children)
                    {
                        BoundingBox = BoundingBox.Extend(((ClashResult)theResult).Center);
                    }
                    GroupBoundingBoxes.Add(new Tuple<BoundingBox3D, Guid>(BoundingBox, Child.Guid));
                    CombinedGroupBoundingBox = CombinedGroupBoundingBox.Extend(BoundingBox);
                }
            }
            return CombinedGroupBoundingBox;
        }

        /// <summary>
        /// Adds the projection of a result to the draw list along with the GUID of the group it belongs to.
        /// </summary>
        /// <param name="Result"></param>
        /// <param name="theView"></param>
        /// <param name="GroupGuid"></param>
        private static void AddResultToDrawList(ClashResult Result, View theView)
        {
            ProjectionResult theProjectionResult = theView.ProjectPoint(((ClashResult)Result).Center, true, true);
            if (theProjectionResult == null) return; //If the result is not visible due to sectioning or frustum clip, the projection result will be null
            ResultDrawList.Add(new ResultDrawInformation(theProjectionResult, Result));
        }

        /// <summary>
        /// Draws the marker for a result in the draw list, in the colors assigned to the stored group GUID. An empty GUID indicates that the marker is ungrouped.
        /// </summary>
        /// <param name="Result"></param>
        /// <param name="theGraphics"></param>
        /// <param name="theView"></param>
        /// <param name="ColorScheme"></param>
        private static void DrawResult(ResultDrawInformation DrawListEntry, Graphics theGraphics, View theView)
        {
            if (!GroupsInfo[DrawListEntry.GroupGuid].DrawGroup) return;
            if (!TestsInfo[DrawListEntry.TestGuid].DrawTest) return;
            Point2D OnScreenLocation = new Point2D(DrawListEntry.Projection.X, DrawListEntry.Projection.Y);

            theGraphics.Color(GroupsInfo[DrawListEntry.GroupGuid].FillColor, (double) ClashMarkerAlpha);
            theGraphics.Circle(OnScreenLocation, MarkerRadius, true);

            theGraphics.LineWidth(MarkerOutlineThickness);
            theGraphics.Color(GroupsInfo[DrawListEntry.GroupGuid].OutlineColor, 1);
            theGraphics.Circle(OnScreenLocation, MarkerRadius, false);

            if (DrawListEntry.Result.Guid != SelectedMarker) return;

            Color SelectedMarkerHighlightColor;
            if (SelectionLocked) SelectedMarkerHighlightColor = Color.FromByteRGB(255, 0, 0);
            else SelectedMarkerHighlightColor = Color.FromByteRGB(0, 255, 0);

            //int SelectionCircleRadius = MarkerRadius + MarkerOutlineThickness + 1;
            int SelectionCircleRadius = MarkerRadius;

            //Draw faint spokes across the entire screen
            theGraphics.Color(SelectedMarkerHighlightColor, 0.3);

            //Top spoke
            Point2D InnerPoint = new Point2D(OnScreenLocation.X, 0);
            Point2D OuterPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y - SelectionCircleRadius);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Bottom spoke
            InnerPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y + SelectionCircleRadius);
            OuterPoint = new Point2D(OnScreenLocation.X, theView.Height);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Left spoke
            InnerPoint = new Point2D(0, OnScreenLocation.Y);
            OuterPoint = new Point2D(OnScreenLocation.X - MarkerRadius, OnScreenLocation.Y);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Right spoke
            InnerPoint = new Point2D(OnScreenLocation.X + MarkerRadius, OnScreenLocation.Y);
            OuterPoint = new Point2D(theView.Width, OnScreenLocation.Y);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Draw opaque spokes around marker and additional circle
            theGraphics.Color(SelectedMarkerHighlightColor, 1);
            //Circle
            //theGraphics.Circle(OnScreenLocation, SelectionCircleRadius, false);
            //Top spoke
            InnerPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y + SelectionCircleRadius);
            OuterPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y + 3 * SelectionCircleRadius);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Bottom spoke
            InnerPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y - SelectionCircleRadius);
            OuterPoint = new Point2D(OnScreenLocation.X, OnScreenLocation.Y - 3 * SelectionCircleRadius);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Left spoke
            InnerPoint = new Point2D(OnScreenLocation.X - SelectionCircleRadius, OnScreenLocation.Y);
            OuterPoint = new Point2D(OnScreenLocation.X - 3 * SelectionCircleRadius, OnScreenLocation.Y);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Right spoke
            InnerPoint = new Point2D(OnScreenLocation.X + SelectionCircleRadius, OnScreenLocation.Y);
            OuterPoint = new Point2D(OnScreenLocation.X + 3 * SelectionCircleRadius, OnScreenLocation.Y);
            theGraphics.Line(InnerPoint, OuterPoint);

            //Draw opaque spokes at edge of screen
            //Top spoke
            InnerPoint = new Point2D(OnScreenLocation.X, theView.Height);
            OuterPoint = new Point2D(OnScreenLocation.X, theView.Height - 3 * SelectionCircleRadius);
            if(OuterPoint.Y > OnScreenLocation.Y + MarkerRadius) theGraphics.Line(InnerPoint, OuterPoint);

            //Bottom spoke
            InnerPoint = new Point2D(OnScreenLocation.X, 0);
            OuterPoint = new Point2D(OnScreenLocation.X, 3 * SelectionCircleRadius);
            if (OuterPoint.Y < OnScreenLocation.Y - MarkerRadius) theGraphics.Line(InnerPoint, OuterPoint);

            //Left spoke
            InnerPoint = new Point2D(0, OnScreenLocation.Y);
            OuterPoint = new Point2D(3 * SelectionCircleRadius, OnScreenLocation.Y);
            if (OuterPoint.X < OnScreenLocation.X - MarkerRadius) theGraphics.Line(InnerPoint, OuterPoint);

            //Right spoke
            InnerPoint = new Point2D(theView.Width + SelectionCircleRadius, OnScreenLocation.Y);
            OuterPoint = new Point2D(theView.Width - 3 * SelectionCircleRadius, OnScreenLocation.Y);
            if (OuterPoint.X > OnScreenLocation.X + MarkerRadius) theGraphics.Line(InnerPoint, OuterPoint);
        }

        /// <summary>
        /// The Graphics.Rectangle function does not account propery for line width and transparency. This function draws an outline rectangle accounting for these.
        /// </summary>
        private static void DrawCorrectedRectangle(Point2D BottomLeft, Point2D TopRight, int LineWidth, Graphics theGraphics)
        {
            theGraphics.LineWidth(LineWidth);
            int CorrectionAmount = (LineWidth - 1) / 2;
            theGraphics.LineStipple(0, 0xffff);


            //Draw left hand line
            Point2D Point1 = new Point2D(BottomLeft.X, BottomLeft.Y - CorrectionAmount);
            Point2D Point2 = new Point2D(BottomLeft.X, TopRight.Y + CorrectionAmount);
            theGraphics.Line(Point1, Point2);

            //Draw right hand line
            Point1 = new Point2D(TopRight.X, BottomLeft.Y - CorrectionAmount);
            Point2 = new Point2D(TopRight.X, TopRight.Y + CorrectionAmount);
            theGraphics.Line(Point1, Point2);

            //Draw bottom line
            Point1 = new Point2D(BottomLeft.X + CorrectionAmount, BottomLeft.Y);
            Point2 = new Point2D(TopRight.X - CorrectionAmount, BottomLeft.Y);
            theGraphics.Line(Point1, Point2);

            //Draw top line
            Point1 = new Point2D(BottomLeft.X + CorrectionAmount, TopRight.Y);
            Point2 = new Point2D(TopRight.X - CorrectionAmount, TopRight.Y);
            theGraphics.Line(Point1, Point2);
        }
    }
}
