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
    public partial class RelatorioUsuario : MetroFramework.Forms.MetroForm
    {
        DataTable tb = new DataTable();
        public Form1 principal;
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[1];
        String DataHora = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        public RelatorioUsuario(DataTable tb)
        {
            this.tb = tb;
            InitializeComponent();
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("DataHora", this.DataHora);
            this.reportViewer1.LocalReport.SetParameters(p);
        }

        private void RelatorioUsuario_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();

            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Utilizador' table. You can move, or remove it, as needed.
            this.UtilizadorTableAdapter.Fill(this.BDPastelariaDataSet.Utilizador);

            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.UtilizadorBindingSource.DataSource = tb;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report7.rdlc";

            this.reportViewer1.RefreshReport();
        }
    }
}
