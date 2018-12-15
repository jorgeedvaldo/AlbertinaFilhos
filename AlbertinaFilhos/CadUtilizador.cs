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
    public partial class CadUtilizador : MetroFramework.Forms.MetroForm
    {
        public CadUtilizador()
        {
            InitializeComponent();
            metroComboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Funcionario");
            metroComboBox1.DisplayMember = "Nome";
            metroComboBox1.ValueMember = "Cod";
            
        }
        Bd bd = new Bd();
        public Form1 principal = new Form1();


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
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox2.Text != metroTextBox3.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                try {
                    //pergunta se deseja efectuar a operação
                    DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                        //insere os dados na bd
                        bd.ExecutarComando("INSERT INTO Utilizador(Nome, Senha, Cargo, CodFuncionario) VALUES ('" + metroTextBox1.Text + "','" + metroTextBox2.Text + "','" + metroComboBox2.Text + "'," + metroComboBox1.SelectedValue + ")");
                        MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }
                catch {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            int valor = bd.RetornaLinhas("SELECT * FROM Utilizador WHERE Nome = '" + metroTextBox1.Text + "'");
            if (valor == 1)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }


        private void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                metroComboBox2.Text = bd.RetornaDados("SELECT Cargo FROM Funcionario WHERE Cod = " + metroComboBox1.SelectedValue + "");
            }
            catch { }
        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox2.Text == metroTextBox3.Text)
            {
                label2.Visible = false;

            }
            else
            {
                label2.Visible = true;
            }
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox2.Text == metroTextBox3.Text)
            {
                label2.Visible = false;

            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CadUtilizador_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
