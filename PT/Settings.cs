using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace PT
{
    public partial class Settings : Form
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public Settings()
        {
            log.Info("Инициализация окна \"Настройки\"");
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.Info("Закрытие окна \"Настройки\"");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("log.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("log.txt","");
            MessageBox.Show("log файл успешно очищен.");
        }
    }
}
