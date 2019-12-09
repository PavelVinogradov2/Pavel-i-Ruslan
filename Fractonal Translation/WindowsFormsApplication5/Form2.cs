using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        string pathTextLogPass = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\login.txt";

        public Form2()
        {
           
            InitializeComponent();           
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login;
            string pasword;

            if (File.Exists(pathTextLogPass))
            {
                string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
                foreach (string line in lines)
                {
                    string[] linesDec = Decryption(line).Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    login = linesDec[0];
                    pasword = linesDec[1];

                    if (login.ToLower() == tbxLogin.Text.ToLower() && pasword == tbxPasword.Text) Start();
                }
            }

          MessageBox.Show("Такого логина или пароля не существует. \n Повторите ввод или зарегистрируйтесь!");
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(pathTextLogPass);
            form3.ShowDialog();
            if (form3.DialogResult == DialogResult.OK) Start();
        }

        void Start()
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        string Decryption(string str)
        {
            StringBuilder strB = new StringBuilder(str);
            for (int i = 0; i < strB.Length; i++)
                strB[i] = (char)(strB[i] - 2);

            return strB.ToString();
        }

        private void TbxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            ToolTip t2 = new ToolTip();
            t.SetToolTip(tbxLogin, "Введите логин");
            t2.SetToolTip(tbxPasword, "Введите пароль");
        }
    }
}
