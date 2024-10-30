using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;

namespace lab4_5
{
    public partial class Form1 : Form
    {
        private IPurchaseFactory purchaseFactory;
        private PurchaseManager purchaseManager;

        private Label label1, label2, totalCostLabel;
        private TextBox nameTextBox;
        private TextBox priceTextBox;
        private ListBox purchaseListBox;
        private Button button1;

        public Form1()
        {
            InitializeComponent();

            // Создайте TextBox и ListBox
            nameTextBox = new TextBox { Location = new System.Drawing.Point(10, 40), Width = 200 };
            this.Controls.Add(nameTextBox);

            priceTextBox = new TextBox { Location = new System.Drawing.Point(10, 100), Width = 200 };
            this.Controls.Add(priceTextBox);

            purchaseListBox = new ListBox { Location = new System.Drawing.Point(300, 40), Width = 300, Height = 400 };
            this.Controls.Add(purchaseListBox);

            // Создайте кнопку button1
            button1 = new Button { Text = "Добавить в список ", Location = new System.Drawing.Point(30, 150), Height = 40, Width = 250 };
            button1.Click += AddPurchaseButton_Click; // Обработка события клика
            this.Controls.Add(button1);

            InitializeMyComponents();

            purchaseFactory = new DefaultPurchaseFactory();
            purchaseManager = PurchaseManager.Instance;
            UpdatePurchaseList();
        }

        private void InitializeMyComponents()
        {
            label1 = new System.Windows.Forms.Label { Text = "Введите название продукта:", AutoSize = true };
            label1.Location = new System.Drawing.Point(10, 20);
            this.Controls.Add(label1);
            label2 = new System.Windows.Forms.Label { Text = "Введите цену продукта:", AutoSize = true };
            label2.Location = new System.Drawing.Point(10, 80);
            this.Controls.Add(label2);
            totalCostLabel = new System.Windows.Forms.Label { AutoSize = true };
            totalCostLabel.Location = new System.Drawing.Point(300, 10);
            this.Controls.Add(totalCostLabel);
        }

        private void AddPurchaseButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            decimal price;
            if (!decimal.TryParse(priceTextBox.Text, out price))
            {
                MessageBox.Show("Неверный формат цены.");
                return;
            }

            Purchase purchase = purchaseFactory.CreatePurchase(name, price);
            purchaseManager.AddPurchase(purchase);
            UpdatePurchaseList();
            nameTextBox.Text = "";
            priceTextBox.Text = "";
        }

        private void UpdatePurchaseList()
        {
            purchaseListBox.Items.Clear();
            foreach (Purchase purchase in purchaseManager.Purchases)
            {
                purchaseListBox.Items.Add($"{purchase.Name} - {purchase.Price}");
            }
            totalCostLabel.Text = $"Общая стоимость: {purchaseManager.GetTotalCost()}";
        }
    }
}