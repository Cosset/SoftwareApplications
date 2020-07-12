using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using KeemanProject.Properties;

namespace KeemanProject
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@Program.ConnectionString);
        public Login()
        {
            InitializeComponent();

            Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbyhandwriting);
            txtUsername.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtPassword.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username can't be empty. Please enter something!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password can't be empty. Please enter something!");
                return;
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[User] where Username='" + username + "' and Password='" + password + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == false) 
            {
                MessageBox.Show("Username or Password is incorrect");
                con.Close();
                return;
            }
            else
            {

             
                con.Close();
                this.Hide();
                MainForm f = new MainForm();
                f.ShowDialog();
                this.Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            {
                this.Hide();  
                Register f = new Register();   
                f.ShowDialog();                
                this.Show();    
            }
        }
    }
}
