namespace BasicDockPanePlugin
{
   partial class HelloWorldControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.helloWorldText = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // helloWorldText
         // 
         this.helloWorldText.AutoSize = true;
         this.helloWorldText.Location = new System.Drawing.Point(3, 11);
         this.helloWorldText.Name = "helloWorldText";
         this.helloWorldText.Size = new System.Drawing.Size(71, 13);
         this.helloWorldText.TabIndex = 0;
         this.helloWorldText.Text = "Hello World!!!";
         // 
         // HelloWorldControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.Controls.Add(this.helloWorldText);
         this.MaximumSize = new System.Drawing.Size(250, 300);
         this.MinimumSize = new System.Drawing.Size(250, 300);
         this.Name = "HelloWorldControl";
         this.Size = new System.Drawing.Size(250, 300);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label helloWorldText;
   }
}
