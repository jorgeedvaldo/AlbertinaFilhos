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
    public partial class ConsultarEncomenda : MetroFramework.Forms.MetroForm
    {
        String Pesquisa = "*";
        Bd bd = new Bd();
        public Form1 principal;
        public ConsultarEncomenda()
        {
            InitializeComponent();
            metroGrid1.DataSource = bd.RetornaTabela("SELECT "+this.Pesquisa+" FROM Factura WHERE CodFactura NOT LIKE 'V%'");

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código da factura":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = false;
                    try
                    {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'V%'");
                        comboBox1.DisplayMember = "CodFactura";
                    }
                    catch { }
                    break;
                case "Data de entrega":
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND DataEntrega LIKE '%"+metroDateTime1.Value.ToShortDateString()+"%'");
                    }
                    catch { }
                    break;
                case "Data feita":
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                    }
                    catch { }
                    break;
                default:
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroDateTime1.Visible = false;
                    metroTextBox1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%'");
                    }
                    catch { }
                    break;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código da factura":
                    
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND CodFactura LIKE '%" + comboBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Data de entrega":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND DataEntrega LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                    }
                    catch { }
                    break;
                case "Data feita":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                    }
                    catch { }
                    break;
                case "Nome do cliente":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND NomeCliente LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Conteúdo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND Conteudo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Quantidade":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Factura WHERE CodFactura NOT LIKE 'V%' AND Qtd LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancelar a operação
            DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja cancelar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (yn == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String CodVenda = "";
                for (int i = 1; i < metroGrid1.SelectedRows[0].Cells[1].Value.ToString().Length; i++)
                {
                    CodVenda += metroGrid1.SelectedRows[0].Cells[1].Value.ToString()[i];
                }
                //pergunta se deseja efectuar a operação
                DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yn == DialogResult.Yes)
                {
                    bd.ExecutarComando("DELETE FROM Factura WHERE CodFactura = '" + metroGrid1.SelectedRows[0].Cells[1].Value.ToString() + "'");
                    bd.ExecutarComando("DELETE FROM EncomendaFeita WHERE CodEncomenda = " + CodVenda + "");
                    bd.ExecutarComando("DELETE FROM Encomenda WHERE Cod = " + CodVenda + "");
                    MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                metroGrid1.DataSource = bd.RetornaTabela("SELECT "+this.Pesquisa+" FROM Factura WHERE CodFactura NOT LIKE 'V%'");

            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique marcou alguma encomenda.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
