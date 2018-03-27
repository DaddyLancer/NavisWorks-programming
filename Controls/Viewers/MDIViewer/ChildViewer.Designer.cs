namespace MDIViewer
{
   partial class ChildViewer
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
         this.viewControl = new Autodesk.Navisworks.Api.Controls.ViewControl();
         this.SuspendLayout();
         // 
         // viewControl
         // 
         this.viewControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.viewControl.DocumentControl = null;
         this.viewControl.Location = new System.Drawing.Point(0, 0);
         this.viewControl.Name = "viewControl";
         this.viewControl.Size = new System.Drawing.Size(413, 313);
         this.viewControl.TabIndex = 0;
         this.viewControl.Text = "viewControl";
         // 
         // ChildViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(413, 313);
         this.Controls.Add(this.viewControl);
         this.Name = "ChildViewer";
         this.ShowInTaskbar = false;
         this.Text = "ChildViewer";
         this.Activated += new System.EventHandler(this.ChildViewer_Activated);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildViewer_FormClosing);
         this.ResumeLayout(false);

      }

      #endregion

      private Autodesk.Navisworks.Api.Controls.ViewControl viewControl;
   }
}