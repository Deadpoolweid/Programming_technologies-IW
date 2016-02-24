using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void вToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                string textFile = fd.FileName;


                string[] text = File.ReadAllLines(textFile);

                bool match1 = Regex.IsMatch(text[0], @"^f\(x\) = \S*$");
                bool match2 = Regex.IsMatch(text[1], @"^from -?\d+ to -?\d+$");
                bool match3 = Regex.IsMatch(text[2], @"^epsilon = \d+$");


                //MessageBox.Show("m1 = " + match1 + ", m2 = " + match2 + ", m3 = " + match3 +"");
                if (match1 && match2 && match3)
                {
                    string fx = Regex.Replace(text[0], @"[f\(x\) = ]{7}", "").ToString();
                    string from = Regex.Match(text[1], @"\d+").ToString();
                    string to = Regex.Match(text[1], @"\d+$").ToString();
                    string epsilon = Regex.Match(text[2], @"\d+$").ToString();

                    tFunction.Text = fx;
                    t_a.Text = from;
                    t_b.Text = to;
                    t_e.Text = epsilon;
                }
                else
                {
                    MessageBox.Show("Данные в указанном файле имеет неверный формат.");
                }

            }
            else
            {
                MessageBox.Show("Произошла ошибка при открытии файла.");
            }

        }
    }
}
