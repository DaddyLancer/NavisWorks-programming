namespace Viewer
{
   partial class ApplicationControlProperties
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
         this.closeFileAfterLoad = new System.Windows.Forms.CheckBox();
         this.isHardwarAccelerationActive = new System.Windows.Forms.CheckBox();
         this.isHardwarAccelerationAvailable = new System.Windows.Forms.CheckBox();
         this.preferHardwareAcceleration = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.ok = new System.Windows.Forms.Button();
         this.cancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // closeFileAfterLoad
         // 
         this.closeFileAfterLoad.AutoSize = true;
         this.closeFileAfterLoad.Location = new System.Drawing.Point(21, 21);
         this.closeFileAfterLoad.Name = "closeFileAfterLoad";
         this.closeFileAfterLoad.Size = new System.Drawing.Size(123, 17);
         this.closeFileAfterLoad.TabIndex = 0;
         this.closeFileAfterLoad.Text = "Close File After Load";
         this.closeFileAfterLoad.UseVisualStyleBackColor = true;
         // 
         // isHardwarAccelerationActive
         // 
         this.isHardwarAccelerationActive.AutoSize = true;
         this.isHardwarAccelerationActive.Enabled = false;
         this.isHardwarAccelerationActive.Location = new System.Drawing.Point(21, 44);
         this.isHardwarAccelerationActive.Name = "isHardwarAccelerationActive";
         this.isHardwarAccelerationActive.Size = new System.Drawing.Size(178, 17);
         this.isHardwarAccelerationActive.TabIndex = 1;
         this.isHardwarAccelerationActive.Text = "Is Hardware Acceleration Active";
         this.isHardwarAccelerationActive.UseVisualStyleBackColor = true;
         // 
         // isHardwarAccelerationAvailable
         // 
         this.isHardwarAccelerationAvailable.AutoSize = true;
         this.isHardwarAccelerationAvailable.Enabled = false;
         this.isHardwarAccelerationAvailable.Location = new System.Drawing.Point(21, 67);
         this.isHardwarAccelerationAvailable.Name = "isHardwarAccelerationAvailable";
         this.isHardwarAccelerationAvailable.Size = new System.Drawing.Size(191, 17);
         this.isHardwarAccelerationAvailable.TabIndex = 2;
         this.isHardwarAccelerationAvailable.Text = "Is Hardware Acceleration Available";
         this.isHardwarAccelerationAvailable.UseVisualStyleBackColor = true;
         // 
         // preferHardwareAcceleration
         // 
         this.preferHardwareAcceleration.AutoSize = true;
         this.preferHardwareAcceleration.Location = new System.Drawing.Point(21, 90);
         this.preferHardwareAcceleration.Name = "preferHardwareAcceleration";
         this.preferHardwareAcceleration.Size = new System.Drawing.Size(165, 17);
         this.preferHardwareAcceleration.TabIndex = 5;
         this.preferHardwareAcceleration.Text = "Prefer Hardware Acceleration";
         this.preferHardwareAcceleration.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(18, 120);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(145, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Maximum Image Texture Size";
         // 
         // ok
         // 
         this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.ok.Location = new System.Drawing.Point(21, 173);
         this.ok.Name = "ok";
         this.ok.Size = new System.Drawing.Size(75, 23);
         this.ok.TabIndex = 10;
         this.ok.Text = "Ok";
         this.ok.UseVisualStyleBackColor = true;
         this.ok.Click += new System.EventHandler(this.ok_Click);
         // 
         // cancel
         // 
         this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancel.Location = new System.Drawing.Point(137, 173);
         this.cancel.Name = "cancel";
         this.cancel.Size = new System.Drawing.Size(75, 23);
         this.cancel.TabIndex = 11;
         this.cancel.Text = "Cancel";
         this.cancel.UseVisualStyleBackColor = true;
         // 
         // ApplicationControlProperties
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(231, 203);
         this.Controls.Add(this.cancel);
         this.Controls.Add(this.ok);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.preferHardwareAcceleration);
         this.Controls.Add(this.isHardwarAccelerationAvailable);
         this.Controls.Add(this.isHardwarAccelerationActive);
         this.Controls.Add(this.closeFileAfterLoad);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(239, 237);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(239, 237);
         this.Name = "ApplicationControlProperties";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "Properties";
         this.Load += new System.EventHandler(this.ApplicationControlProperties_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox closeFileAfterLoad;
      private System.Windows.Forms.CheckBox isHardwarAccelerationActive;
      private System.Windows.Forms.CheckBox isHardwarAccelerationAvailable;
      private System.Windows.Forms.CheckBox preferHardwareAcceleration;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button ok;
      private System.Windows.Forms.Button cancel;
   }
}
