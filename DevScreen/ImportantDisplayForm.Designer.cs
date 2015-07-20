namespace DevScreen
{
    partial class ImportantDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportantDisplayForm));
            this.bottomProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainOutputTextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bottomProgressBar
            // 
            this.bottomProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomProgressBar.BackColor = System.Drawing.Color.Teal;
            this.bottomProgressBar.ForeColor = System.Drawing.Color.DarkRed;
            this.bottomProgressBar.Location = new System.Drawing.Point(0, 338);
            this.bottomProgressBar.Name = "bottomProgressBar";
            this.bottomProgressBar.Size = new System.Drawing.Size(370, 23);
            this.bottomProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bottomProgressBar.TabIndex = 1;
            // 
            // mainOutputTextbox
            // 
            this.mainOutputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainOutputTextbox.BackColor = System.Drawing.Color.Black;
            this.mainOutputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mainOutputTextbox.Location = new System.Drawing.Point(0, 0);
            this.mainOutputTextbox.Name = "mainOutputTextbox";
            this.mainOutputTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.mainOutputTextbox.Size = new System.Drawing.Size(370, 337);
            this.mainOutputTextbox.TabIndex = 2;
            this.mainOutputTextbox.Text = "";
            // 
            // ImportantDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 361);
            this.Controls.Add(this.mainOutputTextbox);
            this.Controls.Add(this.bottomProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportantDisplayForm";
            this.Text = "Ultra Important Shit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar bottomProgressBar;
        private System.Windows.Forms.RichTextBox mainOutputTextbox;
    }
}

