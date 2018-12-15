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
    public partial class ConsultarProduto : MetroFramework.Forms.MetroForm
    {
        Bd bd = new Bd();
        public String Pesquisa;
        public Form1 principal = new Form1();
        public ConsultarProduto()
        {
            InitializeComponent();
            this.Pesquisa = "*";
            metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Produto");
        }

        private void ConsultarProduto_Load(object sender, EventArgs e)
        {

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
            switch(metroComboBox1.Text){
                case "Código do produto":
                    comboBox1.Visible = true;
                    metroTextBox1.Visible = false;
                    try {
                        comboBox1.DataSource = bd.RetornaTabela("SELECT * FROM Produto");
                        comboBox1.DisplayMember = "Cod";
                    }
                    catch { }
                    break;
                default:
                    metroTextBox1.Text = "";
                    comboBox1.Visible = false;
                    metroTextBox1.Visible = true;
                    break;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.Text)
            {
                case "Código do produto":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Produto WHERE Cod = "+comboBox1.Text+"");
                    }
                    catch { }
                    break;
                case "Nome do produto":
                    metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Produto WHERE Nome LIKE '" + metroTextBox1.Text + "%'");
                    break;
                case "Preço":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Produto WHERE Preco = " + metroTextBox1.Text + "");
                    }
                    catch { }
                    break;
                case "Quantidade":
                    try
                    {
                        metroGrid1.DataSource = bd.RetornaTabela("SELECT " + this.Pesquisa + " FROM Produto WHERE Qtd = " + metroTextBox1.Text + "");
                    }
                    catch { }
                    break;
            }
        }
    }
}
