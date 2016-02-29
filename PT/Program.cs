using System;
using System.Windows.Forms;

namespace PT
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

            //try
            //{
                Application.Run(new MainForm());
            //}
            //catch
            //{
            //    MessageBox.Show(@"Произошла ошибка. Приложение будет закрыто. Нам жаль.");
            //    throw;
            //}
        }
    }
}
