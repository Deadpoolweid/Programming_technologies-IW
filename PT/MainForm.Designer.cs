using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PT
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new MenuStrip();
            this.файлToolStripMenuItem = new ToolStripMenuItem();
            this.вToolStripMenuItem = new ToolStripMenuItem();
            this.выходToolStripMenuItem = new ToolStripMenuItem();
            this.bSettings = new ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            this.tFunction = new TextBox();
            this.t_a = new TextBox();
            this.t_b = new TextBox();
            this.t_e = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.Result = new Button();
            this.progressBar1 = new ProgressBar();
            this.panel1 = new Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.bSettings,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(317, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.вToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // вToolStripMenuItem
            // 
            this.вToolStripMenuItem.Name = "вToolStripMenuItem";
            this.вToolStripMenuItem.Size = new Size(153, 22);
            this.вToolStripMenuItem.Text = "Открыть файл";
            this.вToolStripMenuItem.Click += new EventHandler(this.вToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new Size(153, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // bSettings
            // 
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new Size(83, 20);
            this.bSettings.Text = "Параметры";
            this.bSettings.Click += new EventHandler(this.bSettings_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // tFunction
            // 
            this.tFunction.Location = new Point(63, 16);
            this.tFunction.Name = "tFunction";
            this.tFunction.Size = new Size(218, 20);
            this.tFunction.TabIndex = 1;
            // 
            // t_a
            // 
            this.t_a.Location = new Point(113, 49);
            this.t_a.Name = "t_a";
            this.t_a.Size = new Size(69, 20);
            this.t_a.TabIndex = 2;
            // 
            // t_b
            // 
            this.t_b.Location = new Point(213, 49);
            this.t_b.Name = "t_b";
            this.t_b.Size = new Size(68, 20);
            this.t_b.TabIndex = 3;
            // 
            // t_e
            // 
            this.t_e.Location = new Point(113, 94);
            this.t_e.Name = "t_e";
            this.t_e.Size = new Size(69, 20);
            this.t_e.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "f(x) =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Интервал от";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(188, 52);
            this.label3.Name = "label3";
            this.label3.Size = new Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(18, 94);
            this.label4.Name = "label4";
            this.label4.Size = new Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Погрешность";
            // 
            // Result
            // 
            this.Result.Location = new Point(89, 145);
            this.Result.Name = "Result";
            this.Result.Size = new Size(124, 23);
            this.Result.TabIndex = 9;
            this.Result.Text = "Вычислить корень";
            this.Result.UseVisualStyleBackColor = true;
            this.Result.Click += new EventHandler(this.Result_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new Point(63, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(198, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tFunction);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.t_a);
            this.panel1.Controls.Add(this.Result);
            this.panel1.Controls.Add(this.t_b);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.t_e);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(317, 243);
            this.panel1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(317, 267);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Решение нелинейных уравнений";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private TextBox tFunction;
        private TextBox t_a;
        private TextBox t_b;
        private TextBox t_e;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Result;
        private ToolStripMenuItem вToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem bSettings;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ProgressBar progressBar1;
        private Panel panel1;
    }
}

