using System;

namespace vchmat3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.xMax = new System.Windows.Forms.TextBox();
            this.xMin = new System.Windows.Forms.TextBox();
            this.yMax = new System.Windows.Forms.TextBox();
            this.yMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1473, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ввести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 13);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.LabelForeColor = System.Drawing.Color.BlanchedAlmond;
            series1.Legend = "Legend1";
            series1.LegendText = "y(x)";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1421, 996);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1473, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(75, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1470, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите количество аргументов i:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1473, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Метод\r\nнаименьших квадратов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1613, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 36);
            this.button3.TabIndex = 29;
            this.button3.Text = "Точное решение";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(1593, 301);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(40, 20);
            this.textBox16.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(1472, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "Степень многочлена:";
            // 
            // xMax
            // 
            this.xMax.Location = new System.Drawing.Point(1503, 236);
            this.xMax.Name = "xMax";
            this.xMax.Size = new System.Drawing.Size(49, 20);
            this.xMax.TabIndex = 34;
            // 
            // xMin
            // 
            this.xMin.Location = new System.Drawing.Point(1503, 262);
            this.xMin.Name = "xMin";
            this.xMin.Size = new System.Drawing.Size(49, 20);
            this.xMin.TabIndex = 35;
            // 
            // yMax
            // 
            this.yMax.Location = new System.Drawing.Point(1558, 236);
            this.yMax.Name = "yMax";
            this.yMax.Size = new System.Drawing.Size(49, 20);
            this.yMax.TabIndex = 36;
            // 
            // yMin
            // 
            this.yMin.Location = new System.Drawing.Point(1558, 262);
            this.yMin.Name = "yMin";
            this.yMin.Size = new System.Drawing.Size(49, 20);
            this.yMin.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1517, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1575, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1471, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1471, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "min";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1626, 236);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 46);
            this.button5.TabIndex = 42;
            this.button5.Text = "Задать размеры оси";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1472, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Настройки масштаба:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1904, 1021);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yMin);
            this.Controls.Add(this.yMax);
            this.Controls.Add(this.xMin);
            this.Controls.Add(this.xMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аппроксиматор";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox xMax;
        private System.Windows.Forms.TextBox xMin;
        private System.Windows.Forms.TextBox yMax;
        private System.Windows.Forms.TextBox yMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

