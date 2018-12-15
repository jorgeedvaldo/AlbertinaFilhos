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
    public partial class ConsultarFuncionario : MetroFramework.Forms.MetroForm
    {
        String Pesquisa = "*";
        Bd bd = new Bd();
        public Form1 principal;
        public ConsultarFuncionario()
        {
            InitializeComponent();
            metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod");

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

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código do funcionário":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = false;
                    try
                    {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Funcionario");
                        comboBox1.DisplayMember = "Cod";
                    }
                    catch { }
                    break;
                case "Data de nascimento":
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND DataNascimento LIKE '%"+metroDateTime1.Value.ToShortDateString()+"%'");
                    }
                    catch { }
                    break;
                default:
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroDateTime1.Visible = false;
                    metroTextBox1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod");
                    }
                    catch { }
                    break;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código do funcionário":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Cod = " + comboBox1.Text + "");
                    }
                    catch { }
                    break;
                case "Nome do funcionário":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Nome LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Número do bilhete":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.BI LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Sexo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Sexo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Telefone principal":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Telefone1 LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Telefone alternativo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Telefone2 LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Cargo":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Funcionario.Cargo LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Data de nascimento":
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = false;
                    metroDateTime1.Visible = true;
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND DataNascimento LIKE '%" + metroDateTime1.Value.ToShortDateString() + "%'");
                    }
                    catch { }
                break;
                case "Município":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Endereco.Municipio LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Bairro":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Endereco.Bairro LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Rua":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Endereco.Rua LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Quarteirão":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Endereco.Quarteirao LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
                case "Número de casa":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Funcionario, Endereco WHERE Funcionario.CodEndereco = Endereco.Cod AND Endereco.NumeroCasa LIKE '" + metroTextBox1.Text + "%'");
                    }
                    catch { }
                    break;
            }

            //Cena da foto
            try
            {
                String Caminho = bd.RetornaDados("SELECT Foto FROM Funcionario WHERE Cod = " + metroGrid1.SelectedRows[0].Cells[0].Value.ToString() + "");
                pictureBox1.ImageLocation = Caminho;
            }
            catch { }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String Caminho = bd.RetornaDados("SELECT Foto FROM Funcionario WHERE Cod = " + metroGrid1.SelectedRows[0].Cells[0].Value.ToString() + "");
                pictureBox1.ImageLocation = Caminho;
            }
            catch { }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarFuncionario_Load(object sender, EventArgs e)
        {

        }
    }
}
