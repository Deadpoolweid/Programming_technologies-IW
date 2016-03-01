using System;
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
    }
}
