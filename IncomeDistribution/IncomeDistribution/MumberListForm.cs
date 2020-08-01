using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncomeDistribution
{
    public partial class accountListForm : Form
    {
        private TreeNode main_node;
        private Dictionary<string, TreeNode> nodes;

        public accountListForm()
        {
            InitializeComponent();
            initMumberList();
        }

        private void initMumberList()
        {
            main_node = new TreeNode();
            main_node.Text = Program.MAIN_NODE_NAME;
            main_node.Tag = 0;
            mumbersTV.Nodes.Add(main_node);
            readMumberList();
        }

        private void readMumberList()
        {
            main_node.Nodes.Clear();
            nodes = new Dictionary<string, TreeNode>();
            foreach (MoneyDistributor.Mumber m in Program.md.Mumbers_list.Values)
            {
                if (string.IsNullOrEmpty(m.parent))
                {
                    TreeNode parent_nodes = new TreeNode();
                    parent_nodes.Text = m.name;
                    parent_nodes.Tag = "parent";
                    nodes[m.name] = parent_nodes;
                    main_node.Nodes.Add(parent_nodes);
                }
            }
            foreach (MoneyDistributor.Mumber m in Program.md.Mumbers_list.Values)
            {
                if (!string.IsNullOrEmpty(m.parent))
                {
                    TreeNode sub_nodes = new TreeNode();
                    sub_nodes.Text = m.name;
                    sub_nodes.Tag = "sub";
                    nodes[m.name] = sub_nodes;
                    nodes[m.parent].Nodes.Add(sub_nodes);
                }
            }
            mumbersTV.ExpandAll();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (mumbersTV.SelectedNode != null)
            {
                if (!string.IsNullOrEmpty(searchTB.Text.Trim()))
                {
                    if (mumbersTV.SelectedNode.Tag.ToString() == "0")
                    {
                        if (!Program.md.addMumber(searchTB.Text.Trim(), ""))
                        {
                            string o_parent = Program.md.Mumbers_list[searchTB.Text.Trim()].original_parent;
                            if (string.IsNullOrEmpty(o_parent)) {
                                MessageBox.Show("原为主账号，现已更为主账号");
                            }
                            else
                            {
                                MessageBox.Show("原为 " + o_parent + " 小号，现已更为主账号");
                            }
                        }
                    }
                    else
                    {
                        if (mumbersTV.SelectedNode.Text == searchTB.Text.Trim())
                        {
                            MessageBox.Show("无法将主账号添加为主账号的小号，禁止套娃！");
                        }
                        else if (mumbersTV.SelectedNode.Tag.ToString() != "parent")
                        {
                            MessageBox.Show("无法在小号下关联小号");
                        }
                        else
                        {
                            if (!Program.md.addMumber(searchTB.Text.Trim(), mumbersTV.SelectedNode.Text))
                            {
                                string o_parent = Program.md.Mumbers_list[searchTB.Text.Trim()].original_parent;
                                if (string.IsNullOrEmpty(o_parent))
                                {
                                    MessageBox.Show("原为主账号，现已更为 " + mumbersTV.SelectedNode.Text + " 小号");
                                }
                                else
                                {
                                    MessageBox.Show("原为 " + o_parent + " 小号，现已更为 " + mumbersTV.SelectedNode.Text + " 小号");
                                }
                            }
                        }
                    }
                    readMumberList();
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (mumbersTV.SelectedNode != null)
            {
                if (mumbersTV.SelectedNode.Tag.ToString() != "0")
                {
                    if (mumbersTV.SelectedNode.Tag.ToString() == "parent")
                    {
                        foreach (TreeNode sub_node in mumbersTV.SelectedNode.Nodes)
                        {
                            Program.md.removeMumber(sub_node.Text);
                        }
                    }
                    Program.md.removeMumber(mumbersTV.SelectedNode.Text);
                }
                readMumberList();
            }
        }

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string target = searchTB.Text.Trim();
                if (!string.IsNullOrEmpty(target)){
                    if (nodes.ContainsKey(target)) {
                        mumbersTV.SelectedNode = nodes[target];
                    }
                    else
                    {
                        MessageBox.Show("未找到该账号");
                    }
                }
            }
        }

        private void accountListForm_Deactivate(object sender, EventArgs e)
        {
            MainForm.p_MainForm.genMumberLV();
        }
    }
}
