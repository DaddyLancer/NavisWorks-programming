namespace MDIViewer
{
   partial class MDIViewer
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
         this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.publishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cullingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.selectionMenu = new System.Windows.Forms.ToolStripMenuItem();
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
         this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
         this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
         this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.close = new System.Windows.Forms.ToolStripMenuItem();
         this.statusStrip = new System.Windows.Forms.StatusStrip();
         this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
         this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
         this.statusSubText = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
         this.documentTool = new System.Windows.Forms.ToolStripComboBox();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.selectionBehavior = new System.Windows.Forms.ToolStripComboBox();
         this.toolStrip = new System.Windows.Forms.ToolStrip();
         this.menuStrip1.SuspendLayout();
         this.tabContextMenu.SuspendLayout();
         this.statusStrip.SuspendLayout();
         this.toolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.selectionMenu,
            this.viewMenu,
            this.windowsMenu});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.menuStrip1.Size = new System.Drawing.Size(758, 24);
         this.menuStrip1.TabIndex = 2;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileMenu
         // 
         this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.appendToolStripMenuItem,
            this.toolStripSeparator6,
            this.saveAsToolStripMenuItem,
            this.publishToolStripMenuItem,
            this.toolStripSeparator4,
            this.propertiesToolStripMenuItem,
            this.cullingOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
         this.fileMenu.Name = "fileMenu";
         this.fileMenu.Size = new System.Drawing.Size(35, 20);
         this.fileMenu.Text = "&File";
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
         // toolStripSeparator6
         // 
         this.toolStripSeparator6.Name = "toolStripSeparator6";
         this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
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
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
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
         // selectionMenu
         // 
         this.selectionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.focusOnCurrentSelectionToolStripMenuItem,
            this.selectToolStripMenuItem});
         this.selectionMenu.Name = "selectionMenu";
         this.selectionMenu.Size = new System.Drawing.Size(62, 20);
         this.selectionMenu.Text = "Selection";
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
         // windowsMenu
         // 
         this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem,
            this.toolStripSeparator7,
            this.closeAllToolStripMenuItem});
         this.windowsMenu.Name = "windowsMenu";
         this.windowsMenu.Size = new System.Drawing.Size(62, 20);
         this.windowsMenu.Text = "&Windows";
         // 
         // newWindowToolStripMenuItem
         // 
         this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
         this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.newWindowToolStripMenuItem.Text = "New Window";
         this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
         // 
         // cascadeToolStripMenuItem
         // 
         this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
         this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.cascadeToolStripMenuItem.Text = "&Cascade";
         this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
         // 
         // tileVerticalToolStripMenuItem
         // 
         this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
         this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
         this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
         // 
         // tileHorizontalToolStripMenuItem
         // 
         this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
         this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
         this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
         // 
         // arrangeIconsToolStripMenuItem
         // 
         this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
         this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
         this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
         // 
         // toolStripSeparator7
         // 
         this.toolStripSeparator7.Name = "toolStripSeparator7";
         this.toolStripSeparator7.Size = new System.Drawing.Size(139, 6);
         // 
         // closeAllToolStripMenuItem
         // 
         this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
         this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
         this.closeAllToolStripMenuItem.Text = "C&lose All";
         this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
         // 
         // tabContextMenu
         // 
         this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.close});
         this.tabContextMenu.Name = "tabContextMenu";
         this.tabContextMenu.ShowImageMargin = false;
         this.tabContextMenu.Size = new System.Drawing.Size(126, 32);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
         // 
         // close
         // 
         this.close.Name = "close";
         this.close.Size = new System.Drawing.Size(125, 22);
         this.close.Text = "Close document";
         // 
         // statusStrip
         // 
         this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusText,
            this.statusSubText});
         this.statusStrip.Location = new System.Drawing.Point(0, 551);
         this.statusStrip.Name = "statusStrip";
         this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.statusStrip.Size = new System.Drawing.Size(758, 22);
         this.statusStrip.TabIndex = 2;
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
         // toolStrip
         // 
         this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.documentTool,
            this.toolStripLabel1,
            this.selectionBehavior});
         this.toolStrip.Location = new System.Drawing.Point(0, 24);
         this.toolStrip.Name = "toolStrip";
         this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.toolStrip.Size = new System.Drawing.Size(758, 25);
         this.toolStrip.TabIndex = 3;
         this.toolStrip.Text = "toolStrip1";
         // 
         // MDIViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(758, 573);
         this.Controls.Add(this.toolStrip);
         this.Controls.Add(this.menuStrip1);
         this.Controls.Add(this.statusStrip);
         this.IsMdiContainer = true;
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MDIViewer";
         this.Text = "MDIViewer";
         this.Load += new System.EventHandler(this.MDIViewer_Load);
         this.MdiChildActivate += new System.EventHandler(this.MDIViewer_MdiChildActivate);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIViewer_FormClosing);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.tabContextMenu.ResumeLayout(false);
         this.statusStrip.ResumeLayout(false);
         this.statusStrip.PerformLayout();
         this.toolStrip.ResumeLayout(false);
         this.toolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileMenu;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ContextMenuStrip tabContextMenu;
      private System.Windows.Forms.ToolStripMenuItem close;
      private System.Windows.Forms.StatusStrip statusStrip;
      private System.Windows.Forms.ToolStripStatusLabel statusText;
      private System.Windows.Forms.ToolStripProgressBar progressBar;
      private System.Windows.Forms.ToolStripStatusLabel statusSubText;
      private System.Windows.Forms.ToolStripComboBox documentTool;
      private System.Windows.Forms.ToolStripComboBox selectionBehavior;
      private System.Windows.Forms.ToolStripLabel toolStripLabel2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectionMenu;
      private System.Windows.Forms.ToolStripMenuItem focusOnCurrentSelectionToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem fromSearchToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem windowsMenu;
      private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem viewMenu;
      private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem publishToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem cullingOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStrip toolStrip;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem applicationInformationToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem selectionSetsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
   }
}

