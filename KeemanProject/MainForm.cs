using KeemanProject.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KeemanProject
{
    public partial class MainForm : Form
    {
        private SqlConnection con = new SqlConnection(Program.ConnectionString);
        private Dictionary<int, Bitmap> Images { get; } = new Dictionary<int, Bitmap>();


        public MainForm()
        {
            InitializeComponent();

            Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbyhandwriting);
            cbCandies.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            nudQuantity.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtCost.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtMass.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtCustomerName.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtName.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtTotal.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtPassword.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtUsername.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtContact.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtAddress.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtMass.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtCandies.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtQuantity.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);
            txtOrderCost.Cursor = CursorComponent.Instance.Create(CursorPointerEnum.kirbytext);

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();
            About f = new About();
            f.ShowDialog();
            this.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet7.CustomerOrder' table. You can move, or remove it, as needed.
            this.customerOrderTableAdapter2.Fill(this.database1DataSet7.CustomerOrder);
            // TODO: This line of code loads data into the 'database1DataSet5.CustomerOrder' table. You can move, or remove it, as needed.
            this.customerOrderTableAdapter1.Fill(this.database1DataSet5.CustomerOrder);
            // TODO: This line of code loads data into the 'database1DataSet6.CustomerOrder' table. You can move, or remove it, as needed.
            this.customerOrderTableAdapter.Fill(this.database1DataSet6.CustomerOrder);
            // TODO: This line of code loads data into the 'database1DataSet5.CandyMass' table. You can move, or remove it, as needed.
            this.candyMassTableAdapter2.Fill(this.database1DataSet5.CandyMass);
            // TODO: This line of code loads data into the 'database1DataSet4.CandyMass' table. You can move, or remove it, as needed.
            this.candyMassTableAdapter1.Fill(this.database1DataSet4.CandyMass);
            // TODO: This line of code loads data into the 'database1DataSet2.LasTTrYs' table. You can move, or remove it, as needed.
            this.lasTTrYsTableAdapter1.Fill(this.database1DataSet2.LasTTrYs);
            // TODO: This line of code loads data into the 'database1DataSet1.LasTTrYs' table. You can move, or remove it, as needed.

            this.userTableAdapter.Fill(this.database1DataSet.User);

            Images.Add(0, Resources.dragonbreath);
            Images.Add(1, Resources.rsz_jellybeans);
            Images.Add(2, Resources.rsz_macarons);
            Images.Add(3, Resources.rsz_specialmilkpudding);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.ShowDialog();
            this.Show();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            string name = txtName.Text.Trim();
            string contact_number = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();
            string password = txtPassword.Text.Trim();
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                 string.IsNullOrWhiteSpace(txtPassword.Text) ||
                 string.IsNullOrWhiteSpace(txtUsername.Text) ||
                 string.IsNullOrWhiteSpace(txtContact.Text) ||
                 string.IsNullOrWhiteSpace(txtAddress.Text)
                 )

            {
                MessageBox.Show("Please fill out the all the information to add.");
                con.Close();
                return;
            }

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
                con.Close();
                return;
            }
            reader.Close();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [dbo].[User] values( '" + name + "', '" + contact_number + "', '" + address + "', '" + password + "', '" + username + "' )";
            cmd.ExecuteNonQuery();
            con.Close();

            displayData();
        }

        private void displayData()
        {
            con.Open();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[User]";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

            con.Close();
        }

        private void AAAAAAAAAAACOSMI(object sender, KeyPressEventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtUsername.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to delete as it's empty.");
                return;
            }

            int index = Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value);
            var key = Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value);
            int id_customer = (int)key;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [dbo].[User] where Id = '" + id_customer + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            displayData();
            MessageBox.Show("Record deleted successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[User] where Username='" + txtUsername.Text + "'";
            cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text)
                )

            {
                MessageBox.Show("You have to fill out all the information to update.");
                con.Close();
                return;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            bool user_exist = true;
            if (reader.Read() == false)
            {
                user_exist = false;
            }
            else
            {
                MessageBox.Show("Username is already taken. Try a different one!");
                con.Close();
                return;
            }
            reader.Close();
            con.Close();

            int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [dbo].[User] set Name = '" + txtName.Text + "', Contact_Number = '" + txtContact.Text + "', Address = '" + txtAddress.Text + "', Password = '" + txtPassword.Text + "', Username ='" + txtUsername.Text + "' WHERE Id = '" + id + "'";
            //troubleshoot          MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            con.Close();

            displayData();
            MessageBox.Show("Record update successfully");
        }

        private void btnOrderAdd_Click(object sender, EventArgs e)
        {
            string orderquantity = txtQuantity.Text.Trim();
            string ordercandies = txtCandies.Text.Trim();
            string ordermass = txtMass.Text.Trim();
            string ordercost = txtOrderCost.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtCandies.Text) ||
                string.IsNullOrWhiteSpace(txtMass.Text) ||
                string.IsNullOrWhiteSpace(txtOrderCost.Text)
                )

            {
                MessageBox.Show("You have to fill out all the information to add.");
                con.Close();
                return;
            }

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[LasTTrYs] where Candies='" + txtCandies.Text + "'";
            cmd.ExecuteNonQuery();

            SqlDataReader reader = cmd.ExecuteReader();
            bool user_exist = true;
            if (reader.Read() == false)
            {
                user_exist = false;
            }
            else
            {
                MessageBox.Show("Candy name already exist. Try a different one!");
                con.Close();
                return;
            }
            reader.Close();
            con.Close();

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [dbo].[LasTTrYs] values ('" + orderquantity + "', '" + ordercandies + "', '" + ordermass + "', '" + ordercost + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            displayOrderData();
            MessageBox.Show("Inserted successfully!");
        }

        private void displayOrderData()
        {
            con.Open();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[LasTTrYs]";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to delete as it's empty.");
                return;
            }

            int index = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            int id_customer = (int)key;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [dbo].[LasTTrYs] where Id = '" + id_customer + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            displayOrderData();
            MessageBox.Show("Record deleted successfully!");
        }

        private void btnOrderUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[LasTTrYs] where Candies='" + txtCandies.Text + "'";
            cmd.ExecuteNonQuery();

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtCandies.Text) ||
                string.IsNullOrWhiteSpace(txtMass.Text) ||
                string.IsNullOrWhiteSpace(txtOrderCost.Text)
                )

            {
                MessageBox.Show("You have to fill out all the information to update.");
                con.Close();
                return;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            bool user_exist = true;
            if (reader.Read() == false)
            {
                user_exist = false;
            }
            else
            {
                MessageBox.Show("Candy name  is already taken. Try a different one!");
                con.Close();
                return;
            }
            reader.Close();
            con.Close();

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [dbo].[LasTTrYs] set Quantity = '" + txtQuantity.Text + "', Candies = '" + txtCandies.Text + "', Mass = '" + txtMass.Text + "', Cost = '" + txtOrderCost.Text + "' where Id ='" + id + "'";
            //troubleshoot          MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            con.Close();

            displayOrderData();
            MessageBox.Show("Record update successfully");
        }

        private void cbCandies_SelectedIndexChanged(object sender, EventArgs e)
        {

            int cost = 0;
            pbOrder.Image = Images[cbCandies.SelectedIndex];

            switch (cbCandies.SelectedIndex)
            {
                case 0:
                    cost = 10;
                    break;
                case 1:
                    cost = 8;
                    break;
                case 2:
                    cost = 20;
                    break;
                case 3:
                    cost = 30;
                    break;
            }

            txtCost.Text = "$" + Convert.ToString(cost);
            calculateCost();

        }

        private void calculateCost()
        {
            int quantity = Convert.ToInt32(nudQuantity.Value);
            int cost = Convert.ToInt32(extractNumericalValue(txtCost.Text));
            int mass = Convert.ToInt32((string)cbMass.SelectedValue);

            txtTotal.Text = "$" + Convert.ToString(cost * quantity + mass);
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {


            string candy = (cbCandies.Text);
            int quantity = Convert.ToInt32(nudQuantity.Text);
            int cost = Convert.ToInt32(extractNumericalValue(txtCost.Text));
            int mass = Convert.ToInt32((string)cbMass.SelectedValue);
            string customername = (txtCustomerName.Text);

            if (string.IsNullOrWhiteSpace(customername))
            {
                MessageBox.Show("You need to enter a customer name to place the order ^.^");
                return;
            }
            txtTotal.Text = "$" + Convert.ToString(cost * quantity + mass);



            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [dbo].[CustomerOrder] values ('" + quantity + "', '" + cost + "', '" + mass + "', '" + customername + "', '" + candy + "')";

            MessageBox.Show("Order successfully placed!");

            cmd.ExecuteNonQuery();
            con.Close();
            displayOrderData();

        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            cbCandies.Text = "";
            nudQuantity.Value = 1;
            txtCost.Text = "";
            cbMass.Text = "";
            txtTotal.Text = "";
            txtCustomerName.Text = "";
        }

        private int extractNumericalValue(string a)
        {
            string b = string.Empty;
            int val = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }
            if (b.Length > 0)
                val = int.Parse(b);
            return val;

        }

        private void pbOrder_Click(object sender, EventArgs e)
        {

        }

        private void lblMassCostr_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count < 1) return;

            var cells = dataGridView2.SelectedRows[0].Cells;


            txtName.Text = cells[1].Value.ToString();
            txtAddress.Text = cells[3].Value.ToString();
            txtContact.Text = cells[2].Value.ToString();
            txtPassword.Text = cells[4].Value.ToString();
            txtUsername.Text = cells[5].Value.ToString();
        }

        private void Yessir(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1) return;

            var cells = dataGridView1.SelectedRows[0].Cells;


            txtQuantity.Text = cells[1].Value.ToString();
            txtMass.Text = cells[3].Value.ToString();
            txtCandies.Text = cells[2].Value.ToString();
            txtOrderCost.Text = cells[4].Value.ToString();
        }

        private void txtCandies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void cbMass_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView3_Enter(object sender, EventArgs e)
        {
            customerOrderTableAdapter2.Fill(database1DataSet7.CustomerOrder);
            dataGridView3.Update();
            dataGridView3.Refresh();
        }
    }
}