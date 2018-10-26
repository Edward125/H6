using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H6
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new FrmMain());
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(2000);
            th.Abort();
            Thread.Sleep(500);
            
            Application.Run(new FrmMain());
        }



        private static void DoSplash()
        {
            Splash sp = new Splash();
            sp.ShowDialog();
        }
    }
}
