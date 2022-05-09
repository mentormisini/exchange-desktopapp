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
using System.Data.Sql;
using System.Reflection;

namespace ExchangeSoftware
{
    public partial class admin : Form
    {
        public admin()
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
        public void displayworkers()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM workers", conn);
            conn.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //
        private void admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newdataset.ExchangeConvert' table. You can move, or remove it, as needed.
           
            //displayworkers
            displayworkers();

            dataGridView4.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridView4, true, null);
            //raporti
            DataTable dtt = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT *FROM rapporter", conn);
            conn.Open();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;
            conn.Close();
            //
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM ExchangeConvert WHERE Date BETWEEN'" + dateTimePicker3.Text + "' AND '" + dateTimePicker4.Text + "' AND Username='" + textBox4.Text + "'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView4.DataSource = dt; conn.Close();
                button3.PerformClick();
            }
            catch (Exception)
            {

            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO workers (username,password) VALUES (@username,@password)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Ajouter avec sucess!");
                displayworkers();
            }
            catch (Exception)
            {

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label3.Text = row.Cells[1].Value.ToString();
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
               
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("supprimer", "êtes-vous sûr !!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("DELETE FROM workers WHERE id='" + label3.Text + "'", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "workers");
                    dataGridView1.DataSource = ds.Tables["workers"];
                    MessageBox.Show("La suppression à été effectuée avec succès");
                    conn.Close();
                    Form frm = new admin();
                    frm.Show();
                    this.Close();
                }
                catch (Exception)
                {

                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("UPDATE workers set username='"+textBox1.Text+"',password='"+textBox2.Text+"' WHERE id='" + label3.Text + "'", conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "workers");
                dataGridView1.DataSource = ds.Tables["workers"];
                MessageBox.Show("La modifier à été effectuée avec succès");
                conn.Close();
                Form frm = new admin();
                frm.Show();
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM rapporter  where Date LIKE'" + dateTimePicker1.Text + "%'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView2.DataSource = dt; conn.Close();

            }
            catch (Exception)
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM rapporter  where Utilisateur LIKE'" + textBox3.Text + "%'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView2.DataSource = dt; conn.Close();

            }
            catch (Exception)
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
                decimal euroachat = 0, 
                        eurovente = 0,
                        usdachat = 0,
                        usdvente = 0,
                        chfachat = 0,
                        chfvente = 0,
                        gbpachat = 0,
                        gbpvente = 0,
                        cusdachat = 0,
                        cusdvente = 0,
                        ausdachat = 0,
                        ausdvente = 0;
            try
            {

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[5].Value == "EUR")
                    {
                        euroachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[7].Value == "EUR")
                    {
                        eurovente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }
                    //usd
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[5].Value == "USD")
                    {
                        usdachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[7].Value == "USD")
                    {
                        usdvente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }
                    //usd

                    //chf
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[7].Value == "CHF")
                    {
                        chfvente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }

                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[5].Value == "CHF")
                    {
                        chfachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }


                    //chf

                    //gbp pound
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[5].Value == "GBP")
                    {
                        gbpachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[7].Value == "GBP")
                    {
                        gbpvente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }
                    //

                    //C_USD
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[5].Value == "C_USD")
                    {
                        cusdachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[7].Value == "C_USD")
                    {
                        cusdvente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }
                    //

                    //aus
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView4.Rows[i].Cells[5].Value == "A_USD")
                    {
                        ausdachat += Convert.ToDecimal(dataGridView4.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView4.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView4.Rows[i].Cells[7].Value == "A_USD")
                    {
                        ausdvente += Convert.ToDecimal(dataGridView4.Rows[i].Cells[9].Value);
                    }
                }
                textBox8.Text = euroachat.ToString("#,0.00"); //eur
                textBox10.Text = eurovente.ToString("#,0.00");

                textBox6.Text = usdachat.ToString("#,0.00");//usd
                textBox12.Text = usdvente.ToString("#,0.00");

                textBox7.Text = chfachat.ToString("#,0.00"); //chf
                textBox13.Text = chfvente.ToString("#,0.00");

                textBox5.Text = gbpachat.ToString("#,0.00"); //gbp
                textBox14.Text = gbpvente.ToString("#,0.00");

                textBox11.Text = cusdachat.ToString("#,0.00"); //C_usd
                textBox15.Text = cusdachat.ToString("#,0.00");

                textBox9.Text = ausdachat.ToString("#,0.00"); //aus_usd
                textBox16.Text = ausdvente.ToString("#,0.00");




            }
            catch(Exception) { }
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM ExchangeConvert WHERE Date BETWEEN'" + dateTimePicker3.Text + "' AND '" + dateTimePicker4.Text + "' AND Username='"+textBox4.Text+"'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView4.DataSource = dt; conn.Close();
                button3.PerformClick();
            }
            catch(Exception)
            {

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT *FROM ExchangeConvert WHERE Username LIKE'%" + textBox4.Text + "%'", conn);
                conn.Open(); SDA.Fill(dt); dataGridView4.DataSource = dt; conn.Close();
            }
            catch (Exception)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
