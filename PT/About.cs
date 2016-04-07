using System;
using System.Windows.Forms;
using NLog;

namespace PT
{
    public partial class About : Form
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public About()
        {
            log.Info("Инициальзация окна \"О программе\"");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Закрытие окна \"О программе\"");
            Close();
        }
    }
}
