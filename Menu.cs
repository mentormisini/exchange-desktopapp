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
using ExchangeSoftware.Properties;

namespace ExchangeSoftware
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Size = new Size(1200, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        Bitmap BackBmp;
        Bitmap BackImg;
        Graphics memoryGraphics;

        private void InitAppearance()
        {
            //Added performance improvements by caching the image.  Only decodes once here at startup

            BackImg = Resources.Background;
            BackBmp = new Bitmap(BackImg.Width, BackImg.Height);
            memoryGraphics = Graphics.FromImage(BackBmp);

            memoryGraphics.DrawImage(BackImg, 0, 0, BackImg.Width, BackImg.Height);

            // Slow
            //BackgroundImage = Resources.Background;


            // Fast
            BackgroundImage = BackBmp;
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

        public static string passingtext;
        public void displaydata()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT EUR,DOLLARS,CHF,POUND,C_USD,A_USD from money_stock where date=@date AND useri=@useri", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@useri", label1.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    label7.Text = dr["EUR"].ToString();
                    label8.Text = dr["DOLLARS"].ToString();
                    label9.Text = dr["CHF"].ToString();
                    label10.Text = dr["POUND"].ToString();
                    label11.Text = dr["C_USD"].ToString();
                    label12.Text = dr["A_USD"].ToString();
                }
                conn.Close();
            }
            catch(Exception msg) { MessageBox.Show(msg.ToString()); }
        }

        public void workermoney()
        {
            try
            {
                DataTable dtaa = new DataTable();
                SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM ExchangeConvert where Username='" + label1.Text + "'AND Date LIKE'" + dateTimePicker1.Text + "%'", conn);
                conn.Open();
                daa.Fill(dtaa);
                dataGridView1.DataSource = dtaa;
                conn.Close();

               moneyclass klasa = new moneyclass();
               klasa.data(dataGridView1, label1, dateTimePicker1);
                decimal eurachat = 0,
                        eurvente = 0,
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
                    
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                   
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[5].Value == "EUR")
                    {
                        eurachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }
                    if((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[7].Value == "EUR")
                    {
                        eurvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }
                    //usd
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[5].Value == "USD")
                    {
                        usdachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[7].Value == "USD")
                    {
                        usdvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }
                    //usd

                    //chf
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[7].Value == "CHF")
                    {
                        chfvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }

                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[5].Value == "CHF")
                    {
                        chfachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }


                    //chf

                    //gbp pound
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[5].Value == "GBP")
                    {
                        gbpachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[7].Value == "GBP")
                    {
                        gbpvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }
                    //

                    //C_USD
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[5].Value == "C_USD")
                    {
                        cusdachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[7].Value == "C_USD")
                    {
                        cusdvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }
                    //

                    //aus
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "ACHAT" && (String)dataGridView1.Rows[i].Cells[5].Value == "A_USD")
                    {
                        ausdachat += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }
                    if ((String)dataGridView1.Rows[i].Cells[3].Value == "VENTE" && (String)dataGridView1.Rows[i].Cells[7].Value == "A_USD")
                    {
                        ausdvente += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    }
                    //

                }
                //euro achat
                textBox1.Text = eurachat.ToString("#,0.00");
                double a, b, c;
                a = double.Parse(label7.Text);
                b = double.Parse(textBox1.Text);
                c = a + b;
                textBox1.Text = c.ToString("#,0.00");
                //euro achat

                //euro vente
                textBox2.Text = eurvente.ToString("#,0.00");
                double d, e;
                textBox1.Text = c.ToString();
                d = double.Parse(textBox2.Text);
                e = c - d;
                textBox1.Text = e.ToString("#,0.00");
                //euro vente


                //usd achat
                textBox3.Text = usdachat.ToString("#,0.00");
                double q, w, r;
                q = double.Parse(label8.Text);
                w = double.Parse(textBox3.Text);
                r = q + w;
                textBox3.Text = r.ToString("#,0.00");
                //usd achat

                //usdvente
                textBox4.Text = usdvente.ToString("#,0.00");
                double m, n;
                textBox3.Text = r.ToString();
                m = double.Parse(textBox4.Text);
                n = r - m;
                textBox3.Text = n.ToString("#,0.00");
                //

                //chfachat
                textBox7.Text = chfachat.ToString("#,0.00");
                double j, k, l;
                j = double.Parse(label9.Text);
                k = double.Parse(textBox7.Text);
                l = j + k;
                textBox7.Text = l.ToString("#,0.00");
                //

                //chfvente
                textBox6.Text =chfvente.ToString("#,0.00");
                double y, u;
                textBox7.Text = l.ToString();
                y = double.Parse(textBox6.Text);
                u = l - y;
                textBox7.Text = u.ToString("#,0.00");


                //gbpachat
                textBox5.Text = gbpachat.ToString("#,0.00");
                double x, v, h;
                x = double.Parse(label10.Text);
                v = double.Parse(textBox5.Text);
                h = x + v;
                textBox5.Text = h.ToString("#,0.00");


                //gbpvente
                textBox8.Text = gbpvente.ToString("#,0.00");
                double f, g;
                textBox5.Text = h.ToString();
                f = double.Parse(textBox8.Text);
                g = h - f;
                textBox5.Text = g.ToString("#,0.00");

                //cusdachat
                textBox11.Text = cusdachat.ToString("#,0.00");
                double aa, bb, cc;
                aa = double.Parse(label11.Text);
                bb = double.Parse(textBox11.Text);
                cc = aa + bb;
                textBox11.Text = cc.ToString("#,0.00");

                //cusdvetne
                textBox10.Text = cusdvente.ToString("#,0.00");
                double dd, ee;
                textBox11.Text = cc.ToString();
                dd = double.Parse(textBox10.Text);
                ee = cc - dd;
                textBox11.Text = ee.ToString("#,0.00");

                //ausachat
                textBox9.Text = ausdachat.ToString("#,0.00");
                double qq, ww, tt;
                qq = double.Parse(label12.Text);
                ww = double.Parse(textBox9.Text);
                tt = qq + ww;
                textBox9.Text = tt.ToString("#,0.00");

                //ausdvente
                textBox12.Text = ausdvente.ToString("#,0.00");
                double mm, nn;
                mm = double.Parse(textBox12.Text);
                nn = tt - mm;
                textBox9.Text = nn.ToString("#,0.00");

            }
            catch (Exception) { }
        }

        //public void workerdisplay()
        //{
        //    DataTable dtaa = new DataTable();
        //    SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM worker_schedule where name='"+label1.Text+"'", conn);
        //    conn.Open();
        //    daa.Fill(dtaa);
        //    dataGridView2.DataSource = dtaa;
        //    conn.Close();
        //    List<DataGridViewRow> RowsToDelete = new List<DataGridViewRow>();
        //    foreach (DataGridViewRow row in dataGridView2.Rows)
        //        if (row.Cells[4].Value != null &&
        //            row.Cells[4].Value.ToString() == "True") RowsToDelete.Add(row);
        //    foreach (DataGridViewRow row in RowsToDelete) dataGridView2.Rows.Remove(row);
        //    RowsToDelete.Clear();
        //}
        private void Menu_Load(object sender, EventArgs e)
        {
           
            label1.Text = Form1.passingtext;
            displaydata();

                try
                {

                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(idw as int)),0)+1 from worker_schedule", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                label5.Text = dt.Rows[0][0].ToString();
                displaydata();

                //check button for work

                workermoney();
            }


            catch (Exception) { }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new moneystock();
            frm.Show();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new changecourses();
            frm.Show();
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("INSERT INTO worker_schedule (idw,name,startdate) values('" + label5.Text + "','" + label1.Text + "','" + dateTimePicker2.Text + "')", conn);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //    MessageBox.Show("Enregistrer succes");
            //    workerdisplay();
            //    button5.Enabled = false;
            //    pictureBox8.Visible = false;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
        }

        private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult dialogResult = MessageBox.Show("Es-tu sûr", "", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {


            //        SqlDataAdapter da = new SqlDataAdapter("UPDATE worker_schedule SET enddate = '" + dateTimePicker2.Text+ "', endn='"+label3.Text+"' WHERE name='" + label1.Text + "'", conn);
            //        DataSet ds = new DataSet();
            //        da.Fill(ds, "worker_schedule");
            //        dataGridView2.DataSource = ds.Tables["worker_schedule"];
            //        MessageBox.Show(label1.Text + "  " + "Terminer le décalage à la date sur l'horloge : " + dateTimePicker2.Text);
            //        conn.Close();
            //        button5.Enabled = true;
            //        button5.Text = "Commacer Travail";
            //        workerdisplay();


            //    }
    

            //}


            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message.ToString());
            //}
        }

        private void rafraîchirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void rafraîchirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void rafraîchirToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void rafraîchirToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Close();
        }

        private void deconnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
            this.Close();
        }

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //var uri = "https://www.xe.com";
            //var psi = new System.Diagnostics.ProcessStartInfo();
            //psi.UseShellExecute = true;
            //psi.FileName = uri;
            //System.Diagnostics.Process.Start(psi);
            Form frm = new raportditor();
            frm.Show();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new exchange();
            frm.Show();
            this.Close();
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            Form frm = new raporter();

            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new Raports();
            frm.Show();
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void aiderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CONTACT US \n\n\n" +
                "WEB: mentormisini.com \n\n" +
                "EMAIL : info@mentormisini.com \n\n");
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
