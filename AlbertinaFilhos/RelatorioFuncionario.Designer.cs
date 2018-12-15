namespace AlbertinaFilhos
{
    partial class RelatorioFuncionario
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BDPastelariaDataSet = new AlbertinaFilhos.BDPastelariaDataSet();
            this.FuncionarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FuncionarioTableAdapter = new AlbertinaFilhos.BDPastelariaDataSetTableAdapters.FuncionarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncionarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FuncionarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AlbertinaFilhos.Report8.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(749, 377);
            this.reportViewer1.TabIndex = 0;
            // 
            // BDPastelariaDataSet
            // 
            this.BDPastelariaDataSet.DataSetName = "BDPastelariaDataSet";
            this.BDPastelariaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FuncionarioBindingSource
            // 
            this.FuncionarioBindingSource.DataMember = "Funcionario";
            this.FuncionarioBindingSource.DataSource = this.BDPastelariaDataSet;
            // 
            // FuncionarioTableAdapter
            // 
            this.FuncionarioTableAdapter.ClearBeforeFill = true;
            // 
            // RelatorioFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 457);
            this.Controls.Add(this.reportViewer1);
            this.MinimizeBox = false;
            this.Name = "RelatorioFuncionario";
            this.Resizable = false;
            this.Text = "Relatorio dos funcionários";
            this.Load += new System.EventHandler(this.RelatorioFuncionario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BDPastelariaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuncionarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FuncionarioBindingSource;
        private BDPastelariaDataSet BDPastelariaDataSet;
        private BDPastelariaDataSetTableAdapters.FuncionarioTableAdapter FuncionarioTableAdapter;
    }
}