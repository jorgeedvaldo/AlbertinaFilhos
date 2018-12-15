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
    public partial class CadEncomenda : MetroFramework.Forms.MetroForm
    {
        CadInfoEncomenda CIE;
        Bd bd = new Bd();
        String Descricao = "Encomenda";
        public CadEncomenda(CadInfoEncomenda CIE)
        {
            InitializeComponent();
            this.CIE = CIE;
            metroComboBox2.DataSource = bd.RetornaTabela("SELECT * FROM Produto");
            metroComboBox2.DisplayMember = "Nome";
            metroComboBox2.ValueMember = "Cod";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //pergunta se deseja efectuar a operação
                DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yn == DialogResult.Yes)
                {
                bd.ExecutarComando("INSERT INTO Encomenda(DataFeita, DataEntrega, Valor, CodCliente, CodFuncionario, Estado) VALUES ('" + CIE.metroDateTime1.Value + "','" + CIE.metroDateTime2.Value + "'," + CIE.metroTextBox1.Text + ", " + CIE.label1.Text + ", " + CIE.principal.IdFuncionario + ", 'false')");
                String ultimoCodEncomenda = bd.RetornaDados("SELECT Max(Cod) FROM Encomenda");
                
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Inserindo os dados na tabela de Encomenda
                        bd.ExecutarComando("INSERT INTO EncomendaFeita(CodEncomenda, CodProduto, Qtd) VALUES (" + ultimoCodEncomenda + ", " + dataGridView1.Rows[i].Cells[0].Value.ToString() + ", " + dataGridView1.Rows[i].Cells[3].Value.ToString() + ")");
                         //Inserindo os dados na tabela de factura
                        bd.ExecutarComando("INSERT INTO Factura(CodFactura, NomeCliente, Descricao, Conteudo, Qtd, DataFeita, DataEntrega, NomeFuncionario, CodFuncionario, CodCliente) VALUES('E" + ultimoCodEncomenda + "','" + CIE.metroComboBox2.Text + "','" + Descricao + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + CIE.metroDateTime1.Value + "','" + CIE.metroDateTime2.Value + "','" + CIE.principal.NomeFuncionario + "'," + CIE.principal.IdFuncionario + ", " + CIE.label1.Text + ")");
                    }
                    MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(metroRadioButton1.Checked){
                        FacturaEncomenda facturacao = new FacturaEncomenda(("E" + ultimoCodEncomenda), CIE.metroTextBox1.Text, CIE.metroTextBox1.Text);
                        facturacao.Show();
                    }
                    CIE.Close();
                    this.Close();
                }
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text == "" || bd.TemLetras(metroTextBox3.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Digite a quantidade antes de prosseguir.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                     String PrecoProduto = bd.RetornaDados("Select Preco FROM Produto WHERE Cod = " + metroComboBox2.SelectedValue + "");
                        string[] ListaProduto = new string[] { metroComboBox2.SelectedValue.ToString(), metroComboBox2.Text, PrecoProduto, metroTextBox3.Text };
                        dataGridView1.Rows.Add(ListaProduto);
                        metroTextBox3.Text = "";
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "A quantidade introduzida é muito grande.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //cancelar a operação
                DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja remover o produto " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " da sacola?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yn == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }

            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Por favor seleccione o produto que deseja remover.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = bd.TemLetras(metroTextBox3.Text);
        }
    }
}
