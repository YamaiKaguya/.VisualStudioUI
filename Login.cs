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
using System.Xml.Linq;

namespace Simple_Program
{
    public partial class Login : Form
    {
        OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Desktop\.VisualStudioUI-main\CustomerDatabase.accdb");
        OleDbDataAdapter oleDbAdapter;
        DataSet ds;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql; int row;
            OleDbConnection con = new OleDbConnection();
            
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Desktop\\.VisualStudioUI-main\\CustomerDatabase.accdb";
            con.Open();

            sql = "select count(*) from Account where Username='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";

            OleDbCommand cmd = new OleDbCommand(sql, con);
            row = (int)cmd.ExecuteScalar();
            con.Close();

            MessageBox.Show("Login Successful!");
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Connection.Open();
            OleDbCommand cmd = Connection.CreateCommand(); 
            cmd.CommandType = CommandType.Text; cmd.CommandText = "Insert into Account values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Account Created Successfuy");
            Connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
