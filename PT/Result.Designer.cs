using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PT
{
    partial class Result
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result));
            this.button1 = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_x = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSaveImage = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(46, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(149, 377);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Корень уравнения - ";
            // 
            // l_x
            // 
            this.l_x.AutoSize = true;
            this.l_x.Location = new System.Drawing.Point(127, 310);
            this.l_x.Name = "l_x";
            this.l_x.Size = new System.Drawing.Size(12, 13);
            this.l_x.TabIndex = 3;
            this.l_x.Text = "x";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bSaveImage);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.l_x);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 440);
            this.panel1.TabIndex = 4;
            // 
            // bSaveImage
            // 
            this.bSaveImage.Location = new System.Drawing.Point(252, 377);
            this.bSaveImage.Name = "bSaveImage";
            this.bSaveImage.Size = new System.Drawing.Size(131, 23);
            this.bSaveImage.TabIndex = 5;
            this.bSaveImage.Text = "Сохранить график";
            this.bSaveImage.UseVisualStyleBackColor = true;
            this.bSaveImage.Click += new System.EventHandler(this.bSaveImage_Click);
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart1.Size = new System.Drawing.Size(421, 286);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 440);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Result";
            this.Text = "Результат";
            this.Load += new System.EventHandler(this.Result_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button bSave;
        private Label label1;
        private Label l_x;
        private Panel panel1;
        private Chart chart1;
        private Button bSaveImage;
    }
}