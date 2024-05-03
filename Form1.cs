using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace 随机抽号
{
    public partial class Form1 : Form
    {
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label3.Text = "";
            richTextBox1.Text = "52";
        }

        public void Rnd() {
            Random rnd = new Random();
            int maxnum = int.Parse(richTextBox1.Text);
            int num = rnd.Next(1, maxnum + 1);
            label1.Text = num.ToString();
            Wait(50);
        }

        private void Wait(int time)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(time) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("输入人数，傻鸟！", "🐖🖊", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            int maxnum = int.Parse(richTextBox1.Text);
            flag = !flag;
            if ((button1.Text).Equals("开始") == true)
            {
                button1.Text = "停止";
                while (flag == true)
                {
                    Rnd();
                }
            }
            if ((button1.Text).Equals("停止") == true) {
                label3.Text += label1.Text;
                label3.Text += ",";
                button1.Text = "开始";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
