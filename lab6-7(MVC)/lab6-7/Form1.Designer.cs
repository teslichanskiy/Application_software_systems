namespace lab6_7
{
    partial class TaskListView
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
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DueDateTextBox = new System.Windows.Forms.TextBox();
            this.TaskListListBox = new System.Windows.Forms.ListBox();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.RemoveTaskButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(2, 34);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(340, 26);
            this.DescriptionTextBox.TabIndex = 0;
            // 
            // DueDateTextBox
            // 
            this.DueDateTextBox.Location = new System.Drawing.Point(2, 96);
            this.DueDateTextBox.Name = "DueDateTextBox";
            this.DueDateTextBox.Size = new System.Drawing.Size(340, 26);
            this.DueDateTextBox.TabIndex = 1;
            // 
            // TaskListListBox
            // 
            this.TaskListListBox.FormattingEnabled = true;
            this.TaskListListBox.ItemHeight = 20;
            this.TaskListListBox.Location = new System.Drawing.Point(410, 12);
            this.TaskListListBox.Name = "TaskListListBox";
            this.TaskListListBox.Size = new System.Drawing.Size(501, 484);
            this.TaskListListBox.TabIndex = 2;
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Location = new System.Drawing.Point(2, 144);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(123, 49);
            this.AddTaskButton.TabIndex = 3;
            this.AddTaskButton.Text = "Добавить задачу";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click_1);
            // 
            // RemoveTaskButton
            // 
            this.RemoveTaskButton.Location = new System.Drawing.Point(183, 286);
            this.RemoveTaskButton.Name = "RemoveTaskButton";
            this.RemoveTaskButton.Size = new System.Drawing.Size(134, 49);
            this.RemoveTaskButton.TabIndex = 4;
            this.RemoveTaskButton.Text = "Удалить задачу";
            this.RemoveTaskButton.UseVisualStyleBackColor = true;
            this.RemoveTaskButton.Click += new System.EventHandler(this.RemoveTaskButton_Click_1);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(183, 367);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(131, 49);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Очистить список";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите задачу";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Введите дедлайн в формате (дд.мм.гггг)";
            // 
            // TaskListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 559);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RemoveTaskButton);
            this.Controls.Add(this.AddTaskButton);
            this.Controls.Add(this.TaskListListBox);
            this.Controls.Add(this.DueDateTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Name = "TaskListView";
            this.Text = "Список задач";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox DueDateTextBox;
        private System.Windows.Forms.ListBox TaskListListBox;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button RemoveTaskButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

