using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncomeDistribution
{
    static class Program
    {
        public static MoneyDistributor md;
        public static IFormatter formatter;
        public static string MAIN_NODE_NAME = "主账号列表";
        public static string MAIN_ACCOUNT_HEAD = "收款账号";
        public static string SUB_ACCOUNT_HEAD = "小号";
        public static double SCOPE_BONUS;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
