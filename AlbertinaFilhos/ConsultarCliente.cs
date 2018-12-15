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
     
    public partial class ConsultarCliente : MetroFramework.Forms.MetroForm
    {
        String Pesquisa = "Cliente.Cod AS [Código do cliente], Nome, Sexo, Bi AS [Número do bilhete], Telefone1 AS [Telefone principal], Telefone2 AS [Telefone alternativo], Municipio AS [Município], Bairro, Rua, Quarteirao AS [Quarteirão], NumeroCasa AS [Número de casa]";
        Bd bd = new Bd();
        public Form1 principal;
        public ConsultarCliente()
        {
            InitializeComponent();
            metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod");
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(metroComboBox1.Text){
                case "Código do cliente":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    try
                    {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Cliente");
                        comboBox1.DisplayMember = "Cod";
                    }
                    catch { }
                break;
                default:
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod");
                    }
                    catch { }
                break;
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código do cliente":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Cod = " + comboBox1.Text + "");
                    }
                    catch { }
                break;
                case "Nome do cliente":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Nome LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Número do bilhete":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Bi LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Sexo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Sexo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Telefone principal":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Telefone1 LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Telefone alternativo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Cliente.Telefone2 LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Município":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Endereco.Municipio LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Bairro":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Endereco.Bairro LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Rua":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Endereco.Rua LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Quarteirão":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Endereco.Quarteirao LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                break;
                case "Número de casa":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Cliente, Endereco WHERE Cliente.CodEndereco = Endereco.Cod AND Endereco.NumeroCasa LIKE '" + metroTextBox1.Text + "%'");
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
    }
}
