using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGroundWorkerTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // backgroundWorker1.RunWorkerAsync();
            //Thread thread = new Thread(a => MessageBox.Show("Test"));
            //thread.Start();
            //thread.Join();
            Task task = new Task(() =>
            {
                backgroundWorker1_DoWork(null, null);
            });
            Task task2 = new Task(() => MessageBox.Show("Task2"));
            Task task3 = new Task(() => MessageBox.Show("Task3"));
            Task task4 = new Task(() => MessageBox.Show("Task4"));
            task.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            Task.WaitAny(task, task2, task3, task4);
            MessageBox.Show("OKI");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(1000);
                //label1.Text = i.ToString();
                string path = Path.Combine(@"D:\Loggs\", $"{DateTime.Now}.txt");
                path = path.Replace(" ", "_").Replace(".", "_").Replace(":","_").Replace("_txt",".txt").Replace("D_","D:");
                File.Create(path);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Zakończone";
        }
    }
}
