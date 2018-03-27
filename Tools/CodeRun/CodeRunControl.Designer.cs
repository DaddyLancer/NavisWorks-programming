namespace CodeRun.Control
{
   partial class CodeRunControl
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
         this.label2 = new System.Windows.Forms.Label();
         this.mainCodeBody = new System.Windows.Forms.TextBox();
         this.run = new System.Windows.Forms.Button();
         this.output = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.codeCompiler = new System.Windows.Forms.ComboBox();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveCodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.label1 = new System.Windows.Forms.Label();
         this.setDefaultTemplate = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.mainFunction = new System.Windows.Forms.TextBox();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.label5 = new System.Windows.Forms.Label();
         this.fullClassName = new System.Windows.Forms.TextBox();
         this.menuStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 77);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(84, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Main Code body";
         // 
         // mainCodeBody
         // 
         this.mainCodeBody.AcceptsTab = true;
         this.mainCodeBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.mainCodeBody.Location = new System.Drawing.Point(3, 93);
         this.mainCodeBody.Multiline = true;
         this.mainCodeBody.Name = "mainCodeBody";
         this.mainCodeBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.mainCodeBody.Size = new System.Drawing.Size(504, 343);
         this.mainCodeBody.TabIndex = 2;
         this.mainCodeBody.WordWrap = false;
         // 
         // run
         // 
         this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.run.Location = new System.Drawing.Point(432, 468);
         this.run.Name = "run";
         this.run.Size = new System.Drawing.Size(75, 23);
         this.run.TabIndex = 4;
         this.run.Text = "Run";
         this.run.UseVisualStyleBackColor = true;
         this.run.Click += new System.EventHandler(this.run_Click);
         // 
         // output
         // 
         this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.output.Location = new System.Drawing.Point(0, 17);
         this.output.Multiline = true;
         this.output.Name = "output";
         this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.output.Size = new System.Drawing.Size(510, 91);
         this.output.TabIndex = 5;
         this.output.WordWrap = false;
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(39, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Output";
         // 
         // codeCompiler
         // 
         this.codeCompiler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.codeCompiler.FormattingEnabled = true;
         this.codeCompiler.Location = new System.Drawing.Point(3, 42);
         this.codeCompiler.Name = "codeCompiler";
         this.codeCompiler.Size = new System.Drawing.Size(374, 21);
         this.codeCompiler.TabIndex = 7;
         this.codeCompiler.SelectedIndexChanged += new System.EventHandler(this.codeCompiler_SelectedIndexChanged);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(510, 24);
         this.menuStrip1.TabIndex = 8;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileMenuItem
         // 
         this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveCodeMenuItem});
         this.fileMenuItem.Name = "fileMenuItem";
         this.fileMenuItem.Size = new System.Drawing.Size(35, 20);
         this.fileMenuItem.Text = "File";
         // 
         // openFileMenuItem
         // 
         this.openFileMenuItem.Name = "openFileMenuItem";
         this.openFileMenuItem.Size = new System.Drawing.Size(168, 22);
         this.openFileMenuItem.Text = "Open File...";
         this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
         // 
         // saveCodeMenuItem
         // 
         this.saveCodeMenuItem.Name = "saveCodeMenuItem";
         this.saveCodeMenuItem.Size = new System.Drawing.Size(168, 22);
         this.saveCodeMenuItem.Text = "Save code to File...";
         this.saveCodeMenuItem.Click += new System.EventHandler(this.saveCodeMenuItem_Click);
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(55, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Language";
         // 
         // setDefaultTemplate
         // 
         this.setDefaultTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.setDefaultTemplate.Location = new System.Drawing.Point(383, 40);
         this.setDefaultTemplate.Name = "setDefaultTemplate";
         this.setDefaultTemplate.Size = new System.Drawing.Size(124, 23);
         this.setDefaultTemplate.TabIndex = 10;
         this.setDefaultTemplate.Text = "Set Default Template";
         this.setDefaultTemplate.UseVisualStyleBackColor = true;
         this.setDefaultTemplate.Click += new System.EventHandler(this.setDefaultTemplate_Click);
         // 
         // label4
         // 
         this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(325, 445);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(74, 13);
         this.label4.TabIndex = 11;
         this.label4.Text = "Main Function";
         // 
         // mainFunction
         // 
         this.mainFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.mainFunction.Location = new System.Drawing.Point(405, 442);
         this.mainFunction.Name = "mainFunction";
         this.mainFunction.Size = new System.Drawing.Size(102, 20);
         this.mainFunction.TabIndex = 12;
         this.mainFunction.Text = "Main";
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.label5);
         this.splitContainer1.Panel1.Controls.Add(this.fullClassName);
         this.splitContainer1.Panel1.Controls.Add(this.mainFunction);
         this.splitContainer1.Panel1.Controls.Add(this.mainCodeBody);
         this.splitContainer1.Panel1.Controls.Add(this.label4);
         this.splitContainer1.Panel1.Controls.Add(this.label2);
         this.splitContainer1.Panel1.Controls.Add(this.setDefaultTemplate);
         this.splitContainer1.Panel1.Controls.Add(this.run);
         this.splitContainer1.Panel1.Controls.Add(this.label1);
         this.splitContainer1.Panel1.Controls.Add(this.codeCompiler);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.output);
         this.splitContainer1.Panel2.Controls.Add(this.label3);
         this.splitContainer1.Size = new System.Drawing.Size(510, 611);
         this.splitContainer1.SplitterDistance = 499;
         this.splitContainer1.TabIndex = 13;
         // 
         // label5
         // 
         this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(11, 445);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(82, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Full Class Name";
         // 
         // fullClassName
         // 
         this.fullClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.fullClassName.Location = new System.Drawing.Point(99, 442);
         this.fullClassName.Name = "fullClassName";
         this.fullClassName.Size = new System.Drawing.Size(220, 20);
         this.fullClassName.TabIndex = 13;
         this.fullClassName.Text = "CScript.CScript";
         // 
         // CodeRunControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.menuStrip1);
         this.Controls.Add(this.splitContainer1);
         this.MinimumSize = new System.Drawing.Size(510, 283);
         this.Name = "CodeRunControl";
         this.Size = new System.Drawing.Size(510, 611);
         this.Load += new System.EventHandler(this.CodeRunForm_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox mainCodeBody;
      private System.Windows.Forms.Button run;
      private System.Windows.Forms.TextBox output;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox codeCompiler;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
      private System.Windows.Forms.ToolStripMenuItem saveCodeMenuItem;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button setDefaultTemplate;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox mainFunction;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox fullClassName;

      #endregion
   }
}
