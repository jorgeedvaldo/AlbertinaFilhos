namespace AlbertinaFilhos
{
    partial class RelatorioVenda
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BDPastelariaDataSet = new AlbertinaFilhos.BDPastelariaDataSet();
            this.FacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FacturaTableAdapter = new AlbertinaFilhos.BDPastelariaDataSetTableAdapters.FacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.FacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(783, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // BDPastelariaDataSet
            // 
            this.BDPastelariaDataSet.DataSetName = "BDPastelariaDataSet";
            this.BDPastelariaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FacturaBindingSource
            // 
            this.FacturaBindingSource.DataMember = "Factura";
            this.FacturaBindingSource.DataSource = this.BDPastelariaDataSet;
            // 
            // FacturaTableAdapter
            // 
            this.FacturaTableAdapter.ClearBeforeFill = true;
            // 
            // RelatorioVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 454);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "RelatorioVenda";
            this.Resizable = false;
            this.Text = "Apresentação de relatório das vendas";
            this.Load += new System.EventHandler(this.RelatorioVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FacturaBindingSource;
        private BDPastelariaDataSet BDPastelariaDataSet;
        private BDPastelariaDataSetTableAdapters.FacturaTableAdapter FacturaTableAdapter;
    }
}