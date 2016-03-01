using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NLog;
using Word = Microsoft.Office.Interop.Word;

namespace PT
{
    public partial class Result : Form
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public Result()
        {
            log.Info("Инициализация окна результатов.");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Закрытие окна результатов.");
            Close();
        }

        private void Draw()
        {
            log.Debug("Попытка нарисовать график функции.");
            comboBox1.SelectedIndex = 2;

            chart1.ChartAreas.Add(new ChartArea("Default"));

            chart1.Series.Add(new Series("F(x)"));
            chart1.Series["F(x)"].ChartArea = "Default";
            chart1.Series["F(x)"].ChartType = SeriesChartType.Line;


            int n = Convert.ToInt32(Math.Abs(Data.b - Data.a));
            double[] axisXData = new double[n + 1];
            double[] axisYData = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                axisXData[i] = Data.a + i;
                axisYData[i] = Data.f(Data.a + i);
            }

            try
            {
                chart1.Series["F(x)"].Points.DataBindXY(axisXData, axisYData);
            }
            catch (Exception ex)
            {
                log.Error("Ошибка при построении графика. Информация: {0}",ex);
            }
        }

        private void SetTooltips()
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(chart1,"График введённой функции");
            t.SetToolTip(bSaveImage,"Сохранение графика в указанную директорию");
            t.SetToolTip(bSave,"Сохранение результатов в файл");
            t.SetToolTip(button1,"Скрыть окно результатов");
        }

        private void Result_Load(object sender, EventArgs e)
        {
            Draw();
            log.Info("График успешно построен.");


            double _out = Output.Main();
            if (double.IsNaN(_out))
            {
                log.Info("Корень уравнения не принадлежит указанному интервалу, либо не существует.");
                l_x.Text = @"Не принадлежит указанному интервалу, либо не существует.";
                return;
            }
            log.Info("Отображение результата вычислений.");
            l_x.Text = Convert.ToString(_out, CultureInfo.InvariantCulture);
        }

        private void bSaveImage_Click(object sender, EventArgs e)
        {
            log.Info("Сохранение графика.");

            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.DefaultExt = ".jpeg";
                sf.Filter = @"Изображение (*.jpeg)|.jpeg";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string filename = sf.FileName;
                    chart1.SaveImage(filename, ChartImageFormat.Jpeg);
                }
                log.Info("График успешно сохранён в {0}", sf.FileName);
            }
            catch (Exception ex)
            {
                log.Error("Ошибка при сохранении графика. Информация: {0}",ex);
                MessageBox.Show("Ошибка при сохранении графика.");
            }



        }

        private void bSave_Click(object sender, EventArgs e)
        {
            log.Info("Сохранение результатов.");
            string[] text = { "F(x) = " + Data.sFunction, "Корень уравнения - " + l_x.Text };
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    try
                    {
                        SaveFileDialog sf = new SaveFileDialog();
                        sf.Filter = @"Текстовый документ(*.txt)|.txt";

                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            string filename = sf.FileName;

                            File.WriteAllLines(filename, text, Encoding.Unicode);
                            log.Info("Результаты успешно записаны в файл {0}", filename);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("Ошибка при записи в файл. Информация: {0}", ex);
                        MessageBox.Show("Ошибка при записи в файл.");
                        throw ex;

                    }
                    break;
                case 1:
                    try
                    {
                        Object template = Type.Missing;
                        Object newTemplate = false;
                        Object visible = false;

                        Object docType = Word.WdNewDocumentType.wdNewBlankDocument;

                        Word.Application application = new Word.Application();
                        Word.Document document = new Word.Document();

                        application.Documents.Add(ref template, ref newTemplate, ref docType, ref visible);

                        Word.Paragraphs wParagraphs = document.Paragraphs;
                        Word.Paragraph wParagraph;

                        Object begin = Type.Missing;
                        Object end = Type.Missing;
                        Word.Range wRange = document.Range(ref begin, ref end);
                        wRange.Select();

                        wRange.Font.Size = 14;
                        wRange.Font.Color = Word.WdColor.wdColorDarkBlue;
                        wRange.Text = text[0] + "\n" + text[1];

                        document.Save();
                        log.Info("Результаты успешно сохранены в файл.");
                    }
                    catch (Exception exception)
                    {
                        log.Error("Ошибка при записи в файл. Информация: {0}",exception);
                        MessageBox.Show("Ошибка при записи в файл.");
                    }

                    break;
                case 2:
                    try
                    {
                        Object _template = Type.Missing;
                        Object _newTemplate = false;
                        Object _visible = false;

                        Object _docType = Word.WdNewDocumentType.wdNewBlankDocument;

                        Word.Application _application = new Word.Application();
                        Word.Document _document = new Word.Document();

                        _application.Documents.Add(ref _template, ref _newTemplate, ref _docType, ref _visible);

                        Word.Paragraphs _wParagraphs = _document.Paragraphs;
                        Word.Paragraph _wParagraph;

                        Object _begin = Type.Missing;
                        Object _end = Type.Missing;
                        Word.Range _wRange = _document.Range(ref _begin, ref _end);
                        _wRange.Select();



                        using (MemoryStream ms = new MemoryStream())
                        {
                            chart1.SaveImage(ms, ChartImageFormat.Bmp);
                            Bitmap bm = new Bitmap(ms);
                            Clipboard.SetImage(bm);
                        }

                        _wRange.Paste();

                        _wRange = _document.Range(1, ref _end);
                        _wRange.Select();

                        _wRange.Font.Size = 14;
                        _wRange.Font.Color = Word.WdColor.wdColorDarkBlue;
                        _wRange.Text = "\n" + text[0] + "\n" + text[1];

                        _document.Save();
                        log.Info("Результаты успешно сохранены в файл.");
                    }
                    catch (Exception exception)
                    {
                        log.Error("Ошибка при записи в файл. Информация: {0}",exception);
                        MessageBox.Show("Ошибка при записи в файл.");
                    }

                    break;
            }

        }
    }
}
