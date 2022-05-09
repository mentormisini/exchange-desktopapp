using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExchangeSoftware
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
            this.Size = new Size(650, 800);
        }

        private void print_Load(object sender, EventArgs e)
        {

            textBox1.Text = Raports.passingtexti;
            // TODO: This line of code loads data into the 'newdataset.ExchangeConvert' table. You can move, or remove it, as needed.
            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);

      


            try
            {
                this.ExchangeConvertTableAdapter.FillBy2(this.newdataset.ExchangeConvert, ((int)(System.Convert.ChangeType(textBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();

       



        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void fillBy2ToolStripButton_Click_1(object sender, EventArgs e)
        {
          

        }

        private void fillBy1ToolStripButton_Click_1(object sender, EventArgs e)
        {
            

        }

        private void fillBy2ToolStripButton_Click_2(object sender, EventArgs e)
        {
         

        }

        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
          
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
