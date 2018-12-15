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
    public partial class CadInfoEncomenda : MetroFramework.Forms.MetroForm
    {
        public CadInfoEncomenda()
        {
            InitializeComponent();
            metroComboBox2.DataSource = bd.RetornaTabela("SELECT * FROM Cliente");
            metroComboBox2.DisplayMember = "Nome";
            metroComboBox2.ValueMember = "Cod";
        }
        public Form1 principal;
        Bd bd = new Bd();

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
            if (bd.TemLetras(metroTextBox1.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    CadEncomenda cadEncomenda = new CadEncomenda(this);
                    cadEncomenda.ShowDialog();
                }
                catch {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = metroComboBox2.SelectedValue.ToString();
                label2.Text = bd.RetornaDados("SELECT Telefone1 FROM Cliente WHERE Cod = " + metroComboBox2.SelectedValue + "");
                label3.Text = bd.RetornaDados("SELECT Sexo FROM Cliente WHERE Cod = " + metroComboBox2.SelectedValue + "");
                label4.Text = bd.RetornaDados("SELECT Bi FROM Cliente WHERE Cod = " + metroComboBox2.SelectedValue + "");
                label5.Text = bd.RetornaDados("SELECT Telefone2 FROM Cliente WHERE Cod = " + metroComboBox2.SelectedValue + "");
            }
            catch { }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = bd.TemLetras(metroTextBox1.Text);
        }
    }
}
