using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace IncomeDistribution
{
    public class MoneyDistributor
    {
        private Dictionary<string, Mumber> current_mumbers;
        private Dictionary<string, Mumber> mumbers_list;


        private List<string> km_list;

        private string report;

        public Dictionary<string, Mumber> Current_mumbers { get => current_mumbers; set => current_mumbers = value; }
        public Dictionary<string, Mumber> Mumbers_list { get => mumbers_list; }

        [Serializable()]
        public class Mumber
        {
            public string name;
            public string parent;
            public bool isNew;
            public string original_parent;

            public int isScope;
            public bool isScope_new;            // Will replace old one in next version.
            public bool isScopeOnly;
            public bool? isInKM;
            public bool? isInKMOnly;

            public Mumber()
            {
                name = "";
                parent = "";
                isNew = true;
                original_parent = "";
                isScope_new = false;
                isScopeOnly = false;
                isInKM = null;
                isInKMOnly = null;
            }

            public Mumber(string name)
            {
                this.name = name;
                parent = "";
                isNew = true;
                original_parent = "";
                isScope_new = false;
                isScopeOnly = false;
                isInKM = null;
                isInKMOnly = null;
            }
        }

        public class MumberNode
        {
            public Mumber m;
            public MumberNode parent = null;
            public List<MumberNode> childs;
            public MumberNode(Mumber m)
            {
                this.m = m;
                childs = new List<MumberNode>();
            }

            public MumberNode(Mumber m, MumberNode parent) 
            {
                this.m = m;
                this.parent = parent;
                childs = new List<MumberNode>();
            }
        }

        public MoneyDistributor()
        {
            current_mumbers = new Dictionary<string, Mumber>();
            mumbers_list = new Dictionary<string, Mumber>();
            km_list = new List<string>();
            Program.formatter = new BinaryFormatter();
            report = "";
            readMumberList();
            initData();
        }

        public void initData()
        {
            foreach(Mumber m in mumbers_list.Values)
            {
                m.isScope = 0;
                m.isScope_new = false;
                m.isScopeOnly = false;
                m.isInKM = null;
                m.isInKMOnly = null;
            }
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

        public void readKM(string km)
        {
            string[] line = km.Split('\n');
            foreach(string s in line)
            {
                string[] splited_s = s.Split('：');
                if (splited_s[0].Trim() == "名称")
                {
                    string name;
                    string[] split_fh = splited_s[1].Split('(');
                    if (split_fh.Length > 1)
                    {
                        name = split_fh[0].Trim();
                    }
                    else
                    {
                        name = splited_s[1].Trim();
                    }
                    if (!km_list.Contains(name))
                    {
                        km_list.Add(name);
                    }
                }
            }
            checkKM();
        }

        public void addScope(string name)
        {
            current_mumbers[name].isScope_new = true;
            current_mumbers[name].isScopeOnly = false;
        }

        public void addScopeOnly(string name)
        {
            current_mumbers[name].isScope_new = true;
            current_mumbers[name].isScopeOnly = true;
        }

        public void removeScope(string name)
        {
            current_mumbers[name].isScope_new = false;
            current_mumbers[name].isScopeOnly = false;
        }

        public void cleanScope()
        {
            foreach (Mumber m in current_mumbers.Values)
            {
                m.isScope_new = false;
                m.isScopeOnly = false;
            }
        }

        /// <summary>
        /// Add a new mumber in current mumber list. New mumber that does not exist in mumber list is acceptable.
        /// </summary>
        /// <param name="name">name of the new mumber</param>
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

        /// <summary>
        /// Mumber Node List is for mumber list file generation.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, MumberNode> getMumberNodeList()
        {
            Dictionary<string, MumberNode> node_list = new Dictionary<string, MumberNode>();
            
            foreach (Mumber m in mumbers_list.Values)
            {
                if (m.parent == "")
                {
                    MumberNode parent = new MumberNode(m);
                    node_list[parent.m.name] = parent;
                }
            }

            foreach (Mumber m in mumbers_list.Values)
            {
                if (m.parent != "")
                {
                    MumberNode child = new MumberNode(m, node_list[m.parent]);
                    node_list[m.parent].childs.Add(child);
                }
            }

            return node_list;
        }

        public void importMumberNodeListFromFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(file);
            Dictionary<string, MumberNode> node_list = new Dictionary<string, MumberNode>();
            string line;
            string parent = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Substring(0, 1) != "\t")
                {
                    Mumber new_parent = new Mumber(line.Trim());
                    node_list[new_parent.name] = new MumberNode(new_parent);
                    parent = new_parent.name;
                }
                else
                {
                    Mumber new_child = new Mumber(line.Trim());
                    node_list[parent].childs.Add(new MumberNode(new_child, node_list[parent]));
                }
            }
            sr.Close();
            file.Close();

            // Save the Node list to Mumber List (Will replace the original data)
            mumbers_list.Clear();
            foreach (MumberNode node in node_list.Values)
            {
                //mumbers_list[node.m.name] = node.m;
                addMumber(node.m.name, "");
                foreach (MumberNode child in node.childs)
                {
                    addMumber(child.m.name, child.parent.m.name);
                    //mumbers_list[child.m.name] = child.m;
                    //mumbers_list[child.m.name].parent = child.parent.m.name;
                }
            }

            //string test = "";
            //foreach (string name in mumbers_list.Keys)
            //{
            //    test += name + "\n";
            //}
            //MessageBox.Show(test);

            saveMumberList();
        }

        // Generate a mumber list file according to Mumber Node List
        public void genMumberListFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(file);
            Dictionary<string, MumberNode> node_list = getMumberNodeList();
            foreach (MumberNode n in node_list.Values)
            {
                sw.WriteLine(n.m.name);
                foreach(MumberNode child in n.childs)
                {
                    sw.WriteLine("\t" + child.m.name);
                }
            }
            sw.Close();
            file.Close();
        }

        //////////////////////////////////////////////////////////////////////

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


        /// <summary>
        /// Get soldiers and scopes in current list.
        /// </summary>
        /// <returns>[soldiers, scopes]</returns>
        public List<Dictionary<string, Mumber>> getSoldierScopeList()
        {
            Dictionary<string, Mumber> soldiers = new Dictionary<string, Mumber>();
            Dictionary<string, Mumber> scopes = new Dictionary<string, Mumber>();
            foreach (Mumber m in current_mumbers.Values)
            {
                if (m.isScope_new)
                {
                    if (m.isScopeOnly)
                    {
                        scopes[m.name] = m;
                    }
                    else
                    {
                        scopes[m.name] = m;
                        soldiers[m.name] = m;
                    }
                }
                else
                {
                    soldiers[m.name] = m;
                }
            }
            List<Dictionary<string, Mumber>> soldiers_scopes_list = new List<Dictionary<string, Mumber>>();
            soldiers_scopes_list.Add(soldiers);
            soldiers_scopes_list.Add(scopes);
            return soldiers_scopes_list;
        }


        /// <summary>
        /// Get final avaliable soldiers and scopes.
        /// </summary>
        /// <param name="ss_list"></param>
        /// <returns>[soldiers, scopes]</returns>
        public List<Dictionary<string, Mumber>> getFinalSoldierScopeList(List<Dictionary<string, Mumber>> ss_list)
        {
            bool is_new_exist = false;
            List<Mumber> new_account = new List<Mumber>();
            Dictionary<string, Mumber> soldier_list_final = new Dictionary<string, Mumber>();
            Dictionary<string, Mumber> scope_list_final = new Dictionary<string, Mumber>();
            foreach (Mumber m in current_mumbers.Values)
            {
                if (!m.isNew)
                {
                    if (!m.isScopeOnly)
                    {
                        if (!soldier_list_final.ContainsKey(m.name))
                        {
                            if (m.parent == "")
                            {
                                soldier_list_final[m.name] = m;
                            }
                            else
                            {
                                if (!soldier_list_final.ContainsKey(m.parent))
                                {
                                    soldier_list_final[m.parent] = mumbers_list[m.parent];
                                }
                            }
                        }
                    }
                    else
                    {
                        if (m.parent == "")
                        {
                            scope_list_final[m.name] = m;
                        }
                        else
                        {
                            if (!scope_list_final.ContainsKey(m.parent))
                            {
                                scope_list_final[m.parent] = mumbers_list[m.parent];
                            }
                        }
                    }

                    if (m.isScope_new)
                    {
                        if (m.parent == "")
                        {
                            scope_list_final[m.name] = m;
                        }
                        else
                        {
                            if (!scope_list_final.ContainsKey(m.parent))
                            {
                                scope_list_final[m.parent] = mumbers_list[m.parent];
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

                if (MsgBoxResult == DialogResult.Yes)
                {
                    foreach (Mumber m in new_account)
                    {
                        if (!m.isScopeOnly)
                        {
                            if (!soldier_list_final.ContainsKey(m.name))
                            {
                                if (m.parent == "")
                                {
                                    soldier_list_final[m.name] = m;
                                }
                                else
                                {
                                    if (!soldier_list_final.ContainsKey(m.parent))
                                    {
                                        soldier_list_final[m.parent] = mumbers_list[m.parent];
                                    }
                                }
                            }
                        }
                        else
                        {
                            scope_list_final[m.name] = m;
                        }

                        if (m.isScope_new)
                        {
                            scope_list_final[m.name] = m;
                        }
                    }

                }
            }

            List<Dictionary<string, Mumber>> final_ss_list = new List<Dictionary<string, Mumber>>();
            final_ss_list.Add(soldier_list_final);
            final_ss_list.Add(scope_list_final);
            return final_ss_list;

        }

        public string generateReport(double income)
        {
            report = "";
            List<Mumber> new_account = new List<Mumber>();

            List<Dictionary<string, Mumber>> ss_list = getSoldierScopeList();
            List<Dictionary<string, Mumber>> final_ss_list = getFinalSoldierScopeList(ss_list);
            

            report += "参与:\r\n";
            report += "\r\n";
            foreach (Mumber m in final_ss_list[0].Values)
            {
                report += m.name + "\r\n";
            }
            report += "\r\n";
            report += "共计       " + final_ss_list[0].Count + " 人\r\n\r\n";
            report += "斥候:\r\n";

            
            foreach(Mumber n in final_ss_list[1].Values)
            {
                report += n.name + "\r\n";
            }
            
            report += "\r\n";
            report += "共计       " + final_ss_list[1].Count + " 人\r\n";
            report += "============================\r\n";
            report += "总收入:" + income.ToString("N0") + " Isk\r\n";

            double scope_bonus = income * Program.SCOPE_BONUS;
            if (final_ss_list[1].Count == 0)
            {
                scope_bonus = 0;
            }
            double avg = (income - scope_bonus) / final_ss_list[0].Count;
            scope_bonus /= final_ss_list[1].Count;

            report += "斥候奖励: " + scope_bonus.ToString("N0") + " /人\r\n";
            report += "参与奖励: " + avg.ToString("N0") + " /人\r\n";

            exportToExcel(MainForm.p_MainForm.getTitle(), final_ss_list[0].Keys.ToList(), final_ss_list[1].Keys.ToList(), income, avg, scope_bonus);

            return report;
        }

        public void exportToExcel(string title, List<string> soldier_list, List<string> scope_list, double income, double avg, double scope_bouns)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Excels" + Path.DirectorySeparatorChar;
            string time = DateTime.Now.ToString().Replace(" ", "_");
            time = time.Replace(":", "_");
            time = time.Replace("/", "_");
            string name = title + "_" + time + ".xlsx";
            string export_path = path + name;
            List<List<string>> table = new List<List<string>>();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileStream fs = new FileStream(export_path, FileMode.Create, FileAccess.ReadWrite);
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("结算表");
            
            for (int i = 0; i < 8; i++)
            {
                List<string> col = new List<string>();
                table.Add(col);
            }

            // Participants Col 1, 2
            // Col 1
            table[0].Add("参与:");
            for (int i = 1; i <= soldier_list.Count; i++)
            {
                table[0].Add(soldier_list[i - 1]);
            }
            table[0].Add("");
            table[0].Add("共计(人):");
            
            // Col 2
            table[1].Add("工资:");
            for (int i = 1; i <= soldier_list.Count; i++)
            {
                table[1].Add(avg.ToString("N0"));
            }
            table[1].Add("");
            table[1].Add(soldier_list.Count.ToString());

            // Scopes Col 4, 5
            // Col 4
            table[3].Add("斥候:");
            for (int i = 1; i <= scope_list.Count; i++)
            {
                table[3].Add(scope_list[i - 1]);
            }
            table[3].Add("");
            table[3].Add("共计(人):");
            // Col 5
            table[4].Add("工资:");
            for (int i = 1; i <= scope_list.Count; i++)
            {
                table[4].Add(scope_bouns.ToString("N0"));
            }
            table[4].Add("");
            table[4].Add(scope_list.Count.ToString());

            // Result Col 7, 8
            // Col 7
            table[6].Add("事件:");
            table[6].Add("斥候分成:");
            table[6].Add("斥候总奖励:");
            table[6].Add("总收入:");
            table[6].Add("日期:");
            // Col 8
            table[7].Add(title);
            table[7].Add(Program.SCOPE_BONUS * 100 + "%");
            table[7].Add((income * Program.SCOPE_BONUS).ToString("N0"));
            table[7].Add(income.ToString("N0"));
            table[7].Add(DateTime.Now.ToString());

            int max_length = 0;
            foreach (List<string> col in table)
            {
                int length = col.Count;
                if (length > max_length)
                {
                    max_length = length;
                }
            }

            List<IRow> rows = new List<IRow>();
            for (int i = 0; i < max_length; i++)
            {
                IRow row = sheet.CreateRow(i);
                rows.Add(row);
            }

            for (int i = 0; i < max_length; i++)
            {
                for (int j = 0; j < table.Count; j++)
                {
                    if (table[j].Count > i)
                    {
                        rows[i].CreateCell(j).SetCellValue(table[j][i]);
                    }
                }
            }

            // Format Resize
            // Row 1
            sheet.SetColumnWidth(0, 30 * 256);
            // Row 2
            sheet.SetColumnWidth(1, 20 * 256);
            // Row 4
            sheet.SetColumnWidth(3, 30 * 256);
            // Row 5
            sheet.SetColumnWidth(4, 20 * 256);
            // Row 7
            sheet.SetColumnWidth(6, 15 * 256);
            // Row 8
            sheet.SetColumnWidth(7, 20 * 256);
            workbook.Write(fs);
            fs.Close();
        }

        public void checkKM()
        {
            foreach (string name in km_list)
            {
                if (current_mumbers.ContainsKey(name))
                {
                    current_mumbers[name].isInKM = true;
                }
                else
                {
                    addCurrentMumber(name);
                    current_mumbers[name].isInKM = true;
                    current_mumbers[name].isInKMOnly = true;
                }
            }

            foreach (Mumber m in current_mumbers.Values)
            {
                if (m.isInKM == null)
                {
                    m.isInKM = false;
                }
                if (m.isInKMOnly == null)
                {
                    m.isInKMOnly = false;
                }
            }

            // Refresh List View
            MainForm.p_MainForm.refreshMumberLV();

            //test
            ////////////////////////////////////
            //string test = "";
            //foreach (string name in km_list)
            //{
            //    test += name + "\n";
            //}
            //MessageBox.Show(test);
            /////////////////////////////////////

        }


        /// <summary>
        /// Reset KM list. isInKM in current mumber list will be set to null.
        /// </summary>
        public void resetKmList()
        {
            km_list.Clear();
            foreach (Mumber m in current_mumbers.Values)
            {
                m.isInKM = null;
                m.isInKMOnly = null;
            }
            checkKM();
            MainForm.p_MainForm.refreshMumberLV();
        }

        /// <summary>
        /// Show an introduction with content.
        /// </summary>
        /// <param name="content"></param>
        public void showIntroDialog(string content)
        {
            IntroductionForm intro_form = new IntroductionForm();
            intro_form.setContent(content);
            intro_form.Show();
        }

    }
}
