using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            double _out = Output.main();
            if (double.IsNaN(_out))
            {
                l_x.Text = @"Не принадлежит указанному иннтервалу, либо не существует.";
                return;
            }
            l_x.Text = Convert.ToString(_out);
        }
    }
}
