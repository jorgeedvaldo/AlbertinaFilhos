namespace AlbertinaFilhos
{
    partial class Facturacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
        
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
            this.FacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BDPastelariaDataSet = new AlbertinaFilhos.BDPastelariaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FacturaTableAdapter = new AlbertinaFilhos.BDPastelariaDataSetTableAdapters.FacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // FacturaBindingSource
            // 
            this.FacturaBindingSource.DataMember = "Factura";
            this.FacturaBindingSource.DataSource = this.BDPastelariaDataSet;
            // 
            // BDPastelariaDataSet
            // 
            this.BDPastelariaDataSet.DataSetName = "BDPastelariaDataSet";
            this.BDPastelariaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(755, 397);
            this.reportViewer1.TabIndex = 0;
            // 
            // FacturaTableAdapter
            // 
            this.FacturaTableAdapter.ClearBeforeFill = true;
            // 
            // Facturacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 477);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Facturacao";
            this.Resizable = false;
            this.Text = "Apresentação da factura de venda";
            this.Load += new System.EventHandler(this.Facturacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FacturaBindingSource;
        private BDPastelariaDataSet BDPastelariaDataSet;
        private BDPastelariaDataSetTableAdapters.FacturaTableAdapter FacturaTableAdapter;
    }
}