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
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(@Program.ConnectionString);
        public Register()
        {
            InitializeComponent();

            Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbyhandwriting);
            txtUsername.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtPassword.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtRetype.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtContact.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtRealName.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtAddress.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0)   
            {
                MessageBox.Show("Username can't be empty.");
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password can't be empty.");
                return;
            }
            if (txtRetype.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please retype your password.");
                return;
            }
            if (txtRealName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Real Name can't be empty.");
                return;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Address can't be empty.");
                return;
            }
            if (txtContact.Text.Trim().Length == 0)
            {
                MessageBox.Show("Contact can't be empty.");
                return;
            }
            string Password = txtPassword.Text.Trim();
            string Retype = txtRetype.Text.Trim();
            if (Password.Equals(Retype) == false)     
            {
                MessageBox.Show("Password and Retype Password don't match. Please match them and try again.");
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string name = txtRealName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[User] where Username='" + username + "'";
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();
            bool user_exist = true;
            if (reader.Read() == false) 
            {
                user_exist = false;
            }
            else
            {
                MessageBox.Show("Username is already taken. Try a different one!");
            }
            reader.Close();         

            if (user_exist == false)
            {
                SqlCommand add_cmd = con.CreateCommand();
                add_cmd.CommandType = CommandType.Text;
                add_cmd.CommandText = "INSERT INTO [dbo].[User] (Name, Contact_Number, Address, Password, Username) VALUES ('" + name + "','" + contact + "','" + address + "','" +
                    password + "','" + username + "')";
                add_cmd.ExecuteNonQuery();
                MessageBox.Show("Successful! Account created!");
                con.Close();
                this.Close();
            }
            con.Close();
        }

        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}
