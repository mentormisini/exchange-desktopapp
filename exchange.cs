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
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Threading;

namespace ExchangeSoftware
{
    public partial class exchange : Form
    {
        public exchange()
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
        Bitmap BackBmp;
        Bitmap BackImg;
        Graphics memoryGraphics;

        private void InitAppearance()
        {
            //Added performance improvements by caching the image.  Only decodes once here at startup

            BackImg = Properties.Resources.Background;
            BackBmp = new Bitmap(BackImg.Width, BackImg.Height);
            memoryGraphics = Graphics.FromImage(BackBmp);

            memoryGraphics.DrawImage(BackImg, 0, 0, BackImg.Width, BackImg.Height);

            // Slow
            //BackgroundImage = Resources.Background;


            // Fast
            BackgroundImage = BackBmp;
        }
        private void displayid()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(ID) + 1 FROM ExchangeConvert", conn);
            
            label15.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }
        public static string pass;
        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //
        private void exchange_Load(object sender, EventArgs e)
        {

           

            try
            {
                label1.Text = Form1.passingtext;
                button1.PerformClick();
                button12.PerformClick();

                //
                displayid();
                //search suggest
              
                SqlCommand kompania;
                SqlDataReader drr;
                kompania = new SqlCommand("SELECT namesurname FROM ExchangeConvert", conn); // per emrin mbiemrin
                conn.Open();
                drr = kompania.ExecuteReader();
                AutoCompleteStringCollection Collection1 = new AutoCompleteStringCollection();
                while (drr.Read())
                {
                    Collection1.Add(drr.GetString(0));

                }
                textBox8.AutoCompleteCustomSource = Collection1;

                drr.Close();
                conn.Close();
                textBox3.Select();

                button1.PerformClick();


            }
            catch (Exception) { }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm = new Menu();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSlateGray;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
            textBox1.Text = "EUR";
            textBox10.Text = "EUR";
            textBox6.Text = "CHF";
           
            pictureBox20.Image = Properties.Resources.eur;
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtaa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("SELECT course,achat,vente FROM courses where Money='" + textBox1.Text + "'", conn);
            conn.Open();
            daa.Fill(dtaa);
            dataGridView1.DataSource = dtaa;
        
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        


        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.LightSlateGray;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
            textBox1.Text = "USD";
            textBox10.Text = "USD";
            textBox6.Text = "CHF";
            pictureBox20.Image = Properties.Resources.USB;
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

         
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
     
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           


        }
        
      
        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox7.Text = row.Cells[0].Value.ToString();
                    if (textBox2.Text == "ACHAT")
                    {
                        textBox4.Text = row.Cells[1].Value.ToString();

                    }
                    else
                    {
                        textBox4.Text = row.Cells[2].Value.ToString();
                    }
                }

                kalkulimitotalit();

            }
            catch (Exception) { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView2_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
         
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.LightSlateGray;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.WhiteSmoke;
            textBox1.Text = "GBP";
            textBox10.Text = "GBP";
            textBox6.Text = "CHF";
            pictureBox20.Image = Properties.Resources.GBP;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

           
        }
        
        
        
        


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_2(object sender, EventArgs e)
        {

           
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
          
            int number;
            bool result = Int32.TryParse(textBox3.Text, out number);
            if (number <= 1000) // me e vogel se 1000
            {
                
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[0, i].Value.ToString() == "Base-A")
                    {
                        dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(10, i));
                        break;
                    }
                }
                textBox7.BackColor = Color.LightSlateGray;
                groupBox1.Visible = false;
                label16.Text = "False";
                button10.Focus();
                

            }
            if (number >= 1000) // me e madhe se 1000
            {
                
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1[0, i].Value.ToString() == "B")
                    {
                        dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(10, i));
                        break;
                    }
                }
                textBox7.BackColor = Color.Firebrick;
                
                label16.Text = "False";
                groupBox1.Visible = false;    
                button10.Focus();
                groupBox1.ResetText();
            }
            if (number >= 5000)
            {
               
                groupBox1.Visible = Enabled;
                label16.Text = "True";
                textBox12.Select();
           
            }
            
         
        }

        private void textBox8_KeyPress_1(object sender, KeyPressEventArgs e)
        {
    
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void kalkulimitotalit()
        {
            try
            {
                if (textBox2.Text == "ACHAT")
                {
                    double q, w, t;
                    q = double.Parse(textBox3.Text);
                    w = double.Parse(textBox4.Text);

                    t = q * w;
                    textBox5.Text = t.ToString("#0.00");
                }
                else if (textBox2.Text == "VENTE")
                {
                    double q, w, t;
                    q = double.Parse(textBox3.Text);
                    w = double.Parse(textBox4.Text);
                    t = q / w;
                    textBox5.Text = t.ToString("#0.00");

                }
            }
            catch (Exception) { }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void exchange_MouseUp(object sender, MouseEventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                    pictureBox14.Visible = true;
                    pictureBox15.Visible = false;
                    textBox3.Clear();
                    textBox5.Clear();
                    textBox2.Text = "ACHAT";
                    if (textBox2.Text == "ACHAT")
                    {

                        dataGridView1.Columns["ACHAT"].DefaultCellStyle.BackColor = Color.Green;
                        dataGridView1.Columns["ACHAT"].DefaultCellStyle.ForeColor = Color.White;
                        dataGridView1.Columns["VENTE"].DefaultCellStyle.BackColor = Color.White;

                        string text1 = textBox10.Text;
                        textBox10.Text = textBox6.Text;
                        textBox10.Text = textBox6.Text;
                        textBox6.Text = text1;
                        button12.BackColor = Color.Green;
                        button12.ForeColor = Color.White;
                        button13.BackColor = Color.FromArgb(224, 224, 224);

                }
            }
            catch (Exception) { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox15.Visible = true;
            pictureBox14.Visible = false;
            textBox3.Clear();
            textBox5.Clear();
            textBox2.Text = "VENTE";
            if (textBox2.Text == "VENTE")
            {

                dataGridView1.Columns["VENTE"].DefaultCellStyle.BackColor = Color.Gold;
                dataGridView1.Columns["ACHAT"].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Columns["ACHAT"].DefaultCellStyle.ForeColor = Color.Black;
                string text1 = textBox10.Text;
                textBox10.Text = textBox6.Text;
                textBox10.Text = textBox6.Text;
                textBox6.Text = text1;

                button12.BackColor = Color.FromArgb(224, 224, 224);
                button13.BackColor = Color.Gold;
                button12.ForeColor = Color.Black;


            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
          


        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            
        }
    
        private void button10_Click_3(object sender, EventArgs e)
        {
            try
            {
       
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO ExchangeConvert (Username,Date,Type,Base,Moneyinserted,Moneyvalue,Moneyinserted2,Moneyinput,Moneyconverted,idclient,namesurname,nationalite,tp,nodepiece,exp,tel,adresse,datedn,remarque,status) VALUES (@Username,@Date,@Type,@Base,@Moneyinserted,@Moneyvalue,@Moneyinserted2,@Moneyinput,@Moneyconverted,@idclient,@namesurname,@nationalite,@tp,@nodepiece,@exp,@tel,@adresse,@datedn,@remarque,@status)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Username", label1.Text);
                    cmd.Parameters.AddWithValue("@Date", label14.Text);
                    cmd.Parameters.AddWithValue("@Type", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Base", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Moneyinserted", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Moneyvalue", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Moneyinserted2", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Moneyinput", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Moneyconverted", textBox5.Text);
                    cmd.Parameters.AddWithValue("@idclient", textBox12.Text);
                    cmd.Parameters.AddWithValue("@namesurname", textBox8.Text);
                    cmd.Parameters.AddWithValue("@nationalite", textBox13.Text);
                    cmd.Parameters.AddWithValue("@tp", textBox14.Text);
                    cmd.Parameters.AddWithValue("@nodepiece", textBox15.Text);
                    cmd.Parameters.AddWithValue("@exp", maskedTextBox2.Text);
                    cmd.Parameters.AddWithValue("@tel", textBox9.Text);
                    cmd.Parameters.AddWithValue("@adresse", textBox11.Text);
                    cmd.Parameters.AddWithValue("@datedn", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@remarque", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@status", label16.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Enregistré avec succès :)");
                    button10.Enabled = false;
                    button2.Enabled = true;

            }


            catch (Exception)
            {
                MessageBox.Show("vous avez fait une erreur, redémarrez le formulaire et créez à nouveau");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("dd-MM-yyy HH:mm:ss");
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
         

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
         

        }

        private void label2_Click(object sender, EventArgs e)
        {
            displayid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new exchange();
            frm.Show();
            this.Close();

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.LightSlateGray;
            button6.BackColor = Color.WhiteSmoke;
            textBox1.Text = "C_USD";
            textBox10.Text = "C_USD";
            textBox6.Text = "CHF";
            pictureBox20.Image = Properties.Resources.CANADA;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
            button2.BackColor = Color.WhiteSmoke;
            button3.BackColor = Color.WhiteSmoke;
            button4.BackColor = Color.WhiteSmoke;
            button5.BackColor = Color.WhiteSmoke;
            button6.BackColor = Color.LightSlateGray;
            textBox1.Text = "A_USD";
            textBox10.Text = "A_USD";
            textBox6.Text = "CHF";
            pictureBox20.Image = Properties.Resources.AUS;
        }

        private void button8_Click(object sender, EventArgs e)
        {


            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);
            try
            {
                this.ExchangeConvertTableAdapter.FillBy(this.newdataset.ExchangeConvert, ((int)(System.Convert.ChangeType(label15.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.Refresh();
            this.reportViewer1.LocalReport.Print();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox8_KeyPress_2(object sender, KeyPressEventArgs e)
        {
          
        
          
}

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox8_Leave_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT tel,adresse,datedn from ExchangeConvert where NameSurname=@NAmeSurname", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Username", label1.Text);
                cmd.Parameters.AddWithValue("@Date", label14.Text);
                cmd.Parameters.AddWithValue("@Type", textBox2.Text);
                cmd.Parameters.AddWithValue("@Base", textBox7.Text);
                cmd.Parameters.AddWithValue("@Moneyinserted", textBox10.Text);
                cmd.Parameters.AddWithValue("@Moneyvalue", textBox4.Text);
                cmd.Parameters.AddWithValue("@Moneyinserted2", textBox6.Text);
                cmd.Parameters.AddWithValue("@Moneyinput", textBox3.Text);
                cmd.Parameters.AddWithValue("@Moneyconverted", textBox5.Text);
                cmd.Parameters.AddWithValue("@namesurname", textBox8.Text);
                cmd.Parameters.AddWithValue("@tel", textBox9.Text);
                cmd.Parameters.AddWithValue("@adresse", textBox11.Text);
                cmd.Parameters.AddWithValue("@datedn", maskedTextBox1.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Enregistré avec succès :)");
                button10.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception) { }
        }

        private void fillByToolStripButton_Click_2(object sender, EventArgs e)
        {
            

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            

        }
       
        private void button2_Click_2(object sender, EventArgs e)
        {
          
            Form frm = new Exchangeprint();
            pass = label15.Text;
            frm.Show();
     
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
        }

        private void exchange_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                e.SuppressKeyPress = true;
                button10.Focus();
              
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT namesurname,nationalite,tp,nodepiece,exp,tel,adresse,datedn,remarque from ExchangeConvert where idclient=@idclient", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@idclient", textBox12.Text);


                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr["namesurname"].ToString();
                    textBox13.Text = dr["nationalite"].ToString();
                    textBox14.Text = dr["tp"].ToString();
                    textBox15.Text = dr["nodepiece"].ToString();
                    maskedTextBox2.Text = dr["exp"].ToString();
                    textBox9.Text = dr["tel"].ToString();
                    textBox11.Text = dr["adresse"].ToString();
                    maskedTextBox1.Text = dr["datedn"].ToString();
                    comboBox1.Text = dr["remarque"].ToString();

                }
                conn.Close();
            }
            catch (Exception) { }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button11.PerformClick();
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
          
        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click_3(object sender, EventArgs e)
        {
           

        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(idclient)  FROM ExchangeConvert", conn);

            label18.Text = "le dernier ID:Client " + cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox11.Clear();
            comboBox1.Text = "";
        }

        private void textBox3_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
