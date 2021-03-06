﻿using System;
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
    public partial class RelatorioProduto : MetroFramework.Forms.MetroForm
    {
        DataTable tb = new DataTable();
        public Form1 principal;
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[1];
        String DataHora = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        public RelatorioProduto(DataTable tb)
        {
            this.tb = tb;
            InitializeComponent();
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("DataHora", this.DataHora);
            this.reportViewer1.LocalReport.SetParameters(p);
        }

        private void RelatorioProduto_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();

            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Produto' table. You can move, or remove it, as needed.
            this.ProdutoTableAdapter.Fill(this.BDPastelariaDataSet.Produto);

            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.ProdutoBindingSource.DataSource = tb;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report5.rdlc";

            // TODO: This line of code loads data into the 'BDPastelariaDataSet.Produto' table. You can move, or remove it, as needed.
            this.reportViewer1.RefreshReport();
        }
    }
}
