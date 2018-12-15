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
    public partial class AlterarPreco : MetroFramework.Forms.MetroForm
    {
        public AlterarPreco()
        {
            InitializeComponent();
            metroComboBox2.DataSource = bd.RetornaTabela("SELECT * FROM Produto");
            metroComboBox2.DisplayMember = "Nome";
            metroComboBox2.ValueMember = "Cod";
        }
        Bd bd = new Bd();
        public Form1 principal = new Form1();

        private void AlterarPreco_Load(object sender, EventArgs e)
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
            if (metroTextBox2.Text == "" || bd.TemLetras(metroTextBox2.Text))
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
                        //altera os dados na bd
                        bd.ExecutarComando("UPDATE Produto SET Preco = " + metroTextBox2.Text + " WHERE Cod = "+metroComboBox2.SelectedValue+"");
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

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                metroTextBox2.Text = bd.RetornaDados("SELECT Preco FROM Produto WHERE Cod = "+metroComboBox2.SelectedValue+"");
            }
            catch { }
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = bd.TemLetras(metroTextBox2.Text);
        }
    }
}
