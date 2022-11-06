using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carRental
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

  
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LAMIA\OneDrive\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from CustomrTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CustomrTbl values(" + idTb.Text + ",'" + NameTb.Text + "','" + AddressTb.Text + "'," + PhoneTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CustomrTbl where CustId=" + idTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

       


        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustomrTbl set CustName='" + NameTb.Text + "',CustAdd='" + AddressTb.Text + "', Phone=" + PhoneTb.Text + " where CustId=" + idTb.Text + ";";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}
