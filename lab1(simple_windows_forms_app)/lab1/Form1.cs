using lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab1
{
    public partial class Form1 : Form // Объявление частичного класса
                                      // MainForm, наследующего функциональность класса Form
    {
        double V, S;
        public Form1() // конструктор класса Form
        {
            InitializeComponent(); // Вызываем метод инициализации компонентов формы
        }
        Form2 form2;
        private void Form1_Load(object sender, EventArgs e) // Определяем метод инициализации компонентов формы
        { }

        public class Compute //Определение внутреннего класса, который 
                               //содержит методы для расчета объема и площади поверхности 
        {
            public double CalculatingV(double a, double b, double c) // метод вычисляет объем
            {
                return a * b * c;
            }

            public double CalculatingS(double a, double b, double c) // метод вычисляет площадь
            {
                return 2 * a * b + 2 * a * c + 2 * b * c;
            }
        }
        private void label1_Click(object sender, EventArgs e) { } // заголовки
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { } 
        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        private void textBox3_TextChanged(object sender, EventArgs e)
        { }
        private void button1_Click(object sender, EventArgs e) // соответствуют событию клика по кнопкам на форме.
                                                               // Методы вызываются, когда пользователь нажимает на кнопки соответственно
        {
            double number1, number2, number3;
            if (double.TryParse(textBox1.Text, out number1) && double.TryParse(textBox1.Text, out number2) && double.TryParse(textBox1.Text, out number3)) // пробуем получить значения, если они не числа - 
            { // вызывается исключение (возвращаем ошибку)
                try
                {
                    Compute calc = new Compute();
                    V = calc.CalculatingV(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    textBox4.Text = Convert.ToString(V);
                    if (Convert.ToDouble(textBox1.Text) < 0 || Convert.ToDouble(textBox2.Text) < 0 || Convert.ToDouble(textBox3.Text) < 0)
                    {
                        throw new ArgumentOutOfRangeException("Invalid argument value");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Invalid argument value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            { // исключение
                MessageBox.Show("Wrong type of Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double number1, number2, number3;
            if (double.TryParse(textBox1.Text, out number1) && double.TryParse(textBox1.Text, out number2) && double.TryParse(textBox1.Text, out number3)) // пробуем получить значения, если они не числа - 
            { // вызывается исключение (возвращаем ошибку)
                try
                {
                    Compute calc = new Compute();
                    S = calc.CalculatingS(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    textBox5.Text = Convert.ToString(S);
                    if (Convert.ToDouble(textBox1.Text) < 0 || Convert.ToDouble(textBox2.Text) < 0 || Convert.ToDouble(textBox3.Text) < 0)
                    {
                        throw new ArgumentOutOfRangeException("Invalid argument value");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Invalid argument value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Wrong type of Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) // При нажатии на button3, программа создает новый экземпляр формы Form2 
        { // и передает в нее расчетные значения объема и площади для дальнейшего отображения.
            form2 = new Form2(V, S);
            form2.Show(); // показ формы
        }
    }
}

