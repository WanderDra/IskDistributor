using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;


namespace IncomeDistribution
{
    public class MoneyDistributor
    {
        private Dictionary<string, Mumber> current_mumbers;
        private Dictionary<string, Mumber> mumbers_list;

        private Dictionary<string, Mumber> scope_list;
        private Dictionary<string, Mumber> soldier_list;

        private string report;

        public Dictionary<string, Mumber> Current_mumbers { get => current_mumbers; set => current_mumbers = value; }
        public Dictionary<string, Mumber> Mumbers_list { get => mumbers_list; }
        public Dictionary<string, Mumber> Scope_list { get => scope_list; }

        [Serializable()]
        public class Mumber
        {
            public string name;
            public string parent;
            public bool isNew;
            public string original_parent;
            public int isScope;
            public bool isScopeOnly;
            public Mumber()
            {
                name = "";
                parent = "";
                isNew = true;
                original_parent = "";
                isScope = 0;
                isScopeOnly = false;
            }

            public Mumber(string name)
            {
                this.name = name;
                parent = "";
                isNew = true;
                original_parent = "";
                isScope = 0;
                isScopeOnly = false;
            }
        }

        public MoneyDistributor()
        {
            current_mumbers = new Dictionary<string, Mumber>();
            mumbers_list = new Dictionary<string, Mumber>();
            soldier_list = new Dictionary<string, Mumber>();
            scope_list = new Dictionary<string, Mumber>();
            Program.formatter = new BinaryFormatter();
            report = "";
            readMumberList();
        }


        public void readFleetInfo(string fleet_info)
        {
            string[] line = fleet_info.Split('\n');
            foreach (string s in line)
            {
                if (s.Trim() == "")
                {
                    continue;
                }
                string name = s.Split('\t')[0].Trim();
                if (current_mumbers.ContainsKey(name))
                {
                    continue;
                }

                addCurrentMumber(name);
            }
        }

        public void clearFleetInfo()
        {
            current_mumbers.Clear();
        }

        public bool addScope(string name)
        {
            if (!scope_list.ContainsKey(name))
            {
                if (mumbers_list.ContainsKey(name))
                {
                    scope_list[name] = mumbers_list[name];
                    return true;
                }
                else
                {
                    scope_list[name] = new Mumber(name);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool addScopeOnly(string name)
        {
            if (!scope_list.ContainsKey(name))
            {
                if (mumbers_list.ContainsKey(name))
                {
                    scope_list[name] = mumbers_list[name];
                    scope_list[name].isScopeOnly = true;
                    return true;
                }
                else
                {
                    scope_list[name] = new Mumber(name);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void removeScope(string name)
        {
            if (scope_list.ContainsKey(name))
            {
                scope_list[name].isScopeOnly = false;
                scope_list.Remove(name);
            }
        }

        public void cleanScope()
        {
            scope_list.Clear();
        }

        public void cleanSoldier()
        {
            soldier_list.Clear();
        }

        public void addCurrentMumber(string name)
        {
            if (!current_mumbers.ContainsKey(name))
            {
                if (!mumbers_list.ContainsKey(name))
                {
                    Mumber m = new Mumber();
                    m.name = name;
                    current_mumbers[name] = m;
                }
                else
                {
                    current_mumbers[name] = mumbers_list[name];
                }
            }
        }

        public void removeCurrentMumber(string name)
        {
            if (current_mumbers.ContainsKey(name))
            {
                current_mumbers.Remove(name);
            }
            
            if (scope_list.ContainsKey(name))
            {
                scope_list.Remove(name);
            
            }
            if (soldier_list.ContainsKey(name))
            {
                soldier_list.Remove(name);
            }
        }

        public bool addMumber(string name, string parent)
        {
            bool isNew;
            if (name == parent)
            {
                MessageBox.Show("无法添加自己为自己的子账号，禁止套娃！");
                return false;
            }
            if (!mumbers_list.ContainsKey(name))
            {
                Mumber m = new Mumber();
                m.name = name;
                if (parent != "")
                {
                    if (mumbers_list.ContainsKey(parent))
                    {
                        if (mumbers_list[parent].parent != "")
                        {
                            MessageBox.Show("无法在子账号下添加子账号！");
                            return false;
                        }
                        m.parent = parent;
                    }
                    else
                    {
                        MessageBox.Show(parent + "此账号不存在！");
                        return false;
                    }
                }
                m.isNew = false;
                mumbers_list[name] = m;
                isNew = true;
            }
            else
            {
                if (mumbers_list.ContainsKey(parent))
                {
                    if (mumbers_list[parent].parent != "")
                    {
                        MessageBox.Show("无法在子账号下添加子账号！");
                        return false;
                    }
                }
                else
                {
                    if (parent != "")
                    {
                        MessageBox.Show("该主账号不存在！");
                        return false;
                    }
                }
            
                Mumber m = mumbers_list[name];
                m.original_parent = m.parent;
                m.parent = parent;
                m.isNew = false;
                mumbers_list[name] = m;
                isNew = false;
            }
            saveMumberList();
            return isNew;
        }

        public void removeMumber(string name)
        {
            mumbers_list.Remove(name);
            saveMumberList();
        }

        public void readMumberList()
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "MumberList.sav", FileMode.OpenOrCreate);
            try
            {
                mumbers_list = (Dictionary<string, Mumber>)Program.formatter.Deserialize(fs);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fs.Close();
        }

        public void saveMumberList()
        {
            FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "MumberList.sav", FileMode.OpenOrCreate);
            try
            {
                Program.formatter.Serialize(file, mumbers_list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            file.Close();
        }

        public void importMumberFromFile(FileStream file)
        {
            StreamReader sr = new StreamReader(file);

            string main_account = "";
            string line;
            while ((line = sr.ReadLine()) != null){
                if (line.Trim() == "")
                {
                    continue;
                }
                line = line.Trim();
                string[] content = line.Split(':');
                if (content[0] == Program.MAIN_ACCOUNT_HEAD)
                {
                    main_account = content[1];
                    addMumber(main_account, "");
                }
                else if(content[0] == Program.SUB_ACCOUNT_HEAD)
                {
                    string[] sub_accounts = content[1].Split(',');
                    foreach (string s in sub_accounts)
                    {
                        addMumber(s, main_account);
                    }
                }
            }
            sr.Close();
        }

        public string generateReport(double income)
        {
            bool is_new_exist = false;
            report = "";
            soldier_list.Clear();
            List<Mumber> new_account = new List<Mumber>();
            foreach(Mumber m in current_mumbers.Values)
            {
                if (!m.isNew)
                {
                    if (!soldier_list.ContainsKey(m.name))
                    {
                        if (m.parent == "")
                        {
                            soldier_list[m.name] = m;
                        }
                        else
                        {
                            if (!soldier_list.ContainsKey(m.parent))
                            {
                                soldier_list[m.parent] = mumbers_list[m.parent];
                            }
                        }
                    }
                }
                else
                {
                    is_new_exist = true;
                    new_account.Add(m);
                }
            }


            if (is_new_exist)
            {
                DialogResult MsgBoxResult;
                MsgBoxResult = MessageBox.Show("存在未确认玩家，是否计入结算？",
                    "警告",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (MsgBoxResult == DialogResult.Yes)//如果对话框的返回值是YES（按"Y"按钮）
                {
                    foreach (Mumber m in new_account)
                    {
                        if (!soldier_list.ContainsKey(m.name))
                        {
                            if (m.parent == "")
                            {
                                soldier_list[m.name] = m;
                            }
                            else
                            {
                                if (!soldier_list.ContainsKey(m.parent))
                                {
                                    soldier_list[m.parent] = mumbers_list[m.parent];
                                }
                            }
                        }
                    }

                }
            }


            List<string> scope_list_temp = new List<string>();
            foreach (Mumber m in scope_list.Values)
            {
                if (m.parent == "")
                {
                    if (!scope_list_temp.Contains(m.name))
                    {
                        scope_list_temp.Add(m.name);
                    }
                }
                else
                {
                    if (!scope_list_temp.Contains(m.parent))
                    {
                        scope_list_temp.Add(m.parent);
                    }
                }
            }

            List<string> soldier_list_temp = new List<string>();
            foreach (Mumber m in soldier_list.Values)
            {
                if (m.parent == "")
                {
                    if (!soldier_list_temp.Contains(m.name))
                    {
                        soldier_list_temp.Add(m.name);
                    }
                }
                else
                {
                    if (!soldier_list_temp.Contains(m.parent))
                    {
                        soldier_list_temp.Add(m.parent);
                    }
                }
            }
            foreach (Mumber m in current_mumbers.Values)
            {
                if (m.isScopeOnly)
                {
                    if (m.parent == "")
                    {
                        if (soldier_list_temp.Contains(m.name))
                        {
                            soldier_list_temp.Remove(m.name);
                        }
                    }
                    else
                    {
                        if (soldier_list_temp.Contains(m.parent))
                        {
                            soldier_list_temp.Remove(m.parent);
                        }
                    }
                }
            }


            report += "参与:\r\n";
            report += "\r\n";
            foreach (string m in soldier_list_temp)
            {
                report += m + "\r\n";
            }
            report += "\r\n";
            report += "共计       " + soldier_list_temp.Count + " 人\r\n\r\n";
            report += "斥候:\r\n";

            
            foreach(string n in scope_list_temp)
            {
                report += n + "\r\n";
            }
            
            report += "\r\n";
            report += "共计       " + scope_list_temp.Count + " 人\r\n";
            report += "============================\r\n";
            report += "总收入:" + income.ToString("N0") + " Isk\r\n";

            double scope_bonus = income * Program.SCOPE_BONUS;
            if (scope_list_temp.Count == 0)
            {
                scope_bonus = 0;
            }
            double avg = (income - scope_bonus) / soldier_list_temp.Count;
            scope_bonus /= scope_list_temp.Count;

            report += "斥候奖励: " + scope_bonus.ToString("N0") + " /人\r\n";
            report += "参与奖励: " + avg.ToString("N0") + " /人\r\n";
            return report;
        }
    }
}
