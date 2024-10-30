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
    public partial class Form2 : Form // Объявление класса Form2, который наследуется от Form
    {
        double V = 0;
        double S = 0;
        public Form2(double CircleV, double CircleS) // Конструктор класса Form2 с двумя параметрами
        {
            InitializeComponent(); // Инициализация компонентов формы
            V = CircleV; //  Присвоение переданного значения CircleV переменной V
            S = CircleS; //  Присвоение переданного значения CircleS переменной S
        }

        private void Form2_Load(object sender, EventArgs e) // Обработчик события загрузки формы
        {
            textBox1.Text = Convert.ToString(Convert.ToInt32(V)); // Установка значения текстового поля textBox1 равным переменной V
            textBox2.Text = Convert.ToString(Convert.ToInt32(S)); // Установка значения текстового поля textBox2 равным переменной S
        }

        private void label1_Click(object sender, EventArgs e) // Обработчик клика по label1 (пустой)
        { }

        private void button1_Click(object sender, EventArgs e) // Обработчик клика по button1
        {
            this.Close(); // Закрытие текущей формы
        }
    }
}
