using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiffBkRestore
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            String fp = null;
            foreach (String a in args)
            {
                if (a.StartsWith("/") || a.StartsWith("--"))
                {
                }
                else if (fp == null)
                {
                    fp = a;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RForm(fp));
        }
    }
}