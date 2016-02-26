using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            Close();
        }

        private void Result_Load(object sender, EventArgs e)
        {

            chart1.ChartAreas.Add(new ChartArea("Default"));

            chart1.Series.Add(new Series("F(x)"));
            chart1.Series["F(x)"].ChartArea = "Default";
            chart1.Series["F(x)"].ChartType = SeriesChartType.Line;


            int n = Convert.ToInt32(Math.Abs(Data.b - Data.a));
            double[] axisXData = new double[n+1];
            double[] axisYData = new double[n+1];
            for (int i = 0; i <= n; i++)
            {
                axisXData[i] = Data.a + i;
                axisYData[i] = Data.f(Data.a + i);
            }

            chart1.Series["F(x)"].Points.DataBindXY(axisXData, axisYData);



            double _out = Output.Main();
            if (double.IsNaN(_out))
            {
                l_x.Text = @"Не принадлежит указанному иннтервалу, либо не существует.";
                return;
            }
            l_x.Text = Convert.ToString(_out, CultureInfo.InvariantCulture);
        }

        private void bSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".jpeg";
            sf.Filter = @"Изображение (*.jpeg)|.jpeg";
            
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string filename = sf.FileName;
                chart1.SaveImage(filename,ChartImageFormat.Jpeg);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = @"Текстовый документ(*.txt)|.txt|Докумет MS Word(*.doc)|.doc";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string filename = sf.FileName;
                string[] text = {"F(x) = " + Data.sFunction,"Корень уравнения - " + l_x.Text};
                if (sf.FilterIndex == 0)
                {
                    File.WriteAllLines(filename, text, Encoding.Unicode);
                }
                else
                {
                    
                }
            }
        }
    }
}
