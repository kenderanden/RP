using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public struct User
    {
        public string login;
        public string password;
        public string type;
    }
    public partial class FormAuthorization : Form
    {
        public static User users = new User();

        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text == "" && textBoxPass.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool key = false;
                foreach(Users user in Program.RPE.Users)
                {
                    if(textBoxLogin.Text == user.Login && textBoxPass.Text == user.Password)
                    {
                        key = true;
                        users.login = user.Login;
                        users.password = user.Password;
                        users.type = user.Type;
                    }
                }

                if(!key)
                {
                    MessageBox.Show("Проверте данные", "Пользовательне найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxLogin.Text = "";
                    textBoxPass.Text = "";
                }
                else
                {
                    MessageBox.Show("Данные введены верно", "Пользователь найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
            }
        }
    }
}
