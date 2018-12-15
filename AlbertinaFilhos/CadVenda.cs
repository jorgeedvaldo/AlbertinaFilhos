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
    public partial class CadVenda : MetroFramework.Forms.MetroForm
    {
        public CadVenda()
        {
            InitializeComponent();
            metroComboBox2.DataSource = bd.RetornaTabela("SELECT * FROM Produto");
            metroComboBox2.DisplayMember = "Nome";
            metroComboBox2.ValueMember = "Cod";
            
            if (DateTime.Now.Minute < 10)
            {
                metroLabel5.Text = DateTime.Now.Hour + " : 0" + DateTime.Now.Minute;
            }
            else
            {
                metroLabel5.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute;
            }
        }
        int Valor = 0;
        Bd bd = new Bd();
        public Form1 principal;
        String Descricao = "Venda Normal";

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = bd.TemLetras(metroTextBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(label7.Text )<0){
                    Convert.ToInt32("jhbgjbhj");
                }

                    DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                bd.ExecutarComando("INSERT INTO Venda(Data, Hora, NomeCliente, CodFuncionario, ValorCliente) VALUES ('" + metroDateTime1.Value + "','" + metroLabel5.Text + "','" + metroTextBox1.Text + "'," + principal.IdFuncionario + ", " + metroTextBox2.Text + ")");
                String ultimoCodVenda = bd.RetornaDados("SELECT Max(Cod) FROM Venda");
                //pergunta se deseja efectuar a operação
                    
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            int QtdActual = Convert.ToInt32(bd.RetornaDados("SELECT Qtd FROM Produto WHERE Cod = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + ""));
                            //Inserindo os dados na tabela de venda
                            bd.ExecutarComando("INSERT INTO ProdutoVendido(CodVenda, CodProduto, Valor, Qtd) VALUES (" + ultimoCodVenda + ", " + dataGridView1.Rows[i].Cells[0].Value.ToString() + ", " + dataGridView1.Rows[i].Cells[2].Value.ToString() + ", " + dataGridView1.Rows[i].Cells[3].Value.ToString() + ")");
                            //alterando a qtd do stock do produto                   **Operação para descontar no Stock**
                            bd.ExecutarComando("UPDATE Produto SET Qtd = " + (QtdActual - Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString())) + " WHERE Cod = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + "");
                            //Inserindo os dados na tabela de factura
                            bd.ExecutarComando("INSERT INTO Factura(CodFactura, NomeCliente, Descricao, Conteudo, Qtd, DataFeita, DataEntrega, NomeFuncionario, CodFuncionario, Valor) VALUES('V" + ultimoCodVenda + "','" + metroTextBox1.Text + "','" + Descricao + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + metroDateTime1.Value + "','" + metroDateTime1.Value + "','" + principal.NomeFuncionario + "'," + principal.IdFuncionario + ", " + dataGridView1.Rows[i].Cells[2].Value.ToString() + ")");
                        }
                        MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (metroRadioButton1.Checked)
                        {
                            Facturacao facturacao = new Facturacao(("V" + ultimoCodVenda), metroTextBox2.Text, label8.Text);
                            facturacao.Show();
                            
                        }
                        this.LimparCampos();
                    }
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                    //cancelar a operação
                DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja remover o produto " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString()+ " da sacola?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yn == DialogResult.Yes)
                {
                    Valor -= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString()) * Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                    label8.Text = "" + (Valor);
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                } 
                
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Por favor seleccione o produto que deseja remover.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text == "" || bd.TemLetras(metroTextBox3.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Digite a quantidade antes de prosseguir.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                try
                {
                    int QtdDesejada = Convert.ToInt32(metroTextBox3.Text);
                    int QtdActual = Convert.ToInt32(bd.RetornaDados("Select Qtd FROM Produto WHERE Cod = " + metroComboBox2.SelectedValue + ""));

                    if (QtdActual < QtdDesejada)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "A quantidade deste produto desejada pelo cliente é menor que a quantidade produto existente no stock, por favor verifique a quantidade ou remova este produto.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        String PrecoProduto = bd.RetornaDados("Select Preco FROM Produto WHERE Cod = " + metroComboBox2.SelectedValue + "");
                        string[] ListaProduto = new string[] { metroComboBox2.SelectedValue.ToString(), metroComboBox2.Text, PrecoProduto, metroTextBox3.Text };
                        dataGridView1.Rows.Add(ListaProduto);
                        Valor += Convert.ToInt32(dataGridView1.Rows[(dataGridView1.Rows.Count - 1)].Cells[2].Value.ToString()) * Convert.ToInt32(dataGridView1.Rows[(dataGridView1.Rows.Count - 1)].Cells[3].Value.ToString());
                        label8.Text = "" + (Valor);
                        metroTextBox3.Text = "";
                    }
                }
                catch {
                    MetroFramework.MetroMessageBox.Show(this, "A quantidade introduzida é muito grande.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            if(!bd.TemLetras(metroTextBox2.Text)){
                label7.Text = "" + (Convert.ToInt32(metroTextBox2.Text) - Valor);
            }else{
                int index = metroTextBox2.Text.Length;
                label7.Text = "0";

            }
        }
        private void LimparCampos() {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            dataGridView1.Rows.Clear();

        }
    }
}
