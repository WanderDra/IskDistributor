using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;


namespace IncomeDistribution
{
    public partial class MainForm : Form
    {
        public static MainForm p_MainForm;

        accountListForm mumber_list_form;

        public MainForm()
        {
            InitializeComponent();
            Program.md = new MoneyDistributor();
            p_MainForm = this;
        }


        /// <summary>
        /// Generate mumberlistLV
        /// </summary>
        public void genMumberLV()
        {
            Program.md.clearFleetInfo();
            mumberLV.Items.Clear();
            Program.md.cleanScope();

            Program.md.readFleetInfo(FleetInfoTB.Text);
            foreach (MoneyDistributor.Mumber m in Program.md.Current_mumbers.Values)
            {
                addMumberInListView(m);
            }

            Program.md.checkKM();
        }

        /// <summary>
        /// Refresh mumberListLV, without clearing the scopes and fleet info.
        /// </summary>
        public void refreshMumberLV()
        {
            mumberLV.Items.Clear();

            foreach (MoneyDistributor.Mumber m in Program.md.Current_mumbers.Values)
            {
                addMumberInListView(m);
            }
        }

        public void addMumberInListView(MoneyDistributor.Mumber m)
        {
            ListViewItem lvi = new ListViewItem();
            
            // Mark?
            if (m.parent == "")
            {

                if (m.isNew)
                {
                    //MessageBox.Show("test");
                    lvi.Text = "*";
                    if (m.isInKM == false)
                    {
                        lvi.Text = "-*";
                    }
                    if (m.isInKMOnly == true)
                    {
                        lvi.Text = "+*";
                    }
                }
                else
                {
                    lvi.Text = "";
                    if (m.isInKM == false)
                    {
                        lvi.Text = "-";
                    }
                    if (m.isInKMOnly == true)
                    {
                        lvi.Text = "+";
                    }
                }

                lvi.SubItems.Add(m.name);
                lvi.SubItems.Add("");
                mumberLV.Items.Add(lvi);
            }
            else
            {
                lvi.Text = "";
                if (m.isInKM == false)
                {
                    lvi.Text = "-";
                }
                if (m.isInKMOnly == true)
                {
                    lvi.Text = "+";
                }
                lvi.SubItems.Add(m.name);
                lvi.SubItems.Add(m.parent);
                mumberLV.Items.Add(lvi);
            }

            // Back color?
            if (m.isScope_new)
            {
                if (m.isScopeOnly)
                {
                    lvi.BackColor = Color.Yellow;
                }
                else
                {
                    lvi.BackColor = Color.Red;
                }
            }
        }

        public string getTitle()
        {
            string title;
            if (titleTB.Text.ToString().Length != 0)
            {
                title = titleTB.Text.ToString();
            }
            else
            {
                title = "UnnamedAction";
            }
            return title;
        }

        private void FleetInfoTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                genMumberLV();
            }
        }

        private void mumberLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addAvoidBtn_Click(object sender, EventArgs e)
        {
            //Program.md.addAvoidMumber("Test1");
            //Program.md.addAvoidMumber("Test2");
            //Program.md.addAvoidMumber("Test3");
            //Program.md.addAvoidMumber("Test3");
            //Program.md.addAvoidMumber("Test3");
            //Program.md.saveAvoidList();
        }

        private void openAvoidListBtn_Click(object sender, EventArgs e)
        {
            mumber_list_form = new accountListForm();
            mumber_list_form.ShowDialog();
        }

        private void addSubBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count > 0)
            {
                Program.md.addMumber(mumberLV.SelectedItems[0].SubItems[1].Text.ToString(), mainAccountTB.Text);
                genMumberLV();
            }

        }

        private void addMainBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    Program.md.addMumber(lvi.SubItems[1].Text.ToString(), "");
                }
                genMumberLV();
            }
        }

        private void importAccountFromFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.Filter = "文本文件|*.txt";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fName = ofd.FileName;
                FileStream file = new FileStream(fName, FileMode.Open);
                Program.md.importMumberFromFile(file);
            }
            genMumberLV();
        }

        private void addScopeBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    string name = lvi.SubItems[1].Text;
                    Program.md.addScope(name);
                    lvi.BackColor = Color.Red;
                }
            }
        }

        private void addScopeOnlyBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    string name = lvi.SubItems[1].Text;
                    Program.md.addScopeOnly(name);
                    lvi.BackColor = Color.Yellow;
                }
            }
        }

        private void removeScopeBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    string name = lvi.SubItems[1].Text;
                    Program.md.removeScope(name);
                    lvi.BackColor = Color.White;
                }
            }
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            string report = "";
            report += "============================\r\n";
            int length = (int)((report.Length - titleTB.Text.ToString().Length * 2) / 2);
            if (length < 0)
            {
                length = 0;
            }
            for (int i = 0; i < length; i++)
            {
                report += " ";
            }
            report += titleTB.Text.ToString() + "\r\n";
            report += "============================\r\n";

            try
            {
                double income = double.Parse(incomeTB.Text.ToString().Trim());
                Program.SCOPE_BONUS = double.Parse(scopeBonusTB.Text.ToString().Trim()) / 100;
                report += Program.md.generateReport(income);
                reportTB.Text = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void incomeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void incomeTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double income = double.Parse(incomeTB.Text.ToString());
                incomeTB.Text = income.ToString("N0");
                incomeTB.Select(incomeTB.Text.Length, 0);
            }catch(Exception ex)
            {

            }
        }

        private void removeCMumberBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count != 0) {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    Program.md.removeCurrentMumber(lvi.SubItems[1].Text.ToString());
                    lvi.Remove();
                }
            }
        }

        private void importMumberListBtn2_Click(object sender, EventArgs e)
        {
            // Replace warning 
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("导入将会覆盖原有列表，是否继续？",
                "警告",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (MsgBoxResult == DialogResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string init_path = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "ExportedAccountList";
                if (!Directory.Exists(init_path))
                {
                    Directory.CreateDirectory(init_path);
                }
                ofd.InitialDirectory = init_path;
                ofd.Filter = "文本文件|*.txt";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fName = ofd.FileName;
                    Program.md.importMumberNodeListFromFile(fName);
                    MessageBox.Show("导入完成");
                }
            }
        }

        private void exportMumberListBtn2_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString().Replace(" ", "_");
            time = time.Replace(":", "_");
            time = time.Replace("/", "_");

            SaveFileDialog sfd = new SaveFileDialog();
            string init_path = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "ExportedAccountList";
            if (!Directory.Exists(init_path))
            {
                Directory.CreateDirectory(init_path);
            }
            sfd.InitialDirectory = init_path;
            sfd.FileName = "账号列表_" + time;
            sfd.Filter = "文本文件|*.txt";
            sfd.RestoreDirectory = true;
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fName = sfd.FileName;
                Program.md.genMumberListFile(fName);
                MessageBox.Show("导出完成");
            }
        }

        private void KMCheckBtn_Click(object sender, EventArgs e)
        {
            KMImporter km_importer = new KMImporter();
            km_importer.Show();
        }

        private void resetKMBtn_Click(object sender, EventArgs e)
        {
            Program.md.resetKmList();
        }

        private void introBtn_Click(object sender, EventArgs e)
        {
            string intro =
                "-: 未在KM中出现的玩家\r\n" +
                "+: 仅出现在KM中的玩家\r\n" +
                "*: 第一次参与记录的玩家\r\n" +
                "\r\n" +
                "多项满足条件会出现多个符号";
            Program.md.showIntroDialog(intro);
        }
    }
}
