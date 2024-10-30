using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab6_7
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TaskListController controller = new TaskListController();
            TaskListView view = new TaskListView(controller);
            Application.Run(view);
        }
    }
}
