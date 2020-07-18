namespace IncomeDistribution
{
    partial class accountListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.mumbersTV = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "搜索";
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(48, 452);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(219, 21);
            this.searchTB.TabIndex = 2;
            this.searchTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTB_KeyDown);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(15, 484);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "移除";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(192, 484);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "添加";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // mumbersTV
            // 
            this.mumbersTV.FullRowSelect = true;
            this.mumbersTV.HideSelection = false;
            this.mumbersTV.HotTracking = true;
            this.mumbersTV.Location = new System.Drawing.Point(14, 12);
            this.mumbersTV.Name = "mumbersTV";
            this.mumbersTV.Size = new System.Drawing.Size(253, 434);
            this.mumbersTV.TabIndex = 4;
            // 
            // accountListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 519);
            this.Controls.Add(this.mumbersTV);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.searchTB);
            this.Controls.Add(this.label1);
            this.Name = "accountListForm";
            this.Text = "账号关系列表";
            this.Deactivate += new System.EventHandler(this.accountListForm_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TreeView mumbersTV;
    }
}