namespace CodeRun.Forms
{
   partial class CodeRunForm
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
         this.codeRunControl1 = new CodeRun.Control.CodeRunControl();
         this.SuspendLayout();
         // 
         // codeRunControl1
         // 
         this.codeRunControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.codeRunControl1.Location = new System.Drawing.Point(0, 0);
         this.codeRunControl1.MinimumSize = new System.Drawing.Size(510, 283);
         this.codeRunControl1.Name = "codeRunControl1";
         this.codeRunControl1.Size = new System.Drawing.Size(510, 346);
         this.codeRunControl1.TabIndex = 0;
         // 
         // CodeRunForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(509, 346);
         this.Controls.Add(this.codeRunControl1);
         this.MinimumSize = new System.Drawing.Size(517, 380);
         this.Name = "CodeRunForm";
         this.Text = "Code Runner";
         this.ResumeLayout(false);

      }

      #endregion

      private CodeRun.Control.CodeRunControl codeRunControl1;

   }
}