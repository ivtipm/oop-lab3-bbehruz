using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Bot
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton1_Click(object sender, EventArgs e)  //кнопка закрытия формы
        {
            this.Close();  //закрыть формы
        }

        private void LoginButton2_Click(object sender, EventArgs e)  //кнопка входа в ЧатБот
        {
            if (UserName.Text == "")
            {
                MessageBox.Show("Не удалось войти. Введите своё имя.");
            }
            else
            {
                Form1 form = new Form1();  
                form.bot.LoadHistory(UserName.Text);
                form.Show();  //открытие формы ЧатБот
                form.RestoreChat();  //восстановить чат
                this.Hide();  //закрытие формы авторизации
            }
        }
    }
}
