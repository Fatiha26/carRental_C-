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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LAMIA\OneDrive\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populateReturn()
        {
            Con.Open();
            string query1 = "select * from ReturnTbl";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, Con);
            SqlCommandBuilder builder1 = new SqlCommandBuilder(da1);
            var ds1 = new DataSet();
            da1.Fill(ds1);
            ReturnDGV.DataSource = ds1.Tables[0];
            Con.Close();
        }
        private void populateRet()
        {
            Con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }
        private void Deleteonreturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentalDGV.SelectedRows[0].Cells[0].Value.ToString());
            Con.Open();
            string query = "delete from RentalTbl where RentId=" + rentId + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Rental Successfully Deleted");
            Con.Close();
            populate();
            //UpdateonRentDelete();
        }


        private void RentalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarIdTb.Text = RentalDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentalDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentalDGV.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.Date;
            var d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int NrOfDays = Convert.ToInt32(t.TotalDays);
            if(NrOfDays <= 0)
            {
                DelayTb.Text = "No delay";
                FineTb.Text = "0";
            }
            else
            {
                DelayTb.Text = "" + NrOfDays;
                FineTb.Text = ""+ (NrOfDays * 250);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "" || CustNameTb.Text == "" || FineTb.Text == "" || DelayTb.Text =="" || DelayTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into ReturnTbl values(" + idTb.Text + "," + CarIdTb.Text + ",'" + CustNameTb.Text + "','" + Convert.ToDateTime(ReturnDate.Text) + "','" + DelayTb.Text + "','" +FineTb.Text+ "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car is Returned");
                    Con.Close();
                    //UpdateonRent();
                    populateRet();
                    Deleteonreturn();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
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
                    string query = "delete from ReturnTbl where ReturnId=" + idTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Successfully Deleted");
                    Con.Close();
                    populateReturn();
                    //UpdateonRentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void ReturnDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ReturnDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idTb.Text = ReturnDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarIdTb.Text = ReturnDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = ReturnDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

    }
}
