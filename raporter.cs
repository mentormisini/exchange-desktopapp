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
    public partial class raporter : Form
    {
        public raporter()
        {
            InitializeComponent();
        }
        //conectimi
        SqlConnection conn = new SqlConnection(connection.konektimi());
        //
        private void raporter_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.passingtext;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            display();
        }

          private void display()
        {
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *From rapporter WHERE Date='" + dateTimePicker1.Text + "' AND Utilisateur='" + label1.Text + "'", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO rapporter(Date,Utilisateur,Rapporter) VALUES (@Date,@Utilisateur,@Rapporter)",conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Utilisateur", label1.Text);
                cmd.Parameters.AddWithValue("@Rapporter", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Envoyer avec succès");
                conn.Close();
                display();
                
            }
            catch (Exception) { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("supprimer", "êtes-vous sûr !!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("DELETE FROM rapporter WHERE ID='" + label3.Text+ "'", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "rapporter");
                    dataGridView1.DataSource = ds.Tables["rapporter"];
                    MessageBox.Show("La suppression à été effectuée avec succès");            
                    conn.Close();
                    Form frm = new raporter();
                    frm.Show();
                    this.Close();
                }
                catch (Exception)
                {

                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                label3.Text = row.Cells[1].Value.ToString();
              
            }
        }
    }
}
