namespace Viewer
{
   partial class SelectionSetItemNameForm
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
         this.ok = new System.Windows.Forms.Button();
         this.cancel = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.itemName = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // ok
         // 
         this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.ok.Location = new System.Drawing.Point(49, 56);
         this.ok.Name = "ok";
         this.ok.Size = new System.Drawing.Size(75, 23);
         this.ok.TabIndex = 2;
         this.ok.Text = "OK";
         this.ok.UseVisualStyleBackColor = true;
         // 
         // cancel
         // 
         this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancel.Location = new System.Drawing.Point(168, 56);
         this.cancel.Name = "cancel";
         this.cancel.Size = new System.Drawing.Size(75, 23);
         this.cancel.TabIndex = 3;
         this.cancel.Text = "Cancel";
         this.cancel.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(65, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Folder name";
         // 
         // folderName
         // 
         this.itemName.Location = new System.Drawing.Point(12, 30);
         this.itemName.Name = "folderName";
         this.itemName.Size = new System.Drawing.Size(268, 20);
         this.itemName.TabIndex = 1;
         // 
         // SelectionSetFolderForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(292, 88);
         this.ControlBox = false;
         this.Controls.Add(this.itemName);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cancel);
         this.Controls.Add(this.ok);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "SelectionSetFolderForm";
         this.Text = "New Folder";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button ok;
      private System.Windows.Forms.Button cancel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox itemName;
   }
}