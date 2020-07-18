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

        public void refreshMumberLV()
        {
            Program.md.clearFleetInfo();
            mumberLV.Items.Clear();
            Program.md.cleanScope();
            Program.md.cleanSoldier();

            Program.md.readFleetInfo(FleetInfoTB.Text);
            foreach (MoneyDistributor.Mumber m in Program.md.Current_mumbers.Values)
            {
                ListViewItem lvi = new ListViewItem();
                if (m.parent == "")
                {

                    if (m.isNew)
                    {
                        lvi.Text = "*";
                        lvi.SubItems.Add(m.name);
                        lvi.SubItems.Add("");
                        mumberLV.Items.Add(lvi);
                    }
                    else
                    {
                        lvi.Text = "";
                        lvi.SubItems.Add(m.name);
                        lvi.SubItems.Add("");
                        mumberLV.Items.Add(lvi);
                    }
                }
                else
                {
                    lvi.Text = "";
                    lvi.SubItems.Add(m.name);
                    lvi.SubItems.Add(m.parent);
                    mumberLV.Items.Add(lvi);
                }
            }
        }

        private void FleetInfoTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                refreshMumberLV();
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
                refreshMumberLV();
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
                refreshMumberLV();
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
            refreshMumberLV();
        }

        private void addScopeBtn_Click(object sender, EventArgs e)
        {
            if (mumberLV.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in mumberLV.SelectedItems)
                {
                    string name = lvi.SubItems[1].Text;
                    if (Program.md.addScope(name))
                    {
                        lvi.BackColor = Color.Red;
                    }
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
                    if (Program.md.addScopeOnly(name))
                    {
                        lvi.BackColor = Color.Yellow;
                    }
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
                Program.md.removeCurrentMumber(mumberLV.SelectedItems[0].SubItems[1].Text.ToString());
                mumberLV.SelectedItems[0].Remove();
            }
        }

        private void addCMumberBtn_Click(object sender, EventArgs e)
        {

        }


    }
}
