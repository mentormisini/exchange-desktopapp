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
    public partial class Exchangeprint : Form
    {
        public Exchangeprint()
        {
            InitializeComponent();
            this.Size = new Size(650, 800);
        }

        private void Exchangeprint_Load(object sender, EventArgs e)
        {
            textBox1.Text = exchange.pass;
            // TODO: This line of code loads data into the 'newdataset.ExchangeConvert' table. You can move, or remove it, as needed.
            this.ExchangeConvertTableAdapter.Fill(this.newdataset.ExchangeConvert);
            
            try
            {
                this.ExchangeConvertTableAdapter.FillBy4(this.newdataset.ExchangeConvert, ((int)(System.Convert.ChangeType(textBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }

        private void fillBy4ToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
