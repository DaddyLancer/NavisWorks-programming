namespace SDIViewer
{
   partial class SDIViewer
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
         this.statusStrip = new System.Windows.Forms.StatusStrip();
         this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
         this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
         this.statusSubText = new System.Windows.Forms.ToolStripStatusLabel();
         this.splitContainer = new System.Windows.Forms.SplitContainer();
         this.viewControl1 = new Autodesk.Navisworks.Api.Controls.ViewControl();
         this.documentControl = new Autodesk.Navisworks.Api.Controls.DocumentControl(this.components);
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.publishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cullingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
         this.focusOnCurrentSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.fromSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
         this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.applicationInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectionSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStrip = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.documentTool = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.selectionBehavior = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
         this.toolStripContainer1.ContentPanel.SuspendLayout();
         this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
         this.toolStripContainer1.SuspendLayout();
         this.statusStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
         this.splitContainer.Panel1.SuspendLayout();
         this.splitContainer.SuspendLayout();
         this.menuStrip1.SuspendLayout();
         this.toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStripContainer1
         // 
         // 
         // toolStripContainer1.BottomToolStripPanel
         // 
         this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
         // 
         // toolStripContainer1.ContentPanel
         // 
         this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer);
         this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(654, 349);
         this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
         this.toolStripContainer1.Name = "toolStripContainer1";
         this.toolStripContainer1.Size = new System.Drawing.Size(654, 420);
         this.toolStripContainer1.TabIndex = 0;
         this.toolStripContainer1.Text = "toolStripContainer1";
         // 
         // toolStripContainer1.TopToolStripPanel
         // 
         this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
         this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
         // 
         // statusStrip
         // 
         this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusText,
            this.statusSubText});
         this.statusStrip.Location = new System.Drawing.Point(0, 0);
         this.statusStrip.Name = "statusStrip";
         this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.statusStrip.Size = new System.Drawing.Size(654, 22);
         this.statusStrip.TabIndex = 5;
         this.statusStrip.Text = "statusStrip";
         // 
         // progressBar
         // 
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(100, 16);
         this.progressBar.Visible = false;
         // 
         // statusText
         // 
         this.statusText.Name = "statusText";
         this.statusText.Size = new System.Drawing.Size(0, 17);
         // 
         // statusSubText
         // 
         this.statusSubText.Name = "statusSubText";
         this.statusSubText.Size = new System.Drawing.Size(0, 17);
         // 
         // splitContainer
         // 
         this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer.Location = new System.Drawing.Point(0, 0);
         this.splitContainer.Name = "splitContainer";
         // 
         // splitContainer.Panel1
         // 
         this.splitContainer.Panel1.Controls.Add(this.viewControl1);
         this.splitContainer.Panel2Collapsed = true;
         this.splitContainer.Size = new System.Drawing.Size(654, 349);
         this.splitContainer.SplitterDistance = 218;
         this.splitContainer.TabIndex = 2;
         // 
         // viewControl1
         // 
         this.viewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.viewControl1.DocumentControl = this.documentControl;
         this.viewControl1.Location = new System.Drawing.Point(0, 0);
         this.viewControl1.Name = "viewControl1";
         this.viewControl1.Size = new System.Drawing.Size(654, 349);
         this.viewControl1.TabIndex = 1;
         this.viewControl1.Text = "viewControl1";
         // 
         // menuStrip1
         // 
         this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.viewMenu,
            this.windowToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(654, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.appendToolStripMenuItem,
            this.toolStripSeparator4,
            this.saveAsToolStripMenuItem,
            this.publishToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem,
            this.cullingOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.openToolStripMenuItem.Text = "&Open";
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // mergeToolStripMenuItem
         // 
         this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
         this.mergeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.mergeToolStripMenuItem.Text = "Merge";
         this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
         // 
         // appendToolStripMenuItem
         // 
         this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
         this.appendToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.appendToolStripMenuItem.Text = "Append";
         this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
         // 
         // saveAsToolStripMenuItem
         // 
         this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
         this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.saveAsToolStripMenuItem.Text = "Save As...";
         this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
         // 
         // publishToolStripMenuItem
         // 
         this.publishToolStripMenuItem.Name = "publishToolStripMenuItem";
         this.publishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.publishToolStripMenuItem.Text = "Publish...";
         this.publishToolStripMenuItem.Click += new System.EventHandler(this.publishToolStripMenuItem_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
         // 
         // propertiesToolStripMenuItem
         // 
         this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
         this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.propertiesToolStripMenuItem.Text = "Properties";
         this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
         // 
         // cullingOptionsToolStripMenuItem
         // 
         this.cullingOptionsToolStripMenuItem.Name = "cullingOptionsToolStripMenuItem";
         this.cullingOptionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.cullingOptionsToolStripMenuItem.Text = "Culling Options";
         this.cullingOptionsToolStripMenuItem.Click += new System.EventHandler(this.cullingOptionsToolStripMenuItem_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.focusOnCurrentSelectionToolStripMenuItem,
            this.selectToolStripMenuItem});
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(62, 20);
         this.toolStripMenuItem2.Text = "Selection";
         // 
         // focusOnCurrentSelectionToolStripMenuItem
         // 
         this.focusOnCurrentSelectionToolStripMenuItem.Name = "focusOnCurrentSelectionToolStripMenuItem";
         this.focusOnCurrentSelectionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
         this.focusOnCurrentSelectionToolStripMenuItem.Text = "Focus on Current Selection";
         this.focusOnCurrentSelectionToolStripMenuItem.Click += new System.EventHandler(this.focusOnCurrentSelectionToolStripMenuItem_Click);
         // 
         // selectToolStripMenuItem
         // 
         this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.toolStripSeparator3,
            this.fromSearchToolStripMenuItem});
         this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
         this.selectToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
         this.selectToolStripMenuItem.Text = "Select";
         // 
         // allToolStripMenuItem
         // 
         this.allToolStripMenuItem.Name = "allToolStripMenuItem";
         this.allToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
         this.allToolStripMenuItem.Text = "All";
         this.allToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(131, 6);
         // 
         // fromSearchToolStripMenuItem
         // 
         this.fromSearchToolStripMenuItem.Name = "fromSearchToolStripMenuItem";
         this.fromSearchToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
         this.fromSearchToolStripMenuItem.Text = "From Search";
         this.fromSearchToolStripMenuItem.Click += new System.EventHandler(this.fromSearchToolStripMenuItem_Click);
         // 
         // viewMenu
         // 
         this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem,
            this.toolStripSeparator5,
            this.applicationInformationToolStripMenuItem,
            this.selectionSetsToolStripMenuItem});
         this.viewMenu.Name = "viewMenu";
         this.viewMenu.Size = new System.Drawing.Size(41, 20);
         this.viewMenu.Text = "&View";
         // 
         // toolBarToolStripMenuItem
         // 
         this.toolBarToolStripMenuItem.Checked = true;
         this.toolBarToolStripMenuItem.CheckOnClick = true;
         this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
         this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.toolBarToolStripMenuItem.Text = "&Toolbar";
         this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
         // 
         // statusBarToolStripMenuItem
         // 
         this.statusBarToolStripMenuItem.Checked = true;
         this.statusBarToolStripMenuItem.CheckOnClick = true;
         this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
         this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.statusBarToolStripMenuItem.Text = "&Status Bar";
         this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
         // 
         // applicationInformationToolStripMenuItem
         // 
         this.applicationInformationToolStripMenuItem.Name = "applicationInformationToolStripMenuItem";
         this.applicationInformationToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.applicationInformationToolStripMenuItem.Text = "Application Information";
         this.applicationInformationToolStripMenuItem.Click += new System.EventHandler(this.applicationInformationToolStripMenuItem_Click);
         // 
         // selectionSetsToolStripMenuItem
         // 
         this.selectionSetsToolStripMenuItem.Name = "selectionSetsToolStripMenuItem";
         this.selectionSetsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.selectionSetsToolStripMenuItem.Text = "Selection Sets";
         this.selectionSetsToolStripMenuItem.Click += new System.EventHandler(this.selectionSetsToolStripMenuItem_Click);
         // 
         // windowToolStripMenuItem
         // 
         this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitToolStripMenuItem});
         this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
         this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
         this.windowToolStripMenuItem.Text = "Window";
         // 
         // splitToolStripMenuItem
         // 
         this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
         this.splitToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
         this.splitToolStripMenuItem.Text = "Split";
         this.splitToolStripMenuItem.Click += new System.EventHandler(this.splitToolStripMenuItem_Click);
         // 
         // toolStrip
         // 
         this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.documentTool,
            this.toolStripLabel1,
            this.selectionBehavior});
         this.toolStrip.Location = new System.Drawing.Point(3, 24);
         this.toolStrip.Name = "toolStrip";
         this.toolStrip.Size = new System.Drawing.Size(431, 25);
         this.toolStrip.TabIndex = 4;
         this.toolStrip.Text = "toolStrip1";
         // 
         // toolStripLabel2
         // 
         this.toolStripLabel2.Name = "toolStripLabel2";
         this.toolStripLabel2.Size = new System.Drawing.Size(78, 22);
         this.toolStripLabel2.Text = "Document Tool";
         // 
         // documentTool
         // 
         this.documentTool.DropDownHeight = 200;
         this.documentTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.documentTool.Enabled = false;
         this.documentTool.IntegralHeight = false;
         this.documentTool.Name = "documentTool";
         this.documentTool.Size = new System.Drawing.Size(121, 25);
         this.documentTool.ToolTipText = "Document Tool";
         this.documentTool.SelectedIndexChanged += new System.EventHandler(this.documentTool_SelectedIndexChanged);
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
         this.toolStripLabel1.Text = "Selection Behavior";
         // 
         // selectionBehavior
         // 
         this.selectionBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.selectionBehavior.Name = "selectionBehavior";
         this.selectionBehavior.Size = new System.Drawing.Size(121, 25);
         this.selectionBehavior.ToolTipText = "Selection Behavior";
         this.selectionBehavior.SelectedIndexChanged += new System.EventHandler(this.selectionBehavior_SelectedIndexChanged);
         // 
         // SDIViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(654, 420);
         this.Controls.Add(this.toolStripContainer1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "SDIViewer";
         this.Text = "SDIViewer";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SDIViewer_FormClosing);
         this.Load += new System.EventHandler(this.SDIViewer_Load);
         this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
         this.toolStripContainer1.ContentPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.TopToolStripPanel.PerformLayout();
         this.toolStripContainer1.ResumeLayout(false);
         this.toolStripContainer1.PerformLayout();
         this.statusStrip.ResumeLayout(false);
         this.statusStrip.PerformLayout();
         this.splitContainer.Panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
         this.splitContainer.ResumeLayout(false);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.toolStrip.ResumeLayout(false);
         this.toolStrip.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ToolStripContainer toolStripContainer1;
      private Autodesk.Navisworks.Api.Controls.ViewControl viewControl1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private Autodesk.Navisworks.Api.Controls.DocumentControl documentControl;
      private System.Windows.Forms.ToolStrip toolStrip;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripComboBox documentTool;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripComboBox selectionBehavior;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem focusOnCurrentSelectionToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.StatusStrip statusStrip;
      private System.Windows.Forms.ToolStripProgressBar progressBar;
      private System.Windows.Forms.ToolStripStatusLabel statusText;
      private System.Windows.Forms.ToolStripStatusLabel statusSubText;
      private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem viewMenu;
      private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem publishToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem cullingOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem fromSearchToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
      private System.Windows.Forms.SplitContainer splitContainer;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem applicationInformationToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectionSetsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
   }
}

