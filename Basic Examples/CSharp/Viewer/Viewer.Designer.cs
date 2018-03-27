namespace Viewer
{
    partial class Viewer
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
           this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
           this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.viewControl = new Autodesk.Navisworks.Api.Controls.ViewControl();
           this.documentControl = new Autodesk.Navisworks.Api.Controls.DocumentControl(this.components);
           this.menuStrip1.SuspendLayout();
           this.SuspendLayout();
           // 
           // menuStrip1
           // 
           this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Size = new System.Drawing.Size(745, 24);
           this.menuStrip1.TabIndex = 0;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // toolStripMenuItem1
           // 
           this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
           this.toolStripMenuItem1.Name = "toolStripMenuItem1";
           this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
           this.toolStripMenuItem1.Text = "&File";
           // 
           // openToolStripMenuItem
           // 
           this.openToolStripMenuItem.Name = "openToolStripMenuItem";
           this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
           this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
           this.openToolStripMenuItem.Text = "&Open";
           this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
           this.exitToolStripMenuItem.Text = "&Exit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // viewControl
           // 
           this.viewControl.Dock = System.Windows.Forms.DockStyle.Fill;
           this.viewControl.DocumentControl = this.documentControl;
           this.viewControl.Location = new System.Drawing.Point(0, 24);
           this.viewControl.Name = "viewControl";
           this.viewControl.Size = new System.Drawing.Size(745, 496);
           this.viewControl.TabIndex = 1;
           this.viewControl.Text = "viewControl";
           // 
           // Viewer
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(745, 520);
           this.Controls.Add(this.viewControl);
           this.Controls.Add(this.menuStrip1);
           this.MainMenuStrip = this.menuStrip1;
           this.Name = "Viewer";
           this.Text = "Viewer";
           this.menuStrip1.ResumeLayout(false);
           this.menuStrip1.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Autodesk.Navisworks.Api.Controls.ViewControl viewControl;
        private Autodesk.Navisworks.Api.Controls.DocumentControl documentControl;
    }
}

