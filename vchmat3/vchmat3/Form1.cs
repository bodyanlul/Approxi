using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;


namespace vchmat3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Add("Точки");
            chart1.Series.Add("Точное решение");
        }
   

        int n;
        string path;
       
        
        double step = 1;

        //создание массива с данными из текстбокса
       

        private double[] ArrayX(IList<string> stringlist)
        {
            int n = 0;
            for (int i = 0; i < stringlist.Count; i++)
                n++;

            double[] x = new double[n];

            //заполняем массив x, f из таблицы
            for (int i = 0; i < stringlist.Count; i++)
            {
                var array = stringlist[i].Split(';');
                x[i] = new double();
                x[i] = double.Parse(array[0]);
                
            }
            textBox5.Text = Convert.ToString(n);
            return x;
        }

        private double[] ArrayY(IList<string> stringlist) //добавить исключение
        {
            int n = 0;
            for (int i = 0; i < stringlist.Count; i++)
                n++;
            double[] x = new double[n];

            //заполняем массив x, f из таблицы
            for (int i = 0; i < stringlist.Count; i++)
            {
                var array = stringlist[i].Split(';');
                x[i] = new double();
                try
                {
                    x[i] = double.Parse(array[1]);
                }
                catch(FormatException e)
                {
                    MessageBox.Show("Неверно введены данные", "Ошибка");
                }
            }
            return x;
        }

        //пользователь вводит размер таблицы, делает лишние ячейки(максимум ячеек установим 7) невидимыми
    

        //метод Гаусса без выбора главного элемента
        private double[] gauss(double[,] matrix, double[] y, int n)
        {
            double[] x;
            x = new double[n];

            // переставим строки так, чтобы диагоналные элементы были не 0
            for (int ind = 0; ind < n; ind++)
            {
                int numb = ind;
                for (int i = 1; i < n; i++)
                    if (matrix[i, ind] != 0)
                        numb = i;

                //перестановка строк,ставим на позицию ind строку, в которой ind элемент max
                if (numb != ind)
                {
                    //идем по строке
                    for (int i = 0; i < n; i++)
                    {
                        double tempp = matrix[ind, i];
                        matrix[ind, i] = matrix[numb, i];
                        matrix[numb, i] = tempp;
                    }

                    double temp = y[ind];
                    y[ind] = y[numb];
                    y[numb] = temp;
                }
            }

            //идем по переменным
            for (int ind = 0; ind < n; ind++)
            {
                //приведем расширенную матрицу к ступенчатому виду
                //идем по строкам,начиная со следующей после выбранной
                for (int i = ind + 1; i < n; i++)
                {
                    double mult = -matrix[i, ind] / matrix[ind, ind];
                    if (matrix[i, ind] != 0)
                    {
                        for (int j = ind; j < n; j++)
                            matrix[i, j] += matrix[ind, j] * mult;
                    }
                    else
                        continue;
                    y[i] += y[ind] * mult;
                }
            }

            //обратная подстановка
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = y[i] / matrix[i, i];
                for (int j = 0; j < i; j++)
                    y[j] = y[j] - matrix[j, i] * x[i];
            }

            return x;
        }

    
        //построение графика, настраиваются оси
        private void graph(double xMin, double xMax, double step, double[] x, double[] y, double[] pX, double[] pF,double yMin,double yMax)
        {
            chart1.Series[1].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = xMin;
            chart1.ChartAreas[0].AxisX.Maximum = xMax;
            chart1.ChartAreas[0].AxisY.Minimum = yMin;
            chart1.ChartAreas[0].AxisY.Maximum = yMax;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = step;
            chart1.Series[0].Color = Color.FromArgb(0, 0, 0);
            chart1.Series[1].Color = Color.FromArgb(255, 0, 0);
            chart1.Series[0].Points.DataBindXY(x, y);

            chart1.Series[1].BorderWidth = 2;
            for (int i = 0; i < int.Parse(textBox5.Text); i++)
            {
                chart1.Series[1].ChartType = SeriesChartType.Point;
                chart1.Series[1]["PixelPointWidth"] = "10";
                chart1.Series[1].Points.AddXY(pX[i], pF[i]);
            }

        }

        private void Graph(double xMin, double xMax, double step, double[] x, double[] y)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = step;
            chart1.Series[2].ChartType = SeriesChartType.Spline;
            chart1.Series[2].Color = Color.FromArgb(255, 0, 0);
            chart1.Series[2].Points.DataBindXY(x, y);
        }
        private void SetSize()
        {
            chart1.ChartAreas[0].AxisX.Minimum = double.Parse(xMin.Text);
            chart1.ChartAreas[0].AxisX.Maximum = double.Parse(xMax.Text);
            chart1.ChartAreas[0].AxisY.Minimum = double.Parse(yMin.Text);
            chart1.ChartAreas[0].AxisY.Maximum = double.Parse(yMax.Text);
        }

        //метод наименших квадратов
        private void button2_Click(object sender, EventArgs e)
        {
            double yMin, yMax;
            path = GetPath();
            double[] x = ArrayX(File.ReadAllLines(path, Encoding.GetEncoding("windows-1251")));
            double[] f = ArrayY(File.ReadAllLines(path, Encoding.GetEncoding("windows-1251")));
            n = int.Parse(textBox5.Text);
            yMin = f.Min()*2;
            yMax = f.Max()*2;

            int k = int.Parse(textBox16.Text); //степень многочлена
            double[] a = new double[k + 1];
            double[,] c = new double[k + 1, k + 1];
            double[] d = new double[k + 1];

            int m = 2 * k;
            double sum;
            double[] C = new double[m + 1];

            if (k == 0)
            {
                MessageBox.Show("Невозможно построить график. Степень многочлена не должна равняться 0.");
                return;
            }

            //считаем с
            for (int i = 0; i <= m; i++)
            {
                C[i] = new double();
                sum = 0;
                for (int j = 0; j < n; j++)
                    sum += Math.Pow(x[j], i);
                C[i] = sum;
            }

            //записываем двумерный массив с для решения СЛАУ, 
            int temp;
            for (int i = 0; i < k + 1; i++)
            {
                temp = i;
                for (int j = 0; j < k + 1; j++)
                {
                    c[i, j] = new double();
                    c[i, j] = C[temp];
                    temp++;
                }
            }

            //считаем d и заполняем массив
            for (int i = 0; i < k + 1; i++)
            {
                sum = 0;
                d[i] = new double();
                for (int j = 0; j < n; j++)
                    sum += f[j] * Math.Pow(x[j], i);
                d[i] = sum;
            }

            //решим СЛАУ методом Гаусса и получим коэф. аппроксимирующего многочлена
            a = gauss(c, d, k + 1);

            //строим график
            double xMin = x[0] * 5;
            double xMax = x[n - 1] * 5;

            int count = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            double[] abs = new double[count];
            double[] ord = new double[count];

            for (int i = 0; i < count; i++)
            {
                abs[i] = xMin + step * i;
                for (int j = 0; j <= k; j++)
                    ord[i] += Math.Pow(abs[i], j) * a[j];
            }
            xMax = x.Max();
            xMin = x.Min();
            graph(xMin, xMax, step, abs, ord, x, f,yMin,yMax);
        }

        //точное решение
        private void button3_Click(object sender, EventArgs e)
        {
            //заполняем массивы из текстбоксов
            path = GetPath();
            double[] x = ArrayX(File.ReadAllLines(path, Encoding.GetEncoding("windows-1251")));
            double[] f = ArrayY(File.ReadAllLines(path, Encoding.GetEncoding("windows-1251")));
            n = int.Parse(textBox5.Text);

            //строим график
            double xMin = x[0] * 5;
            double xMax = x[n - 1] * 5;

            int count = (int)Math.Ceiling((xMax - xMin) / step) + 1;
            double[] abs = new double[count];
            double[] ord = new double[count];

            double L;
            double num, den; //числитель и знаменатель для вычисления многочлена в форме Лагранжа
            for (int i = 0; i < count; i++)
            {
                abs[i] = xMin + step * i;
                L = 0;
                for (int j = 0; j < n; j++)
                {
                    num = 1;
                    den = 1;
                    for (int ii = 0; ii < n; ii++)
                    {
                        if (ii != j)
                        {
                            num *= abs[i] - x[ii];
                            den *= x[j] - x[ii];
                        }
                        else
                            continue;
                    }
                    L += f[j] * num / den;
                }
                ord[i] = L;
            }
            Graph(xMin, xMax, step, abs, ord);
        }

        private bool empty(TextBox box)
        {
            if (box.Text == "")
                return true;
            else
                return false;
        }

    

        private void button5_Click(object sender, EventArgs e)
        {
            SetSize();
        }

        public string GetPath() //получаем расположение выбранного теста
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Выбор точек";
            dialog.Filter = "txt files (*txt)|*.txt";
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
}

