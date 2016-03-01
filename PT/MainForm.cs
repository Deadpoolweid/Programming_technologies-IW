using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NLog;
using NLog.Fluent;

namespace PT
{
    public partial class MainForm : Form
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public MainForm()
        {
            log.Info("Инициализация главного окна.");
            InitializeComponent();
        }

        private void SetTooltips()
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(t_Function,"Функция для решения");
            t.SetToolTip(t_a,"Нижняя граница интервала");
            t.SetToolTip(t_b,"Верхняя граница интервала");
            t.SetToolTip(t_e, "Погрешность при вычислениях");
            t.SetToolTip(Result,"Вычисление корня уравнения");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Выход из приложения.");
            Application.Exit();
        }

        private void Result_Click(object sender, EventArgs e)
        {
            if (t_Function.Text == "" || t_a.Text == "" || t_b.Text == "" || t_e.Text == "")
            {
                log.Warn("Попытка вычислить результат при наличии незаполненных полей.");
                MessageBox.Show("Заполните все поля.");
                return;
            }
            if (double.Parse(t_a.Text) > double.Parse(t_b.Text)||t_a.ForeColor == Color.Red || t_b.ForeColor == Color.Red || t_e.ForeColor == Color.Red || t_Function.ForeColor == Color.Red)
            {
                    log.Warn("Попытка вычислить результат при наличии ошибочно заполненных полей.");
                    MessageBox.Show("Неправильный ввод!");
                    return;                   

            }

            log.Info("Начало вычислений.");
            Input.Main(t_Function.Text, double.Parse(t_a.Text), double.Parse(t_b.Text), int.Parse(t_e.Text));
            Core.Find_x();
            Result r = new Result();
            Data.progress += 10;
            try
            {
                log.Info("Открытие окна с результатами.");
                Enabled = false;
                Data.progress += 10;
                r.Show();
            }
            catch (Exception)
            {
                log.Error("Произошла ошибка при обработке функции. Введённые данные некорректны.");
                MessageBox.Show("Произошла ошибка при обработке функции. Попробуйте другие данные.");
                throw;
            }
            Enabled = true;
            progressBar1.Value = 0;
            progress = 0;
            Data.progress = 0;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Открытие окна \"О программе\"");
            About a = new About();
            Enabled = false;
            a.ShowDialog();
            Enabled = true;
        }

        private void вToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("Открытие файла.");
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                log.Debug("Пользователь выбрал файл.");
                


                try
                {
                    string textFile = fd.FileName;

                    string[] text = File.ReadAllLines(textFile);


                    bool match1 = Regex.IsMatch(text[0], @"^f\(x\) = \S*$");
                    bool match2 = Regex.IsMatch(text[1], @"^from -?\d+ to -?\d+$");
                    bool match3 = Regex.IsMatch(text[2], @"^epsilon = \d+$");

                    log.Debug("Файл успешно прочитан.");
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
                        log.Info("Данные успешно считаны из файла {0}", textFile);
                    }
                    else
                    {
                        string t = @"Данные в указанном файле имеет неверный формат.";
                        log.Error(t);
                        MessageBox.Show(t);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("При чтении файла произошла ошибка. Информация: {0}", ex);
                }

            }
            else
            {
                string t = @"Произошла ошибка при открытии файла.";
                log.Error(t);
                MessageBox.Show(t);
                throw new FileLoadException();
            }

        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            log.Info("Открытие окна \"Параметры\"");
            Settings s = new Settings();
            Enabled = false;
            s.ShowDialog();
            Enabled = true;
        }

        private void t_a_TextChanged(object sender, EventArgs e)
        {
            log.Info("Текст в поле {0} изменился на {1}", t_a.Name, t_a.Text);
            if (Regex.IsMatch(t_a.Text, @"^([-]?\d+(.\d+)?)$"))
            {
                t_a.ForeColor = Color.Green;
                log.Debug("Данные в поле {0} введены верно.", t_a.Name);
            }
            else
            {
                log.Debug("Данные в поле {0} введены не верно.", t_a.Name);
                t_a.ForeColor = Color.Red;
            }
        }

        private void t_b_TextChanged(object sender, EventArgs e)
        {
            log.Info("Текст в поле {0} изменился на {1}", t_b.Name, t_b.Text);

            if (Regex.IsMatch(t_b.Text, @"^([-]?\d+(.\d+)?)$"))
            {
                t_b.ForeColor = Color.Green;
                log.Debug("Данные в поле {0} введены верно.", t_b.Name);

            }
            else
            {
                t_b.ForeColor = Color.Red;
                log.Debug("Данные в поле {0} введены не верно.", t_b.Name);

            }
        }

        private void t_e_TextChanged(object sender, EventArgs e)
        {
            log.Info("Текст в поле {0} изменился на {1}", t_e.Name, t_e.Text);

            if (Regex.IsMatch(t_e.Text, @"^[-]?\d+$"))
            {
                t_e.ForeColor = Color.Green;
                log.Debug("Данные в поле {0} введены верно.", t_e.Name);

            }
            else
            {
                t_e.ForeColor = Color.Red;
                log.Debug("Данные в поле {0} введены не верно.", t_e.Name);

            }
        }

        private void t_Function_TextChanged(object sender, EventArgs e)
        {
            log.Info("Текст в поле {0} изменился на {1}", t_Function.Name, t_Function.Text);

            try
            {
                FunctionCreator.FunctionCreator.BuildFunc(t_Function.Text);
            }
            catch 
            {
                t_Function.ForeColor = Color.Red;
                log.Debug("Данные в поле {0} введены не верно.", t_Function.Name);

                return;
            }
            t_Function.ForeColor =Color.Green;
            log.Debug("Данные в поле {0} введены верно.", t_Function.Name);

        }

        private void Help_Click(object sender, EventArgs e)
        {
            log.Info("Открытие окна \"Справка\"");
            PT.Help h = new Help();

            this.Enabled = false;
            h.ShowDialog();
            this.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetTooltips();
            Data.mainform = this;
        }

        public void OnChange()
        {
            progressBar1.Value = this.progress;
        }

        public int progress
        {
            get { return p; }
            set
            {
                p = value;
                OnChange();
            }
        }

        private int p;
    }
}
