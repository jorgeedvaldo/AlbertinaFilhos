using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbertinaFilhos
{
    public partial class RelatorioVenda : MetroFramework.Forms.MetroForm
    {
        DataTable tb = new DataTable();
        public Form1 principal;
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[2];
        String NumeroVenda;
        String DataHora = DateTime.Now.ToShortDateString() +  " " + DateTime.Now.ToLongTimeString();
        public RelatorioVenda(DataTable tb, String NumeroVenda = "")
        {
            this.tb = tb;
            this.NumeroVenda = NumeroVenda;
            InitializeComponent();
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("NumeroVenda", this.NumeroVenda);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("DataHora", this.DataHora);
            
            this.reportViewer1.LocalReport.SetParameters(p);
        }

        private void RelatorioVenda_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();

            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Factura' table. You can move, or remove it, as needed.
            this.FacturaTableAdapter.Fill(this.BDPastelariaDataSet.Factura);

            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.FacturaBindingSource.DataSource = tb;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report3.rdlc";


            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Factura' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }
    }
}
