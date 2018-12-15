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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {
            InitializeComponent();
            //try {
            //    int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //    int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //    this.ClientSize = new System.Drawing.Size(screenWidth, screenHeight);
                
            //}
            //catch {
            //    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //}
            
            
        }
        public void ObterInfoFuncionario() {
            try
            {

                IdFuncionario = bd.RetornaDados("SELECT CodFuncionario FROM Utilizador WHERE Nome = '" + login.metroTextBox1.Text + "'");
                NomeFuncionario = bd.RetornaDados("SELECT Nome FROM Funcionario WHERE Cod= " + IdFuncionario + "");
            }
            catch
            {
                IdFuncionario = "0";
                NomeFuncionario = "Desconhecido";
            }

        }
        public Login login;
        Bd bd = new Bd();
        public String IdFuncionario, NomeFuncionario;

        private void Form1_Load(object sender, EventArgs e)
        {
            ObterInfoFuncionario();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sair do sistema
            DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja sair do sistema?","Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(yn == DialogResult.Yes){
                Application.Exit();
            }
        }

        private void aAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.ShowDialog();
        }

        private void terminarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //terminar a sessão
            DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja terminar a sessão?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yn == DialogResult.Yes)
            {
                login.metroTextBox2.Text = "";
                login.Visible = true;
                this.Hide();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void utilizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadUtilizador cadUtilizador = new CadUtilizador();
            cadUtilizador.principal = this;
            cadUtilizador.ShowDialog();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadFuncionario cadFuncionario = new CadFuncionario();
            cadFuncionario.principal = this;
            cadFuncionario.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadProduto cadProduto = new CadProduto();
            cadProduto.principal = this;
            cadProduto.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadCliente cadCliente = new CadCliente();
            cadCliente.principal = this;
            cadCliente.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadStock cadStock = new CadStock();
            cadStock.principal = this;
            cadStock.ShowDialog();
        }

        private void alterarPreçosDosProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarPreco alterarPreco = new AlterarPreco();
            alterarPreco.principal = this;
            alterarPreco.ShowDialog();
        }

        private void efectuarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadVenda cadVenda = new CadVenda();
            cadVenda.principal = this;
            cadVenda.ShowDialog();
        }

        private void efectuarEncomendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadInfoEncomenda CIE = new CadInfoEncomenda();
            CIE.principal = this;
            CIE.ShowDialog();
        }

        private void caixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarVenda venda = new ConsultarVenda();
            venda.principal = this;
            venda.ShowDialog();
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {
        }

        private void estoqueDisponivelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarProduto consultarProduto = new ConsultarProduto();
            consultarProduto.principal = this;
            consultarProduto.ShowDialog();
        }

        private void utilizadorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarUtilizador consultarUtilizador = new ConsultarUtilizador();
            consultarUtilizador.principal = this;
            consultarUtilizador.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarCliente consultarCliente = new ConsultarCliente();
            consultarCliente.principal = this;
            consultarCliente.ShowDialog();
        }

        private void funcionárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarFuncionario consultarFuncionario = new ConsultarFuncionario();
            consultarFuncionario.principal = this;
            consultarFuncionario.ShowDialog();
        }

        private void encomendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarEncomenda consultarEncomenda = new ConsultarEncomenda();
            consultarEncomenda.principal = this;
            consultarEncomenda.ShowDialog();
        }

        private void relatórioDeVeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioVenda relatorioVenda = new RelatorioVenda(bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'"), bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'E%'").Rows.Count.ToString());
            relatorioVenda.principal = this;
            relatorioVenda.ShowDialog();
        }

        private void relatórioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelatorioEncomenda relatorioEncomenda = new RelatorioEncomenda(bd.RetornaTabela("SELECT * FROM Factura WHERE CodFactura NOT LIKE 'V%'"));
            relatorioEncomenda.principal = this;
            relatorioEncomenda.ShowDialog();
        }

        private void relatórioDosProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioProduto relatorioProduto = new RelatorioProduto(bd.RetornaTabela("SELECT * FROM Produto"));
            relatorioProduto.principal = this;
            relatorioProduto.ShowDialog();
        }

        private void relatórioDosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioCliente relatorioCliente = new RelatorioCliente(bd.RetornaTabela("SELECT * FROM Cliente"));
            relatorioCliente.principal = this;
            relatorioCliente.ShowDialog();
        }

        private void relatórioDosUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioUsuario relatorioUsuario = new RelatorioUsuario(bd.RetornaTabela("SELECT * FROM Utilizador"));
            relatorioUsuario.principal = this;
            relatorioUsuario.ShowDialog();
        }

        private void relatórioDosFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatorioFuncionario relatorioFuncionario = new RelatorioFuncionario(bd.RetornaTabela("SELECT * FROM Funcionario"));
            relatorioFuncionario.principal = this;
            relatorioFuncionario.ShowDialog();
        }
    }
}
