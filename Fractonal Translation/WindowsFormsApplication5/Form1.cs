using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        List<string> dd = new List<string>();
        List<string> bb = new List<string>();
        List<string> fromfile = new List<string>();
        public Form1()
        {
           
            InitializeComponent();
           

        }

        private void MenuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }


        private string doWork(string s, string s1)
        {
            s = Convert.ToString(Convert.ToInt32(s), 2) + "." + Convert.ToString(Convert.ToInt32(s1), 2);
            return s;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите число");
                return;
            }
            string s;
            string s1;
            try
            {
                s = textBox1.Text.Substring(0, textBox1.Text.IndexOf('.'));
                s1 = textBox1.Text.Substring(textBox1.Text.LastIndexOf('.') + 1);
                s = doWork(s, s1);

            }
            catch
            {
                try { s = Convert.ToString(Convert.ToInt32(textBox1.Text), 2); }
                catch { s = "Неверное значение"; }

            }
            if (s.Length > 32)
                s = s.Substring(0, 32);
            TextBox box = new TextBox();
            TextBox box2 = new TextBox();
            box.Text = s;
            box2.Text = textBox1.Text;
            tableLayoutPanel1.Controls.Add(box, 0, tableLayoutPanel1.RowCount);
            tableLayoutPanel2.Controls.Add(box2, 0, tableLayoutPanel2.RowCount);
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel2.RowCount++;
            dd.Add(textBox1.Text);
            bb.Add(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Введите число,нажмите Enter");
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "Text files(*.txt;*.html;*.htm)|*.txt;*.html;*.htm|All files (*.*)|*.*"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                List<string> filelist = new List<string>();
                if (File.Exists(dlg.FileName))
                {
                    File.Delete(dlg.FileName);
                }
                for (int i = 0; i < dd.Count; i++)
                {
                    filelist.Add("Исходное значение:" + dd[i] + ",двоичное значение:" + bb[i]+".");

                }
                File.AppendAllLines(dlg.FileName, filelist);
            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text files(*.txt;*.html;*.htm)|*.txt;*.html;*.htm|All files (*.*)|*.*"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dd.Clear();
                fromfile.Clear();
                bb.Clear();
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel2.RowStyles.Clear();
                BackgroundWorker backgroundWorker1 = new BackgroundWorker();
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.RunWorkerAsync(dlg.FileName);               
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {         
            string ss = (string)e.Argument;
            var lin = File.ReadAllLines(ss);
            foreach (string str in lin)
            {
                fromfile.Add(str);
            }
            foreach(string str in fromfile)
            {
                if (str.IndexOf("Исходное значение")==0)
                {
                    exist();
                    return;
                }
                string s;
                string s1;
                try
                {
                    s =str.Substring(0, str.IndexOf('.'));
                    s1 = str.Substring(str.LastIndexOf('.') + 1);
                    s = doWork(s, s1);

                }
                catch
                {
                    try { s = Convert.ToString(Convert.ToInt32(str), 2); }
                    catch { s = "Неверное значение"; }

                }
                if (s.Length > 32)
                    s = s.Substring(0, 32);
                TextBox box = new TextBox();
                TextBox box2 = new TextBox();
                box.Text = s;
                box2.Text = str;
                tableLayoutPanel1.Invoke(new Action(() => tableLayoutPanel1.Controls.Add(box, 0, tableLayoutPanel1.RowCount)));
                tableLayoutPanel1.Invoke(new Action(() => tableLayoutPanel1.RowCount++));
                tableLayoutPanel2.Invoke(new Action(() => tableLayoutPanel2.Controls.Add(box2, 0, tableLayoutPanel2.RowCount)));
                tableLayoutPanel2.Invoke(new Action(() => tableLayoutPanel2.RowCount++));
                dd.Add(str);
                bb.Add(s);
            }
        }

        private void exist()
        {
            foreach (string str in fromfile)
            {
                string s;
                string s1;
                TextBox box = new TextBox();
                TextBox box2 = new TextBox();
         
             
                s1 = str.Substring(str.IndexOf(":")+1, str.IndexOf(",")- str.IndexOf(":")-1);
                s = str.Substring(str.LastIndexOf(":")+1, str.IndexOf(".") - str.LastIndexOf(":")-1);
                if (s.Length > 32)
                    s = s.Substring(0, 32);
                box.Text = s;
                box2.Text = s1;
                tableLayoutPanel1.Invoke(new Action(() => tableLayoutPanel1.Controls.Add(box, 0, tableLayoutPanel1.RowCount)));
                tableLayoutPanel1.Invoke(new Action(() => tableLayoutPanel1.RowCount++));
                tableLayoutPanel2.Invoke(new Action(() => tableLayoutPanel2.Controls.Add(box2, 0, tableLayoutPanel2.RowCount)));
                tableLayoutPanel2.Invoke(new Action(() => tableLayoutPanel2.RowCount++));
                dd.Add(s1);
                bb.Add(s);
            }

           }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)              
               button1.PerformClick();
            if (ModifierKeys == Keys.Control)
                if (e.KeyValue == 83)
                    toolStripMenuItem4.PerformClick();
                else if (e.KeyValue == 79)
                    toolStripMenuItem3.PerformClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void ОткрытьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }
    }
}
