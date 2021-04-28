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
        int[] x;
        int[] y;
        int n;
        TextBox[] X = new TextBox[7];  //массив ячеек x(i)
        TextBox[] F = new TextBox[7];  //массив ячеек f(i)
        double step = 1;

        //создание массива с данными из текстбокса
        private double[] array(TextBox[] box, int n)
        {
            double[] x = new double[n];
            double[] f = new double[n];

            //заполняем массив x, f из таблицы
            for (int i = 0; i < n; i++)
            {
                x[i] = new double();
                x[i] = double.Parse(box[i].Text);
            }
            return x;
        }

        //cтирает данные
        private void cleaning(int n)
        {
            for (int i = 0; i < n; i++)
            {
                X[i].Clear();
                F[i].Clear();
            }
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            textBox16.Clear();
        }

        //проверка, что не все х=0, k!=0 
        private bool check(TextBox[] box, int n)
        {
            int fl = 0;
            for (int i = 0; i < n; i++)
                if (double.Parse(box[i].Text) == 0)
                    fl++;
            if (fl == n)
            {
                MessageBox.Show("Невозможно построить график. Введите другие значения х.");
                return false;
            }
            else
                return true;
        }

        //кнопка ввести
        //пользователь вводит размер таблицы, делает лишние ячейки(максимум ячеек установим 7) невидимыми
        private void button1_Click(object sender, EventArgs e)
        {
            //cleaning(n);
            n = int.Parse(textBox5.Text);
            if ((int.Parse(textBox5.Text) < 1) || (int.Parse(textBox5.Text) > 7))
            {
                MessageBox.Show("Невозможно построить график. Введите n от 1 до 7.");
                return;
            }
            X[0] = textBox2;
            X[1] = textBox3;
            X[2] = textBox4;
            X[3] = textBox6;
            X[4] = textBox7;
            X[5] = textBox8;
            X[6] = textBox9;

            F[0] = textBox1;
            F[1] = textBox15;
            F[2] = textBox14;
            F[3] = textBox13;
            F[4] = textBox12;
            F[5] = textBox11;
            F[6] = textBox10;

            for (int i = 0; i < 7; i++) //убираем лишние ячейки
            {
                if (i < n)
                {
                    X[i].Visible = true;
                    F[i].Visible = true;
                }
                else
                {
                    X[i].Visible = false;
                    F[i].Visible = false;
                }
                X[i].Clear();
                F[i].Clear();
            }
            button1.Hide();
            label1.Hide();
            textBox5.Hide();
        }

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
        private void graph(double xMin, double xMax, double step, double[] x, double[] y, double[] pX, double[] pF)
        {
            chart1.Series[2].Points.Clear();

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
            if (!checkTable())
            {
                cleaning(n);
                return;
            }
            else
                 if (int.Parse(textBox16.Text) == 0)
            {
                MessageBox.Show("Невозможно построить график. Степень многочлена не должна равняться 0.");
                cleaning(n);
                return;
            }

            //заполняем массивы из текстбоксов
            double[] x = array(X, n);
            double[] f = array(F, n);

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
            graph(xMin, xMax, step, abs, ord, x, f);
        }

        //точное решение
        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkTable())
                return;

            //заполняем массивы из текстбоксов
            double[] x = array(X, n);
            double[] f = array(F, n);

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

        private bool checkTable()
        {
            int fl1 = 0;
            //проверка на пустоту
            for (int i = 0; i < n; i++)
                if (empty(X[i]) || empty(F[i]))
                {
                    MessageBox.Show("Заполните таблицу.");
                    return false;
                }
            if (empty(xMin) || empty(xMax) || empty(yMin) || empty(yMax))
            {
                MessageBox.Show("Укажите масштаб.");
                return false;
            }

            //проверяем, что не все х=0
            for (int i = 0; i < n; i++)
                if (double.Parse(X[i].Text) == 0)
                    fl1++;
            if (fl1 == n)
            {
                MessageBox.Show("Невозможно построить график. Введите другие значения х.");
                cleaning(n);
                return false;
            }

            //проверка, чтобы пользователь вводил различные точки
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if ((double.Parse(X[i].Text) == double.Parse(X[j].Text)) && (double.Parse(F[i].Text) == double.Parse(F[j].Text)))
                    {
                        MessageBox.Show("Невозможно построить график. Введите различные точки.");
                        cleaning(n);
                        return false;
                    }

            //проверка масштаба
            if ((double.Parse(xMin.Text) >= double.Parse(xMax.Text)) || (double.Parse(yMin.Text) >= double.Parse(yMax.Text)))
            {
                MessageBox.Show("Невозможно построить график. Введите корректный масштаб.");
                cleaning(n);
                return false;
            }
            return true;
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

        void ParsePointsFromList(IList<string> stringlist)
        {
            for (int i = 0; i < stringlist.Count; i++) 
            {
                //x[i] = int.Parse(stringlist[i]);
                y[i] = int.Parse(stringlist[i].Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            ParsePointsFromList(File.ReadAllLines(path, Encoding.GetEncoding("windows-1251")));
            for(int i = 0;i<y.Length;i++)
            {
                MessageBox.Show(Convert.ToString(y[i]));
            }
        }
    }
}
