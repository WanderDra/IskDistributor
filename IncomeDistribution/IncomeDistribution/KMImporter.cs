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
    public partial class KMImporter : Form
    {
        public KMImporter()
        {
            InitializeComponent();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            Program.md.readKM(KMTB.Text.ToString());
        }

        private void introBtn_Click(object sender, EventArgs e)
        {
            string intro =
                "将KM复制至文本框内点击 导入KM核查\r\n" +
                "KM列表中出现的ID将会添加至参与成员\r\n" +
                "不存在于KM的成员和只存在于KM的成员会被符号标注，详见符号说明\r\n" +
                "可以多次导入KM，将会自动去重，累加新出现的玩家\r\n" +
                "点击主界面的 重置KM 删除所有已导入的KM信息";
            Program.md.showIntroDialog(intro);
        }
    }
}
