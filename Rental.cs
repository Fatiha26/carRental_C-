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


namespace carRental
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
       SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LAMIA\OneDrive\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fillcombo()
        {
            Con.Open();
            string query = "select  RegNum from CarTbl where Available='"+"Yes "+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            Con.Close();
        }
        private void fillCustomer()
        {
            Con.Open();
            string query = "select CustId from CustomrTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustCb.ValueMember = "CustId";
            CustCb.DataSource = dt;
            Con.Close();
        }
        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from CustomrTbl where CustId="+CustCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }
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
        private void UpdateonRent()
        {
            Con.Open();
            string query = "update CarTbl set Available='" + "No" + "' where RegNum='" +CarRegCb.SelectedValue.ToString()+ "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
           //MessageBox.Show("Car Successfully Updated");
            Con.Close();
            populate();
        }
        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update CarTbl set Available='" + "Yes" + "' where RegNum='" + CarRegCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Car Successfully Updated");
            Con.Close();
        }
            private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idTb.Text == "" || CustNameTb.Text == "" || FeesTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into RentalTbl values(" + idTb.Text + ",'" + CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + Convert.ToDateTime(RentDate.Text) + "','"+ Convert.ToDateTime(ReturnDate.Text)+"',"+FeesTb.Text+")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");
                    Con.Close();
                    UpdateonRent();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
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
                    string query = "delete from RentalTbl where RentId=" + idTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Successfully Deleted");
                    Con.Close();
                    populate();
                    UpdateonRentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void RentalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idTb.Text = RentalDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.Text = RentalDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentalDGV.SelectedRows[0].Cells[2].Value.ToString();
            FeesTb.Text = RentalDGV.SelectedRows[0].Cells[5].Value.ToString();


        }

        private void RentDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
