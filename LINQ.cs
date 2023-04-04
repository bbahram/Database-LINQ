using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace az_paygah
{
    public partial class Form1 : Form
    {
        public string Check(string text)
        {
            if (text == "")
                return true.ToString();
            return text;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox9.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                textBox8.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox10.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox7.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);

            var comm = new SqlCommand("select * from CONSUMER where IDNUM= '" + Check(textBox1.Text) + "' ", conn);
            if (textBox1.Text == "*")
                comm = new SqlCommand("select * from CONSUMER", conn);
            try
            {
                conn.Open();
                var dreader = comm.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dreader);
                dataGridView1.DataSource = table;


                dreader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Error!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);

            var comm = new SqlCommand("select * from FOOD_COMPANY where COID= '" + Check(textBox9.Text) + "' ", conn);
            if (textBox9.Text == "*")
                comm = new SqlCommand("select * from FOOD_COMPANY", conn);
            try
            {
                conn.Open();
                var dreader = comm.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dreader);
                dataGridView3.DataSource = table;


                dreader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Error!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();


            if (comboBox1.Text == "Worker")
            {
                if (comboBox2.Text == "All")
                {
                    comm = new SqlCommand("select * from WORKER where PID= '" + Check(textBox6.Text) + "' ", conn);
                    if (textBox6.Text == "*")
                        comm = new SqlCommand("select * from WORKER", conn);
                }
                else
                {
                    comm = new SqlCommand("select * from worker_info where PID= '" + Check(textBox6.Text) + "' ", conn);
                    if (textBox6.Text == "*")
                        comm = new SqlCommand("select * from worker_info", conn);
                }
            }
            else
            {
                comm = new SqlCommand("select * from COOK where PID= '" + Check(textBox6.Text) + "' ", conn);
                if (textBox6.Text == "*")
                    comm = new SqlCommand("select * from COOK", conn);
            }

            try
            {
                conn.Open();
                var dreader = comm.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dreader);
                dataGridView2.DataSource = table;


                dreader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Error!");
            }
            finally
            {
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox1.Text != "" && textBox1.Text != "*")
            {
                comm = new SqlCommand("INSERT INTO CONSUMER VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "'); ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");


                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox9.Text != "" && textBox9.Text != "*")
            {
                comm = new SqlCommand("INSERT INTO FOOD_COMPANY VALUES ('" + textBox9.Text + "', '" + textBox8.Text + "'); ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");


                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox1.Text != "" && textBox1.Text != "*")
            {
                comm = new SqlCommand("delete from CONSUMER where IDNUM= '" + textBox1.Text + "' ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");


                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox9.Text != "" && textBox9.Text != "*")
            {
                comm = new SqlCommand("delete from FOOD_COMPANY where COID= '" + textBox9.Text + "' ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");


                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox1.Text != "" && textBox1.Text != "*")
            {
                comm = new SqlCommand("update CONSUMER set IDNUM='" + textBox1.Text + "', Fname='" + textBox2.Text + "', Lname= '" + textBox3.Text + "' where IDNUM= '" + textBox1.Text + "' ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");

                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();
            if (textBox9.Text != "" && textBox9.Text != "*")
            {
                comm = new SqlCommand("update FOOD_COMPANY set COID='" + textBox9.Text + "', PNUM='" + textBox8.Text + "' where COID= '" + textBox9.Text + "' ", conn);
                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    MessageBox.Show(" Done!");

                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();

            if (textBox6.Text != "" && textBox6.Text != "*")
            {
                if (comboBox1.Text == "Worker")
                {
                    comm = new SqlCommand("INSERT INTO WORKER VALUES ('" + textBox6.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "', '" + textBox10.Text + "','" + textBox7.Text + "'); ", conn);
                }
                else
                {
                    comm = new SqlCommand("INSERT INTO COOK VALUES ('" + textBox6.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "', '" + textBox10.Text + "','" + textBox7.Text + "'); ", conn);
                }

                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(dreader);
                    dataGridView2.DataSource = table;

                    MessageBox.Show(" Done!");

                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();

            if (textBox6.Text != "" && textBox6.Text != "*")
            {
                if (comboBox1.Text == "Worker")
                {
                    comm = new SqlCommand("update WORKER set PID='" + textBox6.Text + "', Lname='" + textBox5.Text + "', [WORK HOUR]= '" + textBox4.Text + "', [STEADY SALARY]='" + textBox10.Text + "', [VIRTUAL SALARY]='" + textBox7.Text + "' where PID= '" + textBox6.Text + "' ", conn);
                }
                else
                {
                    comm = new SqlCommand("update COOK set PID='" + textBox6.Text + "', Lname='" + textBox5.Text + "', [WORK HOUR]= '" + textBox4.Text + "', [STEADY SALARY]='" + textBox10.Text + "', [VIRTUAL SALARY]='" + textBox7.Text + "' where PID= '" + textBox6.Text + "' ", conn);
                }

                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(dreader);
                    dataGridView2.DataSource = table;

                    MessageBox.Show(" Done!");

                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();

            if (textBox6.Text != "" && textBox6.Text != "*")
            {
                if (comboBox1.Text == "Worker")
                {
                    comm = new SqlCommand("delete from WORKER where PID= '" + textBox6.Text + "' ", conn);
                }
                else
                {
                    comm = new SqlCommand("delete from COOK where PID= '" + textBox6.Text + "' ", conn);
                }

                try
                {
                    conn.Open();
                    var dreader = comm.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(dreader);
                    dataGridView2.DataSource = table;

                    MessageBox.Show(" Done!");

                    dreader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(" Error!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                MessageBox.Show("ID field is empty");
        }

        private void tabPage2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Worker")
            {
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
                button16.Visible = true;
                button16.Enabled = true;
                button17.Visible = true;
                button17.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Visible = false;
                button16.Visible = false;
                button16.Enabled = false;
                button17.Visible = false;
                button17.Enabled = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();


            comm = new SqlCommand("select * from dbo.totsal()", conn);

            try
            {
                conn.Open();
                var dreader = comm.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dreader);
                dataGridView2.DataSource = table;

                MessageBox.Show(" Done!");

                dreader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Error!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection conn;
            connetionString = "data source=YOUR NAME; database=SELF; integrated security=true";
            conn = new SqlConnection(connetionString);
            var comm = new SqlCommand();


            comm = new SqlCommand("declare @account int exec numberOfWorkers @account = @account OUTPUT; select @account as Number_Of_Workers ", conn);

            try
            {
                conn.Open();
                var dreader = comm.ExecuteReader();
                dreader.Read();
                MessageBox.Show("The Number Of Workers Is: '"+dreader[0].ToString()+"'");

                dreader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(" Error!");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
