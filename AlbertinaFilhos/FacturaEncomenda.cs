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
    public partial class FacturaEncomenda : MetroFramework.Forms.MetroForm
    {
        Bd bd = new Bd();
        public String Cde, Total, ValorCliente, Troco;
        public System.Data.DataTable tb = new System.Data.DataTable();
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[3];
        public FacturaEncomenda(String Cde, String V, String T)
        {
            this.Cde = Cde;
            this.ValorCliente = V;
            this.Total = T;
            this.Troco = "0";
            tb = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura = '" + Cde + "'");
            InitializeComponent();
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Troco", this.Troco);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Total", this.Total);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("ValorPago", this.ValorCliente);
            this.reportViewer1.LocalReport.SetParameters(p);
        }

        private void FacturaEncomenda_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();

            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Factura' table. You can move, or remove it, as needed.
            this.FacturaTableAdapter.Fill(this.BDPastelariaDataSet.Factura);

            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.FacturaBindingSource.DataSource = tb;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report2.rdlc";

            //TODO:
            this.reportViewer1.RefreshReport();
        }
    }
}
