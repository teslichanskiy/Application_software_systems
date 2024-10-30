using System;
using System.Threading;
using System.Windows.Forms;


namespace lab8
{
    public partial class MainForm : Form
    {
        private KeyHandlerChain chain;

        public MainForm()
        {
            InitializeComponent();
            chain = new KeyHandlerChain();
            chain.AddHandler(new LetterHandler());
            chain.AddHandler(new DigitHandler());
            chain.AddHandler(new DefaultHandler());

            textBox1.KeyPress += TextBox1_KeyPress;

            Button finishButton = new Button { Text = "Завершить ввод", Location = new System.Drawing.Point(170, 100), Width = 150 };
            finishButton.Click += FinishInputButton_Click;
            this.Controls.Add(finishButton);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Передаем нажатую клавишу в цепочку обработчиков
            chain.Handle(e.KeyChar);
        }

        private void FinishInputButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ввод завершен.");
            Thread.Sleep(500);

            // Завершение программы
            Application.Exit();
        }
    }


    // Базовый класс обработчика
    abstract class KeyHandler
    {
        public KeyHandler nextHandler;

        public void SetNext(KeyHandler next)
        {
            nextHandler = next;
        }

        public abstract void Handle(char keyChar);
    }

    // Обработчик для букв
    class LetterHandler : KeyHandler
    {
        public override void Handle(char keyChar)
        {
            if (char.IsLetter(keyChar))
            {
                MessageBox.Show($"Обработка буквы: {keyChar}");
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(keyChar);
            }
        }
    }

    // Обработчик для цифр
    class DigitHandler : KeyHandler
    {
        public override void Handle(char keyChar)
        {
            if (char.IsDigit(keyChar))
            {
                MessageBox.Show($"Обработка цифры: {keyChar}");
            }
            else if (nextHandler != null)
            {
                nextHandler.Handle(keyChar);
            }
        }
    }

    // Обработчик по умолчанию
    class DefaultHandler : KeyHandler
    {
        public override void Handle(char keyChar)
        {
            MessageBox.Show($"Неизвестный символ: {keyChar}");
        }
    }

    // Класс цепочки обработчиков
    class KeyHandlerChain
    {
        private KeyHandler firstHandler;

        public void AddHandler(KeyHandler handler)
        {
            if (firstHandler == null)
            {
                firstHandler = handler;
            }
            else
            {
                KeyHandler currentHandler = firstHandler;
                while (currentHandler.nextHandler != null)
                {
                    currentHandler = currentHandler.nextHandler;
                }
                currentHandler.SetNext(handler);
            }
        }

        public void Handle(char keyChar)
        {
            if (firstHandler != null)
            {
                firstHandler.Handle(keyChar);
            }
        }
    }
}