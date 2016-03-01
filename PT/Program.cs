using System;
using System.Windows.Forms;
using NLog;
using NLog.Fluent;

namespace PT
{
    static class Program
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                log.Info("Запуск приложения.");
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                log.Fatal("Критическая ошибка. Информация: {0}", ex);
                MessageBox.Show(@"Произошла ошибка. Приложение будет закрыто. Нам жаль.");
                throw; // todo избавиться после релиза
            }
            log.Info("Завершение работы приложения.");
        }
    }
}
