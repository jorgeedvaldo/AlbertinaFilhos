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
    public partial class ConsultarVenda : MetroFramework.Forms.MetroForm
    {
        public ConsultarVenda()
        {
            InitializeComponent();
            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'");
        }
        Bd bd = new Bd();
        public Form1 principal;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
            {
                switch (metroComboBox1.Text)
                {
                    case "Código da factura":
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND CodFactura LIKE '%" + metroTextBox1.Text + "%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                        break;
                    case "Nome do produto":
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND Conteudo LIKE '%" + metroTextBox1.Text + "%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                        break;
                    case "Nome do cliente":
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND NomeCliente LIKE '%" + metroTextBox1.Text + "%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                        break;
                    case "Nome do operador":
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND NomeFuncionario LIKE '%" + metroTextBox1.Text + "%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                        break;
                }
            }
            else
            {
                switch (metroComboBox1.Text)
                    {
                        case "Código da factura":
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND CodFactura LIKE '%"+metroTextBox1.Text+"%'");
                            break;
                        case "Nome do produto":
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND Conteudo LIKE '%" + metroTextBox1.Text + "%'");
                            break;
                        case "Nome do cliente":
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND NomeCliente LIKE '%" + metroTextBox1.Text + "%'");
                            break;
                        case "Nome do operador":
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND NomeFuncionario LIKE '%" + metroTextBox1.Text + "%'");
                            break;
                    }
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

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(metroComboBox1.Text){
                case "Código do operador":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    break;
                default:
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = true;
                    metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'");                  
                    break;
            }
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
            {
                metroTextBox1.Text = "";
                metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
            }
            else {
                metroTextBox1.Text = "";
                metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked)
            {
                switch (metroComboBox1.Text)
                {
                    case "Código do operador":
                        try
                        {
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND CodFuncionario = " + comboBox1.Text + " AND DataFeita LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                        }
                        catch { }
                        break;
                }
            }
            else
            {
                switch (metroComboBox1.Text)
                {
                    case "Código do operador":
                        try
                        {
                            metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%' AND CodFuncionario = " + comboBox1.Text + "");
                        }
                        catch { }
                        break;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                        bd.ExecutarComando("DELETE FROM ProdutoVendido WHERE CodVenda = " + CodVenda + "");
                        bd.ExecutarComando("DELETE FROM Venda WHERE Cod = " + CodVenda + "");
                        MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                    metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'");

            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique marcou alguma venda.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!metroRadioButton1.Checked)
            {
                metroGrid1.DataSource = bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'");
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
