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
    public partial class ConsultarUtilizador : MetroFramework.Forms.MetroForm
    {
        public Form1 principal;
        Bd bd = new Bd();
        String Pesquisa;
        public ConsultarUtilizador()
        {
            InitializeComponent();
            this.Pesquisa = "Cod AS [Código], Nome AS [Nome do utilizador], Cargo, CodFuncionario AS [Código do funcionário]";
            metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador");

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Nome do utilizador":
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = true;                
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE Nome LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Cargo":
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE Cargo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Código do utilizador":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    try
                    {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Utilizador");
                        comboBox1.DisplayMember = "Cod";
                    }
                    catch { }                  
                    break;
                case "Código do funcionário":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    try
                    {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Utilizador");
                        comboBox1.DisplayMember = "CodFuncionario";
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

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Nome do utilizador":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE Nome LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Cargo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE Cargo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Código do utilizador":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE Cod = " + comboBox1.Text + "");
                    }
                    catch { }
                    break;
                case "Código do funcionário":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Utilizador WHERE CodFuncionario = " + comboBox1.Text + "");
                    }
                    catch { }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                //pergunta se deseja efectuar a operação
                DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja efectuar a operação?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yn == DialogResult.Yes)
                {
                    bd.ExecutarComando("DELETE FROM Utilizador WHERE Cod = " + metroGrid1.SelectedRows[0].Cells[0].Value.ToString() + "");                  
                    MetroFramework.MetroMessageBox.Show(this, "Operação efectuada com sucesso.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                metroGrid1.DataSource = bd.RetornaTabela("SELECT "+this.Pesquisa+" FROM Utilizador");

            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Erro ao efectuar a operação, verifique marcou algum utilizador.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
