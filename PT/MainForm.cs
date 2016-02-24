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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Result_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            Input.main(tFunction.Text,double.Parse(t_a.Text), double.Parse(t_b.Text),int.Parse(t_e.Text));
            Core.Find_x();
            Result r = new Result();
            r.ShowDialog();
            this.Enabled = true;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            this.Enabled = false;
            a.ShowDialog();
            this.Enabled = true;
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            this.Enabled = false;
            s.ShowDialog();
            this.Enabled = true;
        }
    }
}
