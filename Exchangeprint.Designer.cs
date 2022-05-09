namespace ExchangeSoftware
{
    partial class Exchangeprint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exchangeprint));
            this.ExchangeConvertBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.newdataset = new ExchangeSoftware.newdataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ExchangeConvertTableAdapter = new ExchangeSoftware.newdatasetTableAdapters.ExchangeConvertTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeConvertBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newdataset)).BeginInit();
            this.SuspendLayout();
            // 
            // ExchangeConvertBindingSource
            // 
            this.ExchangeConvertBindingSource.DataMember = "ExchangeConvert";
            this.ExchangeConvertBindingSource.DataSource = this.newdataset;
            // 
            // newdataset
            // 
            this.newdataset.DataSetName = "newdataset";
            this.newdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ExchangeConvertBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExchangeSoftware.a4print.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ExchangeConvertTableAdapter
            // 
            this.ExchangeConvertTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(466, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 2;
            // 
            // Exchangeprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Exchangeprint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPRIMER";
            this.Load += new System.EventHandler(this.Exchangeprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeConvertBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newdataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ExchangeConvertBindingSource;
        private newdataset newdataset;
        private newdatasetTableAdapters.ExchangeConvertTableAdapter ExchangeConvertTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
    }
}