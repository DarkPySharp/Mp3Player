using System;
using System.Threading;
using System.Windows.Forms;

namespace Mp3Player
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Except;
            Application.Run(new DJ_SHARP());
        }

        private static void Except(object sender, ThreadExceptionEventArgs e) { MessageBox.Show(e.Exception.ToString(), "DJ-Sharp", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
