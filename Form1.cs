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
using System.Diagnostics.Eventing.Reader;
using System.Collections.Specialized;

namespace 随机抽号
{
    public partial class Form1 : Form
    {
        bool flag = false;
        List<int> de = new List<int>(), used = new List<int>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label3.Text = "";
            label4.Text = "排除号数";
            richTextBox2.Text = "使用空格分隔";
            richTextBox1.Text = "52";
        }

        private void Get_de(string s)
        {
            de.Clear();
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!('0' <= s[i] && s[i] <= '9'))
                {
                    de.Add(Toint(res));
//                    MessageBox.Show(Toint(res).ToString());
                    res = ""; continue;
                }
                res += s[i];
            }
            de.Add(Toint(res));
        }
        
        private int Toint(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                res = res * 10 + s[i] - '0';
            }
            return res;
        }

        public bool Rnd() {
            Random rnd = new Random();
            int maxnum = int.Parse(richTextBox1.Text);
            int num = rnd.Next(1, maxnum + 1);
            if (!checkBox1.Checked)
            {
                if (used.Count + de.Count == maxnum)
                {
                    MessageBox.Show("「♡杂鱼～杂鱼～废物～♡真的是杂鱼呢～♡」，连抽完了都不知道", "♡杂鱼♡", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return true;
                }
                while (used.Contains(num) || de.Contains(num)) num = rnd.Next(1, maxnum + 1);
            }
            else
            {
                while (de.Contains(num)) num = rnd.Next(1, maxnum + 1);
            }
            label1.Text = num.ToString();
            Wait(50);
            return false;
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
                string s = richTextBox2.Text;
                Get_de(s);
                while (flag == true)
                {
                     if (Rnd())
                    {
                        button1.Text = "开始";
                        flag = !flag;
                        break;
                    }
                }
            }
            if ((button1.Text).Equals("停止") == true) {
                label3.Text += label1.Text;
                used.Add(Toint(label1.Text));
                label3.Text += ",";
                button1.Text = "开始";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            used.Clear();
        }
    }
}
