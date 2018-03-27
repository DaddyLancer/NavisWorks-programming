namespace Viewer
{
   partial class SelectionSetsForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionSetsForm));
         this.selectionSetsTree = new System.Windows.Forms.TreeView();
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newSelectionSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // selectionSetsTree
         // 
         this.selectionSetsTree.AllowDrop = true;
         this.selectionSetsTree.ContextMenuStrip = this.contextMenuStrip;
         this.selectionSetsTree.Dock = System.Windows.Forms.DockStyle.Fill;
         this.selectionSetsTree.HideSelection = false;
         this.selectionSetsTree.HotTracking = true;
         this.selectionSetsTree.ImageIndex = 0;
         this.selectionSetsTree.ImageList = this.imageList;
         this.selectionSetsTree.LabelEdit = true;
         this.selectionSetsTree.Location = new System.Drawing.Point(0, 0);
         this.selectionSetsTree.Name = "selectionSetsTree";
         this.selectionSetsTree.SelectedImageIndex = 0;
         this.selectionSetsTree.Size = new System.Drawing.Size(252, 364);
         this.selectionSetsTree.TabIndex = 1;
         this.selectionSetsTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.selectionSetsTree_AfterLabelEdit);
         this.selectionSetsTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.selectionSetsTree_BeforeExpand);
         this.selectionSetsTree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.selectionSetsTree_BeforeCollapse);
         this.selectionSetsTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectionSetsTree_DragDrop);
         this.selectionSetsTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectionSetsTree_DragEnter);
         this.selectionSetsTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.selectionSetsTree_BeforeSelect);
         this.selectionSetsTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.selectionSetsTree_ItemDrag);
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.newSelectionSetToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeToolStripMenuItem});
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size(161, 98);
         // 
         // newFolderToolStripMenuItem
         // 
         this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
         this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.newFolderToolStripMenuItem.Text = "New Folder";
         this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
         // 
         // newSelectionSetToolStripMenuItem
         // 
         this.newSelectionSetToolStripMenuItem.Name = "newSelectionSetToolStripMenuItem";
         this.newSelectionSetToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.newSelectionSetToolStripMenuItem.Text = "New Selection Set";
         this.newSelectionSetToolStripMenuItem.Click += new System.EventHandler(this.newSelectionSetToolStripMenuItem_Click);
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "FolderItemImg.bmp");
         this.imageList.Images.SetKeyName(1, "SelectionSetImg.bmp");
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
         // 
         // removeToolStripMenuItem
         // 
         this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
         this.removeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
         this.removeToolStripMenuItem.Text = "Remove";
         this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
         // 
         // SelectionSetsForm
         // 
         this.ClientSize = new System.Drawing.Size(252, 364);
         this.Controls.Add(this.selectionSetsTree);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(260, 390);
         this.Name = "SelectionSetsForm";
         this.Text = "Selection Sets";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionSets_FormClosing);
         this.contextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TreeView selectionSetsTree;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newSelectionSetToolStripMenuItem;
      private System.Windows.Forms.ImageList imageList;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
   }
}