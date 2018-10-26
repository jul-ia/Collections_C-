using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace collections1
{
    public partial class Form1 : Form
    {
        Stack<Task> tasks = new Stack<Task>();

        Queue<Task> qtask = new Queue<Task>();

        List<Task> ltask = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                tasks.Push(new Task("Task" + i));
                qtask.Enqueue(new Task("Task" + i));
                ltask.Add(new Task("Task" + i));
            }


            label2.Text = tasks.Peek().Name;
            label4.Text = qtask.Peek().Name;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ltask;
        }
        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                tasks.Push(new Task(textBox1.Text));
                ltask.Add(new Task(textBox1.Text));
                qtask.Enqueue(new Task(textBox1.Text));
            }
            label2.Text = tasks.Peek().Name;
            label4.Text = qtask.Peek().Name;
            textBox1.Text = "";
            button4.Enabled = true;
            button3.Enabled = true;

        }

        //show
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ltask;
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < ltask.Count;)
            {
                if (ltask[i].State)
                    ltask.RemoveAt(i);
                else
                    i++;
            }
            if (ltask.Count == 0)
                button3.Enabled = false;
        }

        //finish current task
        private void button4_Click(object sender, EventArgs e)
        {
            if(tasks.Count == 1 && qtask.Count == 1)
            {
                label2.Text = "No tasks available";
                label4.Text = "No tasks available";
                tasks.Clear();
                qtask.Clear();
                button4.Enabled = false;
                return;
            }
            tasks.Pop();
            qtask.Dequeue();
            label2.Text = tasks.Peek().Name;
            label4.Text = qtask.Peek().Name;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = tasks.ToList<Task>();
            listBox1.DisplayMember = "Name";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = qtask.ToList<Task>();
            listBox2.DisplayMember = "Name";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedRows[0].Index;
            if (ltask[i].State)
                ltask.RemoveAt(i);
        }
    }
}
