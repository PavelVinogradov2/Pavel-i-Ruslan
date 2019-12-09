using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {
       string pathTextLogPass;

       public Form3(string pathTextLogPass)
        {
            InitializeComponent();

            this.pathTextLogPass = pathTextLogPass;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (!(File.Exists(pathTextLogPass))) 
                using (FileStream fs = new FileStream(pathTextLogPass, FileMode.CreateNew));
            label3.Hide(); tbxPasword2.Hide();
        }

        private void brnOk_Click(object sender, EventArgs e)
        {         
                if (tbxLogin.Text == string.Empty)
                {
                    MessageBox.Show("Создайте логин");
                    return;
                }
          
                if (tbxPasword1.Text == string.Empty || tbxPasword2.Text == string.Empty)
                {
                    MessageBox.Show("Поле с паролем не заполнено");
                    return;
                }
                if (tbxPasword1.Text != tbxPasword2.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }

                if (Save(tbxLogin.Text, tbxPasword1.Text) == true)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    return;
        }

        
        //проверяем, что такой логин еще не занят
        bool NotHaveLogin(string pathTextLogPass)
        {
            string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
            foreach (string line in lines)
            {
                if (Decryption(line).Split('|')[0].ToLower() == tbxLogin.Text.ToLower())
                {
                    MessageBox.Show("Такой логин уже существует");
                    return false;
                }
            }

            return true;
        }


        // сохраняем пару логин/пароль в файл
        bool Save(string login, string pasword)
        {
            try
            {
                if (NotHaveLogin(pathTextLogPass))
                {
                    File.AppendAllLines(pathTextLogPass, new[] {  Encryption(login + "|" + pasword) } , Encoding.Default);
                      return true;                    
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        // шифрование пары логин/пароль
        string Encryption(string str)
        {
            StringBuilder strB = new StringBuilder (str);
               for (int i = 0; i < strB.Length; i++)
                   strB[i] = (char) (strB[i]+2); //простейшее шифрование. Изменяем значение каждого символа на тот символ, который идет вторым после этого в таблице символов. Используйте другое шифрование

            return strB.ToString();
        }

        // расшифрование пары логин/пароль
        string Decryption(string str)
        {
            StringBuilder strB = new StringBuilder(str);
            for (int i = 0; i < strB.Length; i++)
                strB[i] = (char)(strB[i] - 2); 

            return strB.ToString();
        }
        
        // появление поля для повторного ввода пароля
        private void tbxPasword1_TextChanged(object sender, EventArgs e)
        {           
            if (tbxPasword1.Text == string.Empty) { label3.Hide(); tbxPasword2.Hide(); }
               else { label3.Show(); tbxPasword2.Show(); }            
        }


       // запрет ввода символа '|'
        private void tbxPasword1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|') 
            {
                MessageBox.Show("Символ ' | ' запрещен для ввода"); // т.к этот символ будет разделителем для логина и пароля при хранении строк в файле
                e.Handled = true;
            }
        }
    }
}
