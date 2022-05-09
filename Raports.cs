using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;


namespace ExchangeSoftware
{
    public partial class Raports : Form
    {
        public Raports()
        {
            InitializeComponent();
            this.Size = new Size(1200, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override CreateParams CreateParams
        {

            get
            {
                CreateParams handleparm = base.CreateParams;
                handleparm.ExStyle |= 0x02000000;
                return handleparm;

            }
        }
        public static string passingtexti;
        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //
        private void Raports_Load(object sender, EventArgs e)
        {
            
            label1.Text = Form1.passingtext;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            try
            {

                DataTable dta = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ExchangeConvert Where Date LIKE '%" + dateTimePicker2.Text + "%' AND Username='" + label1.Text + "'", conn);
                conn.Open();
                da.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();

                //for reflection
                dataGridView1.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridView1, true, null);
               // textBox2.Text= exchange.pass;
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.Select();
                label9.Text = dataGridView1.RowCount.ToString();

                kal();
                

            }
            catch (Exception) { }


        }
        public void kal()
        {
            int sum = 0, sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                sum2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
            }
            label12.Text = sum.ToString("#,0.00");
            label13.Text = sum2.ToString("#,0.00");

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Close();
        }

    


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM ExchangeConvert  where ID LIKE'" + textBox2.Text + "%' AND Date LIKE'" + dateTimePicker2.Text + "%' AND Username='" + label1.Text + "' ", conn);
                conn.Open(); SDA.Fill(dt); dataGridView1.DataSource = dt; conn.Close();
                label9.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM ExchangeConvert  where NameSurname LIKE'" + textBox1.Text + "%' AND Date LIKE'"+dateTimePicker2.Text+"%' AND Username='"+label1.Text+"' ", conn);
                conn.Open(); SDA.Fill(dt); dataGridView1.DataSource = dt; conn.Close();
                label9.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dta = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ExchangeConvert Where Date LIKE '%" + dateTimePicker2.Text + "%' AND Username='" + label1.Text + "'", conn);
                conn.Open();
                da.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();
            }
            catch (Exception) { }
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    label6.Text= row.Cells[0].Value.ToString();
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 

            passingtexti = label6.Text;
            Form frm = new print();
            frm.Show();
        }

        private void Raports_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dta = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ExchangeConvert Where Tel LIKE'%" + textBox3.Text + "%'", conn);
                conn.Open();
                da.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();
                label9.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DataTable dta = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ExchangeConvert Where status='true'", conn);
                conn.Open();
                da.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();
                label9.Text = dataGridView1.RowCount.ToString();
            }
            else
            {
                DataTable dta = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM ExchangeConvert Where Date LIKE '%" + dateTimePicker2.Text + "%' AND Username='" + label1.Text + "'", conn);
                conn.Open();
                da.Fill(dta);
                dataGridView1.DataSource = dta;
                conn.Close();
                label9.Text = dataGridView1.RowCount.ToString();
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            kal();
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            kal();
        }
    }
}


