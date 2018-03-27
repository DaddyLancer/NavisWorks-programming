namespace ClashDetective
{
    partial class ClashMarkersDialog
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
            this.TestsCheckedList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // TestsCheckedList
            // 
            this.TestsCheckedList.FormattingEnabled = true;
            this.TestsCheckedList.Location = new System.Drawing.Point(8, 8);
            this.TestsCheckedList.Name = "TestsCheckedList";
            this.TestsCheckedList.Size = new System.Drawing.Size(264, 229);
            this.TestsCheckedList.TabIndex = 0;
            this.TestsCheckedList.SelectedIndexChanged += new System.EventHandler(this.TestsCheckedList_SelectedIndexChanged);
            // 
            // ClashMarkersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TestsCheckedList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClashMarkersDialog";
            this.ShowIcon = false;
            this.Text = "Clash Markers Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TestsCheckedList;

    }
}