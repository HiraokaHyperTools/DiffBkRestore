using System;
using System.Collections.Generic;
using System.IO;
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

#if false
            Environment.SetEnvironmentVariable(
                "PATH",
                Environment.GetEnvironmentVariable("PATH")
                + ";"
                + Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    (IntPtr.Size == 4) ? "x86" : "x64"
                )
            );
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RForm(fp));
        }
    }
}