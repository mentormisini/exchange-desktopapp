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


// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ExchangeSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        SqlConnection conn = new SqlConnection(connection.konektimi());

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter cb = new SqlDataAdapter("Select username from workers", conn);
                conn.Open();
                DataTable cm = new DataTable();
                cb.Fill(cm);
                DataRow row = cm.NewRow();
               

                comboBox1.DataSource = cm;
                comboBox1.DisplayMember = "username";
                comboBox1.ValueMember = "id";
                conn.Close();

            }
            catch (Exception)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
        }
        public static string passingtext;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin")
            {
                Form frm = new admin();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Le mot de passe n'est pas correct ou vous n'êtes pas administrateur");
            }
          
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button11.PerformClick();
                
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                string select = "SELECT * FROM workers where username='" + comboBox1.Text + "' AND password='" + this.textBox1.Text + "'";
             
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    passingtext = comboBox1.Text;
                    Form frm = new Menu();
                    frm.Show();
                    this.Hide();
                   
                }
               
                else
                {
                    MessageBox.Show("Erreur de mot de passe, veuillez réessayer ! ");
                    textBox1.Clear();
                }
              
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
