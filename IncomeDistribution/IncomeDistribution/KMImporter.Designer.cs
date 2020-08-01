namespace IncomeDistribution
{
    partial class KMImporter
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
            this.KMTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.importBtn = new System.Windows.Forms.Button();
            this.introBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KMTB
            // 
            this.KMTB.Location = new System.Drawing.Point(14, 28);
            this.KMTB.MaxLength = 99999999;
            this.KMTB.Multiline = true;
            this.KMTB.Name = "KMTB";
            this.KMTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KMTB.Size = new System.Drawing.Size(296, 442);
            this.KMTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "将KM信息粘贴至下方";
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(120, 476);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(75, 23);
            this.importBtn.TabIndex = 2;
            this.importBtn.Text = "导入KM核查";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // introBtn
            // 
            this.introBtn.Location = new System.Drawing.Point(268, 476);
            this.introBtn.Name = "introBtn";
            this.introBtn.Size = new System.Drawing.Size(42, 23);
            this.introBtn.TabIndex = 2;
            this.introBtn.Text = "说明";
            this.introBtn.UseVisualStyleBackColor = true;
            this.introBtn.Click += new System.EventHandler(this.introBtn_Click);
            // 
            // KMImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 508);
            this.Controls.Add(this.introBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KMTB);
            this.Name = "KMImporter";
            this.Text = "KM核对";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KMTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button introBtn;
    }
}