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
    public partial class raportditor : Form
    {
        public raportditor()
        {
            InitializeComponent();
            this.Size = new Size(650, 800);
        }

        private void raportditor_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy 07:00:00";
            dateTimePicker2.CustomFormat = "dd-MM-yyyy 23:59:59";
            // TODO: This line of code loads data into the 'newdataset.ExchangeConvert' table. You can move, or remove it, as needed.
            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);
            try
            {
                this.ExchangeConvertTableAdapter.FillBy3(this.newdataset.ExchangeConvert, dateTimePicker1.Text, dateTimePicker2.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            this.reportViewer1.RefreshReport();
        }

        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
          

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);
            try
            {
                this.ExchangeConvertTableAdapter.FillBy3(this.newdataset.ExchangeConvert, dateTimePicker1.Text, dateTimePicker2.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        

            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);
            try
            {
                this.ExchangeConvertTableAdapter.FillBy3(this.newdataset.ExchangeConvert, dateTimePicker1.Text, dateTimePicker2.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            this.reportViewer1.RefreshReport();
        }
    }
}
