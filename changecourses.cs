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

namespace ExchangeSoftware
{
    public partial class changecourses : Form
    {
        public changecourses()
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


        public static string passingtext;
        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //

        DataTable dt = new DataTable();

        private void changecourses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exchangeDataSet3.courses' table. You can move, or remove it, as needed.

            //SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(IDC as int)),0)+1 from courses", conn);
            //sda.Fill(dt);
            //string[] row = row = new string[] { "Base-A", "0.0000", "0.0000", dt.Rows[0][0].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), Form1.passingtext };
            //dataGridView1.Rows.Add(row);

            //row = new string[] { "B", "0.0000", "0.0000", dt.Rows[0][0].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), Form1.passingtext };
            //dataGridView1.Rows.Add(row);

            //row = new string[] { "C", "0.0000", "0.0000", dt.Rows[0][0].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), Form1.passingtext };
            //dataGridView1.Rows.Add(row);

            //row = new string[] { "D", "0.0000", "0.0000", dt.Rows[0][0].ToString(), DateTime.Now.ToString("dd/MM/yyyy"), Form1.passingtext };
            //dataGridView1.Rows.Add(row);




            label1.Text = Form1.passingtext;

            //  label6.Text = dt.Rows[0][0].ToString();




        }




        private void button1_Click(object sender, EventArgs e)
        {
           
            
                pictureBox1.Visible = true;
                pictureBox1.Image = Properties.Resources.eur;
                label4.Text = "EURO E";

            DataTable dtaa = new DataTable();
                SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC,Money FROM courses where Money='" + button1.Text + "'", conn);
                conn.Open();
                daa.Fill(dtaa);
                dataGridView2.DataSource = dtaa;
                conn.Close();
    
        }

        private void loadafterupdate()
        {
            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC FROM courses where Money='" + label5.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView2.DataSource = dtaa;
            conn.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
          

            pictureBox1.Image = Properties.Resources.USB;
            label4.Text = "USD $";

            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC,Money FROM courses where Money='" + button2.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView2.DataSource = dtaa;
            conn.Close();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            pictureBox1.Image = Properties.Resources.GBP;
            label4.Text = "GBP £";
            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC,Money FROM courses where Money='" + button4.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView2.DataSource = dtaa;
            conn.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (label4.Text == "Sélectionner de l'argent")
            //    {
            //        MessageBox.Show("Sélectionner de l'argent");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {
            //            SqlCommand cmd = new SqlCommand(@"INSERT INTO courses (course,achat,vente,IDC,date,pchange,Money) VALUES ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "')", conn);
            //            conn.Open();
            //            cmd.ExecuteNonQuery();

            //            conn.Close();

            //        }
            //        MessageBox.Show("Courses Enregistre Avec Succes :)");
            //        Form frm = new changecourses();
            //        frm.Show();
            //        this.Close();
            //    }
           


            //}
            //catch (Exception)

            //{
            //    MessageBox.Show("Ajouter Courses");
            //    Form frm = new changecourses();
            //    frm.Show();
            //    this.Close();

            //}
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            //if (dataGridView1.CurrentCell.ColumnIndex == 1 || dataGridView1.CurrentCell.ColumnIndex == 2) //Desired Column
            //{
            //    TextBox tb = e.Control as TextBox;
            //    if (tb != null)
            //    {
            //        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
            //    }
            //}
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //(e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        }

        private void dataGridView1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("UPDATE courses SET achat='" + textBox1.Text + "', vente='" + textBox2.Text + "'where course='" + label3.Text + "' AND IDC='" + label2.Text + "'", conn);
                DataSet dg = new DataSet();
                da.Fill(dg, "courses");
                dataGridView2.DataSource = dg.Tables["courses"];
                MessageBox.Show("C'est modifié avec succès");
                conn.Close();
                loadafterupdate();


            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView2_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView2_CellClick_3(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    label3.Text = row.Cells[0].Value.ToString();
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    label2.Text = row.Cells[3].Value.ToString();
                    label5.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_CellClick_4(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick_5(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    label3.Text = row.Cells[0].Value.ToString();
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    label2.Text = row.Cells[3].Value.ToString();
                    label5.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.CANADA;
            label4.Text = "CANADA USD";

            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC,Money FROM courses where Money='" + button5.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView2.DataSource = dtaa;
            conn.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.AUS;
            label4.Text = "AUSTRIA USD";


            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente,IDC,Money FROM courses where Money='" + button6.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView2.DataSource = dtaa;
            conn.Close();
 
        }

        private void changecourses_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
