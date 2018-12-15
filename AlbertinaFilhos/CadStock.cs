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
    public partial class CadStock : MetroFramework.Forms.MetroForm
    {
        public CadStock()
        {
            InitializeComponent();
            metroComboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Produto");
            metroComboBox1.DisplayMember = "Nome";
            metroComboBox1.ValueMember = "Cod";
            metroRadioButton1.CheckedChanged += new System.EventHandler(metroTextBox3_TextChanged);
        }
        Bd bd = new Bd();
        public Form1 principal = new Form1();
        int Quantidade = 0;

        private void CadStock_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bd.TemLetras(metroTextBox3.Text) || String.IsNullOrEmpty(metroTextBox3.Text))
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                try { 
                    //pergunta se deseja efectuar a operação
                    DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (yn == DialogResult.Yes)
                    {
                        //actualizando os dados do Stock
                        bd.ExecutarComando("UPDATE Produto SET Qtd = " + Quantidade + " WHERE Cod= " + metroComboBox1.SelectedValue + "");
                        MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch {
                    MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique se os dados foram inseridos correctamente.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "(A quantidade actual é de  " + bd.RetornaDados("SELECT Qtd FROM Produto WHERE Cod = " + metroComboBox1.SelectedValue + "") + " unidades.)";
                label1.Visible = true;
            }
            catch {
                label1.Visible = false;
            }
            metroTextBox3.Text = "0";
            Quantidade = 0;
        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            if(bd.TemLetras(metroTextBox3.Text))
            {
                label3.Visible = true;
                label4.Visible = false;
            }
            else
            {
                label3.Visible = false;
                if (!metroRadioButton1.Checked)
                {
                    label4.Text = "Se guardar essas definições a quantidade do actual produto será de " + metroTextBox3.Text + " unidades.";
                    Quantidade = Convert.ToInt32(metroTextBox3.Text);
                    label4.Visible = true;
                }
                else
                {
                    try
                    {
                        int QtdActual = Convert.ToInt32(bd.RetornaDados("SELECT Qtd FROM Produto WHERE Cod = " + metroComboBox1.SelectedValue + ""));
                        int QtdAdicional = Convert.ToInt32(metroTextBox3.Text);
                        int QtdTotal = QtdActual + QtdAdicional;
                        Quantidade = QtdTotal;
                        label4.Text = "Se guardar essas definições a quantidade do actual produto será de "+ QtdTotal + " unidades.";
                        label4.Visible = true;
                    }
                    catch {
                        label4.Visible = false;
                    }
                }
            }         
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
