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
    public partial class CadCliente : MetroFramework.Forms.MetroForm
    {
        public CadCliente()
        {
            InitializeComponent();
        }
        Bd bd = new Bd();
        public Form1 principal;

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(metroTextBox1.Text) || String.IsNullOrEmpty(metroTextBox2.Text) || String.IsNullOrEmpty(metroTextBox3.Text) || String.IsNullOrEmpty(metroComboBox1.Text) || bd.TemLetrasN(metroTextBox3.Text) || bd.TemLetrasN(metroTextBox4.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                try
                {
                    //pergunta se deseja efectuar a operação
                    DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                        //insere os dados da tabela Endereço na bd
                        bd.ExecutarComando("INSERT INTO Endereco(Municipio, Bairro, Rua, Quarteirao, NumeroCasa) VALUES ('" + metroTextBox5.Text + "','" + metroTextBox6.Text + "','" + metroTextBox7.Text + "', '" + metroTextBox8.Text + "', '" + metroTextBox9.Text + "')");
                        //retorna ultimo Id do endereço inserido
                        String ultimoIdEndereco = bd.RetornaDados("SELECT Max(Cod) FROM Endereco");
                        //insere os dados da tabela Cliente na bd
                        bd.ExecutarComando("INSERT INTO Cliente(Nome, Sexo, Bi, Telefone1, Telefone2, CodEndereco) VALUES ('" + metroTextBox1.Text + "','" + metroComboBox1.Text + "','" + metroTextBox2.Text + "','" + metroTextBox3.Text + "', '" + metroTextBox4.Text + "', "+ultimoIdEndereco+")");
                        MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();                      
                    }

                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
                label2.Visible = bd.TemLetrasN(metroTextBox3.Text);
        }

        private void metroTextBox4_TextChanged(object sender, EventArgs e)
        {            
                label3.Visible = bd.TemLetrasN(metroTextBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancelar a operação
            DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja cancelar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yn == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
