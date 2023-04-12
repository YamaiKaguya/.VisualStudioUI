using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Program
{
    public partial class Form1 : Form
    {
        OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Desktop\.VisualStudioUI-main\CustomerDatabase.accdb");
        OleDbDataAdapter oleDbAdapter;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            if (Connection.State.ToString().Equals("Closed"))
            {
                Connection.Open();
            }
            oleDbAdapter = new OleDbDataAdapter();
            ds = new DataSet();


            try
            {
                oleDbAdapter.SelectCommand = new OleDbCommand("SELECT * FROM [CustumerDatabase]", Connection);
                dataGridView1.DataSource = null;
                oleDbAdapter.Fill(ds);
                oleDbAdapter.Dispose();
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (Connection.State.ToString().Equals("Open"))
            {
                Connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.Open();
            OleDbCommand cmd = Connection.CreateCommand(); cmd.CommandType = CommandType.Text; cmd.CommandText = "Insert into CustumerDatabase values('" + txtcustomer.Text + "','" + txtcompany.Text + "','" + txtcontact.Text + "','" + txtaddress.Text + "','" + txtphone.Text + "','" + txthealthy.Text + "','" + txttheme.Text + "','" + txtfavorite.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Inserted Successfuy");
            Connection.Close();
            Display();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtcustomer.Text = "";
            txtcompany.Text = "";
            txtcontact.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txthealthy.Text = "";
            txttheme.Text = "";
            txtfavorite.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcustomer.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            txtcompany.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtcontact.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtaddress.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            txtphone.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            txthealthy.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            txttheme.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            txtfavorite.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                OleDbCommand cmd = new
                OleDbCommand();
                cmd.Connection = Connection;
                string query = "Delete from CustumerDatabase where Custumer_No=" + txtcustomer.Text + "";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Succesfully");
                Connection.Close();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            Connection.Open();
            OleDbCommand cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CustumerDatabase where Custumer_No=" + txtcustomer.Text+ "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            Connection.Close();

            if (count == 0)
            {
                MessageBox.Show("Record not Found");
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
