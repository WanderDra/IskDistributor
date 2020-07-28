namespace IncomeDistribution
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FleetInfoTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addScopeBtn = new System.Windows.Forms.Button();
            this.addSubAccountBtn = new System.Windows.Forms.Button();
            this.openAvoidListBtn = new System.Windows.Forms.Button();
            this.mumberLV = new System.Windows.Forms.ListView();
            this.new_mark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.parent_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainAccountTB = new System.Windows.Forms.TextBox();
            this.addMainAccountBtn = new System.Windows.Forms.Button();
            this.importAccountFromFileBtn = new System.Windows.Forms.Button();
            this.reportTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.calculateBtn = new System.Windows.Forms.Button();
            this.scopeBonusTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.incomeTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.removeCMumberBtn = new System.Windows.Forms.Button();
            this.addScopeOnlyBtn = new System.Windows.Forms.Button();
            this.importMumberListBtn2 = new System.Windows.Forms.Button();
            this.exportMumberListBtn2 = new System.Windows.Forms.Button();
            this.KMCheckBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FleetInfoTB
            // 
            this.FleetInfoTB.Location = new System.Drawing.Point(21, 26);
            this.FleetInfoTB.MaxLength = 99999999;
            this.FleetInfoTB.Multiline = true;
            this.FleetInfoTB.Name = "FleetInfoTB";
            this.FleetInfoTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FleetInfoTB.Size = new System.Drawing.Size(230, 331);
            this.FleetInfoTB.TabIndex = 0;
            this.FleetInfoTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FleetInfoTB_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "复制舰队成员列表至下方文本框内";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "参与成员（已排除小号）";
            // 
            // addScopeBtn
            // 
            this.addScopeBtn.Location = new System.Drawing.Point(432, 363);
            this.addScopeBtn.Name = "addScopeBtn";
            this.addScopeBtn.Size = new System.Drawing.Size(75, 23);
            this.addScopeBtn.TabIndex = 3;
            this.addScopeBtn.Text = "添加斥候>>";
            this.addScopeBtn.UseVisualStyleBackColor = true;
            this.addScopeBtn.Click += new System.EventHandler(this.addScopeBtn_Click);
            // 
            // addSubAccountBtn
            // 
            this.addSubAccountBtn.Location = new System.Drawing.Point(270, 437);
            this.addSubAccountBtn.Name = "addSubAccountBtn";
            this.addSubAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.addSubAccountBtn.TabIndex = 3;
            this.addSubAccountBtn.Text = "小号<<";
            this.addSubAccountBtn.UseVisualStyleBackColor = true;
            this.addSubAccountBtn.Click += new System.EventHandler(this.addSubBtn_Click);
            // 
            // openAvoidListBtn
            // 
            this.openAvoidListBtn.Location = new System.Drawing.Point(176, 368);
            this.openAvoidListBtn.Name = "openAvoidListBtn";
            this.openAvoidListBtn.Size = new System.Drawing.Size(75, 23);
            this.openAvoidListBtn.TabIndex = 4;
            this.openAvoidListBtn.Text = "账号列表";
            this.openAvoidListBtn.UseVisualStyleBackColor = true;
            this.openAvoidListBtn.Click += new System.EventHandler(this.openAvoidListBtn_Click);
            // 
            // mumberLV
            // 
            this.mumberLV.AllowColumnReorder = true;
            this.mumberLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.new_mark,
            this.id,
            this.parent_id});
            this.mumberLV.FullRowSelect = true;
            this.mumberLV.HideSelection = false;
            this.mumberLV.Location = new System.Drawing.Point(270, 26);
            this.mumberLV.Name = "mumberLV";
            this.mumberLV.Size = new System.Drawing.Size(237, 331);
            this.mumberLV.TabIndex = 5;
            this.mumberLV.UseCompatibleStateImageBehavior = false;
            this.mumberLV.View = System.Windows.Forms.View.Details;
            // 
            // new_mark
            // 
            this.new_mark.Text = "新";
            this.new_mark.Width = 24;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 98;
            // 
            // parent_id
            // 
            this.parent_id.Text = "主账号";
            this.parent_id.Width = 111;
            // 
            // mainAccountTB
            // 
            this.mainAccountTB.Location = new System.Drawing.Point(351, 437);
            this.mainAccountTB.Name = "mainAccountTB";
            this.mainAccountTB.Size = new System.Drawing.Size(156, 21);
            this.mainAccountTB.TabIndex = 6;
            this.mainAccountTB.Text = "小号的主账号ID";
            // 
            // addMainAccountBtn
            // 
            this.addMainAccountBtn.Location = new System.Drawing.Point(270, 409);
            this.addMainAccountBtn.Name = "addMainAccountBtn";
            this.addMainAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.addMainAccountBtn.TabIndex = 3;
            this.addMainAccountBtn.Text = "主号<<";
            this.addMainAccountBtn.UseVisualStyleBackColor = true;
            this.addMainAccountBtn.Click += new System.EventHandler(this.addMainBtn_Click);
            // 
            // importAccountFromFileBtn
            // 
            this.importAccountFromFileBtn.Location = new System.Drawing.Point(21, 368);
            this.importAccountFromFileBtn.Name = "importAccountFromFileBtn";
            this.importAccountFromFileBtn.Size = new System.Drawing.Size(132, 23);
            this.importAccountFromFileBtn.TabIndex = 7;
            this.importAccountFromFileBtn.Text = "导入账号列表(邮件)";
            this.importAccountFromFileBtn.UseVisualStyleBackColor = true;
            this.importAccountFromFileBtn.Click += new System.EventHandler(this.importAccountFromFileBtn_Click);
            // 
            // reportTB
            // 
            this.reportTB.Location = new System.Drawing.Point(528, 26);
            this.reportTB.MaxLength = 99999999;
            this.reportTB.Multiline = true;
            this.reportTB.Name = "reportTB";
            this.reportTB.ReadOnly = true;
            this.reportTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reportTB.Size = new System.Drawing.Size(260, 331);
            this.reportTB.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "结算报告";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "<<移除斥候";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.removeScopeBtn_Click);
            // 
            // calculateBtn
            // 
            this.calculateBtn.Location = new System.Drawing.Point(624, 452);
            this.calculateBtn.Name = "calculateBtn";
            this.calculateBtn.Size = new System.Drawing.Size(75, 23);
            this.calculateBtn.TabIndex = 3;
            this.calculateBtn.Text = "<<结算>>";
            this.calculateBtn.UseVisualStyleBackColor = true;
            this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
            // 
            // scopeBonusTB
            // 
            this.scopeBonusTB.Location = new System.Drawing.Point(703, 426);
            this.scopeBonusTB.Name = "scopeBonusTB";
            this.scopeBonusTB.Size = new System.Drawing.Size(56, 21);
            this.scopeBonusTB.TabIndex = 8;
            this.scopeBonusTB.Text = "15";
            this.scopeBonusTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(646, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "斥候奖励";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(762, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "%";
            // 
            // incomeTB
            // 
            this.incomeTB.Location = new System.Drawing.Point(581, 398);
            this.incomeTB.Name = "incomeTB";
            this.incomeTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.incomeTB.Size = new System.Drawing.Size(178, 21);
            this.incomeTB.TabIndex = 8;
            this.incomeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.incomeTB.TextChanged += new System.EventHandler(this.incomeTB_TextChanged);
            this.incomeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.incomeTB_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "总收入";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(761, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Isk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "标题";
            // 
            // titleTB
            // 
            this.titleTB.Location = new System.Drawing.Point(581, 368);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(178, 21);
            this.titleTB.TabIndex = 8;
            this.titleTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // removeCMumberBtn
            // 
            this.removeCMumberBtn.Location = new System.Drawing.Point(351, 391);
            this.removeCMumberBtn.Name = "removeCMumberBtn";
            this.removeCMumberBtn.Size = new System.Drawing.Size(75, 23);
            this.removeCMumberBtn.TabIndex = 3;
            this.removeCMumberBtn.Text = "<<移除参与";
            this.removeCMumberBtn.UseVisualStyleBackColor = true;
            this.removeCMumberBtn.Click += new System.EventHandler(this.removeCMumberBtn_Click);
            // 
            // addScopeOnlyBtn
            // 
            this.addScopeOnlyBtn.Location = new System.Drawing.Point(432, 391);
            this.addScopeOnlyBtn.Name = "addScopeOnlyBtn";
            this.addScopeOnlyBtn.Size = new System.Drawing.Size(75, 23);
            this.addScopeOnlyBtn.TabIndex = 3;
            this.addScopeOnlyBtn.Text = "仅斥候>>";
            this.addScopeOnlyBtn.UseVisualStyleBackColor = true;
            this.addScopeOnlyBtn.Click += new System.EventHandler(this.addScopeOnlyBtn_Click);
            // 
            // importMumberListBtn2
            // 
            this.importMumberListBtn2.Location = new System.Drawing.Point(21, 409);
            this.importMumberListBtn2.Name = "importMumberListBtn2";
            this.importMumberListBtn2.Size = new System.Drawing.Size(132, 23);
            this.importMumberListBtn2.TabIndex = 7;
            this.importMumberListBtn2.Text = "导入账号列表(直观)";
            this.importMumberListBtn2.UseVisualStyleBackColor = true;
            this.importMumberListBtn2.Click += new System.EventHandler(this.importMumberListBtn2_Click);
            // 
            // exportMumberListBtn2
            // 
            this.exportMumberListBtn2.Location = new System.Drawing.Point(21, 435);
            this.exportMumberListBtn2.Name = "exportMumberListBtn2";
            this.exportMumberListBtn2.Size = new System.Drawing.Size(132, 23);
            this.exportMumberListBtn2.TabIndex = 7;
            this.exportMumberListBtn2.Text = "导出账号列表(直观)";
            this.exportMumberListBtn2.UseVisualStyleBackColor = true;
            this.exportMumberListBtn2.Click += new System.EventHandler(this.exportMumberListBtn2_Click);
            // 
            // KMCheckBtn
            // 
            this.KMCheckBtn.Location = new System.Drawing.Point(270, 363);
            this.KMCheckBtn.Name = "KMCheckBtn";
            this.KMCheckBtn.Size = new System.Drawing.Size(75, 23);
            this.KMCheckBtn.TabIndex = 4;
            this.KMCheckBtn.Text = "KM核对";
            this.KMCheckBtn.UseVisualStyleBackColor = true;
            this.KMCheckBtn.Click += new System.EventHandler(this.KMCheckBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 487);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.incomeTB);
            this.Controls.Add(this.scopeBonusTB);
            this.Controls.Add(this.exportMumberListBtn2);
            this.Controls.Add(this.importMumberListBtn2);
            this.Controls.Add(this.importAccountFromFileBtn);
            this.Controls.Add(this.mainAccountTB);
            this.Controls.Add(this.mumberLV);
            this.Controls.Add(this.KMCheckBtn);
            this.Controls.Add(this.openAvoidListBtn);
            this.Controls.Add(this.addMainAccountBtn);
            this.Controls.Add(this.addSubAccountBtn);
            this.Controls.Add(this.removeCMumberBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.calculateBtn);
            this.Controls.Add(this.addScopeOnlyBtn);
            this.Controls.Add(this.addScopeBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportTB);
            this.Controls.Add(this.FleetInfoTB);
            this.Name = "MainForm";
            this.Text = "资金结算小程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FleetInfoTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addScopeBtn;
        private System.Windows.Forms.Button addSubAccountBtn;
        private System.Windows.Forms.Button openAvoidListBtn;
        private System.Windows.Forms.ListView mumberLV;
        private System.Windows.Forms.ColumnHeader new_mark;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader parent_id;
        private System.Windows.Forms.TextBox mainAccountTB;
        private System.Windows.Forms.Button addMainAccountBtn;
        private System.Windows.Forms.Button importAccountFromFileBtn;
        private System.Windows.Forms.TextBox reportTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button calculateBtn;
        private System.Windows.Forms.TextBox scopeBonusTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox incomeTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Button removeCMumberBtn;
        private System.Windows.Forms.Button addScopeOnlyBtn;
        private System.Windows.Forms.Button importMumberListBtn2;
        private System.Windows.Forms.Button exportMumberListBtn2;
        private System.Windows.Forms.Button KMCheckBtn;
    }
}

