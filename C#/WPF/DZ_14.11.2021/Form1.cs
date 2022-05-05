using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_14._11._2021
{



    public partial class MainForm : Form
    {
        private List<Command> commands = new List<Command>();


        public MainForm()
        {

            InitializeComponent();

            listBoxTasks.Items.Add(new Command() { name = "Задание 1",
                Action = form => {form = new Task1(); form.ShowDialog();} });
            
            listBoxTasks.Items.Add(new Command() { name = "Задание 2",
                Action = form => { form = new Task2(); form.ShowDialog(); } });

            listBoxTasks.Items.Add(new Command() { name = "Задание 3",
                Action = form => { form = new Task3(); form.ShowDialog(); }
            });

            listBoxTasks.Items.Add(new Command()
            {
                name = "Задание 4",
                Action = form => { form = new Task4(); form.ShowDialog(); }
            });

            listBoxTasks.Items.Add(new Command()
            {
                name = "Задание 5",
                Action = form => { form = new Task5(); form.ShowDialog(); }
            });

            listBoxTasks.Items.Add(new Command()
            {
                name = "Задание 6",
                Action = form => { form = new Task6(); form.ShowDialog(); }
            });

            listBoxTasks.Items.Add(new Command()
            {
                name = "Задание 7",
                Action = form => { form = new Task7(); form.ShowDialog(); }
            });

            listBoxTasks.Items.Add(new Command()
            {
                name = "Задание 8",
                Action = form => { form = new Task2(); form.ShowDialog(); }
            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;

            Form newForm = null;

            if (index != -1) {
                if((listBoxTasks.Items[index] as Command).Action != null)
                    (listBoxTasks.Items[index] as Command).Action(newForm);
            }else return;
        }
    }

    public class Command
    {
        public string name;
        public Action<Form> Action;

        public override string ToString() => name;
    }
}
