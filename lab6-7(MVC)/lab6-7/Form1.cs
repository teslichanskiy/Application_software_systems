using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace lab6_7
{
    public partial class TaskListView : Form
    {
        private TaskListController controller;

        public TaskListView(TaskListController controller)
        {
            InitializeComponent();
            this.controller = controller;
            UpdateTaskList();
        }


        private void UpdateTaskList()
        {
            TaskListListBox.Items.Clear();
            foreach (var task in controller.GetTasks())
            {
                string itemText = $"{task.Description} (Крайний срок: {task.DueDate:d})";
                if (task.IsCompleted)
                {
                    itemText += " (Завершено)";
                }
                TaskListListBox.Items.Add(itemText);
            }
        }

        private void TaskListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TaskListListBox.SelectedIndex >= 0)
            {
                int taskId = controller.GetTaskId(TaskListListBox.SelectedIndex);
                controller.MarkTaskAsCompleted(taskId);
                UpdateTaskList();
            }
        }


        private int GetTaskId(int listIndex)
        {
            return controller.GetTasks()[listIndex].Id;
        }

        private void AddTaskButton_Click_1(object sender, EventArgs e)
        {
            string description = DescriptionTextBox.Text;
            if (DateTime.TryParse(DueDateTextBox.Text, out DateTime dueDate))
            {
                controller.AddTask(description, dueDate);
                UpdateTaskList();
                DescriptionTextBox.Text = "";
                DueDateTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Неверный формат даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveTaskButton_Click_1(object sender, EventArgs e)
        {
            if (TaskListListBox.SelectedIndex >= 0)
            {
                int taskId = controller.GetTaskId(TaskListListBox.SelectedIndex);
                controller.RemoveTask(taskId);
                UpdateTaskList();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            controller.ClearTasks();
            UpdateTaskList();
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public Task(string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }

    public class TaskList
    {
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public Task AddTask(string description, DateTime dueDate)
        {
            var task = new Task(description, dueDate) { Id = nextId++ };
            tasks.Add(task);
            return task;
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public void RemoveTask(int taskId)
        {
            tasks.RemoveAll(t => t.Id == taskId);
        }
    }

    public class TaskListController
    {
        private TaskList taskList = new TaskList();

        public List<Task> GetTasks()
        {
            return taskList.GetTasks();
        }

        public Task AddTask(string description, DateTime dueDate)
        {
            return taskList.AddTask(description, dueDate);
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            taskList.MarkTaskAsCompleted(taskId);
        }

        public void RemoveTask(int taskId)
        {
            taskList.RemoveTask(taskId);
        }

        public int GetTaskId(int listIndex)
        {
            return taskList.GetTasks()[listIndex].Id;
        }

        public void ClearTasks()
        {
            taskList.GetTasks().Clear();
        }
    }
}
