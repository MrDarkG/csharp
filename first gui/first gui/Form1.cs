using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, EventArgs e)
        {
            string username=LoginUsername.Text;
            string pwd = LoginPassword.Text;
            int result = Program.Login(username, pwd);
            if (result == 1)
            {
                if (Program.priv == 1)
                {
                    this.Hide();
                    var form2 = new Form2();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else
                {
                    this.Hide();
                    var ChatView = new ChatView();
                    ChatView.Closed += (s, args) => this.Close();
                    ChatView.Show();
                }
            }
            else
            {
                MessageBox.Show("Creditionals are Incorrect");
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            register.Enabled = checkBox1.Checked;
        }

        private void register_Click(object sender, EventArgs e)
        {
            string user = RegisterUsername.Text;
            RegisterUsername.Text = "";
            string pwd = RegisterPassword.Text;
            RegisterPassword.Text = "";
            string repwd = RepeatePwd.Text;
            RepeatePwd.Text = "";
            if (!pwd.Equals(repwd)) {
                MessageBox.Show("Passwrods didnt match");
            }
            else if (pwd.Length < 8)
            {
                MessageBox.Show("Passwrods must be at least 8 chars ");
                RegisterPassword.Text = "";
                RepeatePwd.Text = "";
            }
            else
            {
                MessageBox.Show(Program.register(user,pwd));
            }
            


        }
        private void LoginUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RegisterUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
