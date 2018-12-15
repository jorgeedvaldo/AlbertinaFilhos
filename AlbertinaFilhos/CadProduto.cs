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
    public partial class CadProduto : MetroFramework.Forms.MetroForm
    {
        public CadProduto()
        {
            InitializeComponent();
        }
        Bd bd = new Bd();
        public Form1 principal;

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || bd.TemLetras(metroTextBox2.Text) || bd.TemLetras(metroTextBox3.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    //pergunta se deseja efectuar a operação
                    DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                        //insere os dados na bd
                        bd.ExecutarComando("INSERT INTO Produto(Nome, Preco, Qtd) VALUES ('" + metroTextBox1.Text + "'," + metroTextBox2.Text + "," + metroTextBox3.Text + ")");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (bd.TemLetras(metroTextBox3.Text))
            {
                label3.Visible = true;
            }
            else {
                label3.Visible = false;
            }
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (bd.TemLetras(metroTextBox2.Text))
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            int valor = bd.RetornaLinhas("SELECT * FROM Produto WHERE Nome = '"+metroTextBox1.Text+"'");
            if (valor == 1)
            {
                label2.Visible = true;
            }
            else {
                label2.Visible = false;
            }
        }
    }
}
