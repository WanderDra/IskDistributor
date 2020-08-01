namespace IncomeDistribution
{
    partial class IntroductionForm
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
            this.contentTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // contentTB
            // 
            this.contentTB.Location = new System.Drawing.Point(12, 12);
            this.contentTB.MaxLength = 99999999;
            this.contentTB.Multiline = true;
            this.contentTB.Name = "contentTB";
            this.contentTB.ReadOnly = true;
            this.contentTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentTB.Size = new System.Drawing.Size(251, 427);
            this.contentTB.TabIndex = 0;
            // 
            // IntroductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(275, 450);
            this.Controls.Add(this.contentTB);
            this.Name = "IntroductionForm";
            this.Text = "说明";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentTB;
    }
}