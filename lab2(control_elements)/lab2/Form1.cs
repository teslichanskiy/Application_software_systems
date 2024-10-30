using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();
        }

        private void InitializeMyComponents()
        {
          
            // Настройка элементов управления
            this.Text = "Личная информация";
            ToolTip toolTip1 = new ToolTip();

            // Label для имени
            Label label1 = new Label { Text = "Введите Ваше имя:", AutoSize = true };
            label1.Location = new System.Drawing.Point(10, 10);
            this.Controls.Add(label1);

            // TextBox для ввода имени
            TextBox textBox1 = new TextBox { Location = new System.Drawing.Point(200, 10),  Width = 200 };
            this.Controls.Add(textBox1);

            // Button для подтверждения
            Button button1 = new Button { Text = "Подтвердить", Location = new System.Drawing.Point(200, 40), Height = 40, Width = 200 };
            button1.Click += (sender, e) =>
            {
                MessageBox.Show($"Здравствуйте, {textBox1.Text}!");
            };
            this.Controls.Add(button1);

            // GroupBox для пола
            GroupBox groupBox1 = new GroupBox { Text = "Пол", Location = new System.Drawing.Point(10, 80), Size = new System.Drawing.Size(200, 100) };
            RadioButton radioButton1 = new RadioButton { Text = "Мужчина", Location = new System.Drawing.Point(10, 20) };
            RadioButton radioButton2 = new RadioButton { Text = "Женщина", Location = new System.Drawing.Point(10, 40), Width = 150 };
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            this.Controls.Add(groupBox1);

            // ComboBox для возраста
            Label label2 = new Label { Text = "Выберите Ваш возраст:", Location = new System.Drawing.Point(10, 190), AutoSize = true };
            this.Controls.Add(label2);
            ComboBox comboBox1 = new ComboBox { Location = new System.Drawing.Point(250, 190) };
            comboBox1.Items.AddRange(new string[] { "18-25", "26-35", "36-45", "46+" });
            this.Controls.Add(comboBox1);

            // CheckBox для интересов
            Label label3 = new Label { Text = "Выберите ваше хобби:", Location = new System.Drawing.Point(10, 220), AutoSize = true };
            this.Controls.Add(label3);
            CheckBox checkBox1 = new CheckBox { Text = "Спорт", Location = new System.Drawing.Point(10, 250) };
            this.Controls.Add(checkBox1);
            CheckBox checkBox2 = new CheckBox { Text = "Музыка", Location = new System.Drawing.Point(10, 280) };
            this.Controls.Add(checkBox2);
            CheckBox checkBox3 = new CheckBox { Text = "Рисование", Location = new System.Drawing.Point(10, 310), Width = 200};
            this.Controls.Add(checkBox3);
            CheckBox checkBox4 = new CheckBox { Text = "Игры", Location = new System.Drawing.Point(10, 340) };
            this.Controls.Add(checkBox4);


            // NumericUpDown для задания количества хобби
            Label label4 = new Label { Text = "Сколько у Вас интересов:", Location = new System.Drawing.Point(10, 370), AutoSize = true };
            this.Controls.Add(label4);
            NumericUpDown numericUpDown1 = new NumericUpDown { Location = new System.Drawing.Point(250, 370), Minimum = 1, Maximum = 10 };
            this.Controls.Add(numericUpDown1);

            // ListBox для отображения интересов
            ListBox listBox1 = new ListBox { Location = new System.Drawing.Point(10, 460), Width = 200, Height = 50 };
            this.Controls.Add(listBox1);
            checkBox1.CheckedChanged += (sender, e) =>
            {
                if (checkBox1.Checked)
                {
                    listBox1.Items.Add(checkBox1.Text);
                }
                else
                {
                    listBox1.Items.Remove(checkBox1.Text);
                }
            };
            checkBox2.CheckedChanged += (sender, e) =>
            {
                if (checkBox2.Checked)
                {
                    listBox1.Items.Add(checkBox2.Text);
                }
                else
                {
                    listBox1.Items.Remove(checkBox2.Text);
                }
            };
            checkBox3.CheckedChanged += (sender, e) =>
            {
                if (checkBox3.Checked)
                {
                    listBox1.Items.Add(checkBox3.Text);
                }
                else
                {
                    listBox1.Items.Remove(checkBox3.Text);
                }
            };
            checkBox4.CheckedChanged += (sender, e) =>
            {
                if (checkBox4.Checked)
                {
                    listBox1.Items.Add(checkBox4.Text);
                }
                else
                {
                    listBox1.Items.Remove(checkBox4.Text);
                }
            };
            

            // Создание VScrollBar для ListBox
            VScrollBar vScrollBarListBox = new VScrollBar
            {
                Location = new System.Drawing.Point(220, 430), // расположение скроллбара
                Height = 80, // высота скроллбара
                Maximum = 80, // максимальное значение
                SmallChange = 10,
                LargeChange = 20
            };
            vScrollBarListBox.Scroll += (sender, e) =>
            {
                int offset = -vScrollBarListBox.Value; // обратное значение для смещения
                listBox1.Top = 460 + offset; // перемещение спискового элемента
            };
            this.Controls.Add(vScrollBarListBox);

           

            // TrackBar для выбора уровня счастья
            Label label5 = new Label { Text = "Насколько Вы довольны своей жизнью:", Location = new System.Drawing.Point(10, 550), AutoSize = true };
            this.Controls.Add(label5);
            TrackBar trackBar1 = new TrackBar { Location = new System.Drawing.Point(10, 580), Maximum = 100, Minimum = 0, Width = 200 };
            this.Controls.Add(trackBar1);

            // ToolTip для подсказок
            toolTip1.SetToolTip(textBox1, "Введите Ваше имя");
            toolTip1.SetToolTip(button1, "Нажмите, чтобы отправить данные");
            toolTip1.SetToolTip(comboBox1, "Выберите возрастную категорию");

            // Масштабирование шрифт 
            float fontScale = 1.5F;
            foreach (Control control in this.Controls)
            {
                control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size * fontScale);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
