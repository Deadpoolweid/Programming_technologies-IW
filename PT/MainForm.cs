using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
            if (t_Function.Text == "" || t_a.Text == "" || t_b.Text == "" || t_e.Text == "")
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }
            if (t_a.ForeColor == Color.Red || t_b.ForeColor == Color.Red || t_e.ForeColor == Color.Red || t_Function.ForeColor == Color.Red)
            {
                MessageBox.Show("Неправильный ввод!");
                return;
            }

            Enabled = false;

            Input.Main(t_Function.Text, double.Parse(t_a.Text), double.Parse(t_b.Text), int.Parse(t_e.Text));
            Core.Find_x();
            Result r = new Result();
            try
            {
                r.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при обработке функции. Попробуйте другие данные.");
                throw;
            }
            Enabled = true;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            Enabled = false;
            a.ShowDialog();
            Enabled = true;
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

                if (match1 && match2 && match3)
                {
                    string fx = Regex.Replace(text[0], @"[f\(x\) = ]{7}", "");
                    string from = Regex.Match(text[1], @"[-]?\d+").ToString();
                    string to = Regex.Match(text[1], @"[-]?\d+$").ToString();
                    string epsilon = Regex.Match(text[2], @"\d+$").ToString();

                    t_Function.Text = fx;
                    t_a.Text = from;
                    t_b.Text = to;
                    t_e.Text = epsilon;
                }
                else
                {
                    MessageBox.Show(@"Данные в указанном файле имеет неверный формат.");
                }

            }
            else
            {
                MessageBox.Show(@"Произошла ошибка при открытии файла.");
            }

        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            Enabled = false;
            s.ShowDialog();
            Enabled = true;
        }

        private void t_a_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(t_a.Text, @"^([-]?\d+(.\d+)?)$"))
            {
                t_a.ForeColor = Color.Green;
            }
            else
            {
                t_a.ForeColor = Color.Red;
            }
        }

        private void t_b_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(t_b.Text, @"^([-]?\d+(.\d+)?)$"))
            {
                t_b.ForeColor = Color.Green;
            }
            else
            {
                t_b.ForeColor = Color.Red;
            }
        }

        private void t_e_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(t_e.Text, @"^[-]?\d+$"))
            {
                t_e.ForeColor = Color.Green;
            }
            else
            {
                t_e.ForeColor = Color.Red;
            }
        }

        private void t_Function_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Func<double,double> f = FunctionCreator.FunctionCreator.BuildFunc(t_Function.Text);
            }
            catch 
            {
                t_Function.ForeColor = Color.Red;
                return;
            }
            t_Function.ForeColor =Color.Green;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            PT.Help h = new Help();

            this.Enabled = false;
            h.ShowDialog();
            this.Enabled = true;
        }
    }
}
