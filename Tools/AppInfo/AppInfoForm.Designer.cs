namespace AppInfo
{
   partial class AppInfoForm
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
         this.appInfoControl = new Control.AppInfoControl();
         this.SuspendLayout();
         // 
         // appInfoControl
         // 
         this.appInfoControl.AutoSize = true;
         this.appInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.appInfoControl.Location = new System.Drawing.Point(0, 0);
         this.appInfoControl.MinimumSize = new System.Drawing.Size(585, 280);
         this.appInfoControl.Name = "appInfoControl";
         this.appInfoControl.Size = new System.Drawing.Size(747, 541);
         this.appInfoControl.TabIndex = 0;
         // 
         // AppInfoForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(747, 541);
         this.Controls.Add(this.appInfoControl);
         this.KeyPreview = true;
         this.Name = "AppInfoForm";
         this.Text = "Application Information";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppInfoForm_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Control.AppInfoControl appInfoControl;

   }
}