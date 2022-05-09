using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ExchangeSoftware
{
    public partial class moneystock : Form
    {
        public moneystock()
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
        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //
        private void textBox1_Enter(object sender, EventArgs e)
        {
           // Process.Start(@"C:\Windows\WinSxS\amd64_microsoft-windows-osk_31bf3856ad364e35_10.0.19041.1_none_60ade0eff94c37fc\osk.exe");
        }

        private void moneystock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exchangeDataSet2.money_stock' table. You can move, or remove it, as needed.
           
            try
            {
                label9.Text = Form1.passingtext;

           
                displaydata();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows.Count >= 1 && dataGridView1.Rows != null)
                    {
                 
                        button5.Enabled = false;
                    }

                }
            }


            catch (Exception) { }
        }

        public void displaydata()
        {
            //load data
            DataTable dta = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM money_stock where date='" + dateTimePicker2.Text + "' AND useri='"+label9.Text+"'", conn);
            conn.Open();
            da.Fill(dta);
            dataGridView1.DataSource = dta;
            conn.Close();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET EUR='" + textBox1.Text + "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO money_stock (date,useri,EUR,DOLLARS,CHF,POUND,C_USD,A_USD) values('" + dateTimePicker2.Text + "','"+label9.Text+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox5.Text+"','"+textBox6.Text+"')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Enregistrer succes");
                displaydata();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET DOLLARS='" + textBox2.Text+"' Where idsm='" + label6.Text + "' AND date='"+dateTimePicker2.Text+"'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    label6.Text = row.Cells[0].Value.ToString();
                    textBox1.Text = row.Cells[3].Value.ToString();
                    textBox2.Text = row.Cells[4].Value.ToString();
                    textBox3.Text = row.Cells[5].Value.ToString();
                    textBox4.Text = row.Cells[6].Value.ToString();
                    textBox5.Text = row.Cells[7].Value.ToString();
                    textBox6.Text = row.Cells[8].Value.ToString();

                }
            }
            catch(Exception) { }
            

         
        }
        
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            displaydata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET CHF='" + textBox3.Text + "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET POUND='" + textBox4.Text + "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET C_USD='" + textBox5.Text + "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET A_USD='" + textBox6.Text + "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                conn.Open();
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("C'est Modifier avec succes");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("UPDATE money_stock SET eur='"+textBox1.Text+"',DOLLARS='"+textBox2.Text+"',CHF='"+textBox3.Text+"',POUND='"+textBox4.Text+"',C_USD='"+textBox5.Text+"',A_USD='"+textBox6.Text+ "' Where idsm='" + label6.Text + "' AND date='" + dateTimePicker2.Text + "'", conn);
                DataSet dg = new DataSet();
                da.Fill(dg, "money_stock");
                dataGridView1.DataSource = dg.Tables["money_stock"];
                MessageBox.Show("C'est modifié avec succès");
                conn.Close();
                Form frm = new moneystock();
                frm.Show();
                this.Close();
              

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void moneystock_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

