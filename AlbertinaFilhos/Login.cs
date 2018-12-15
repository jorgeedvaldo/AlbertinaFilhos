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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        Bd bd = new Bd();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int valor = bd.RetornaLinhas("SELECT * FROM Utilizador WHERE Nome = '" + metroTextBox1.Text + "' AND Senha = '" + metroTextBox2.Text + "'");
            if (valor == 1)
            {
                //Instaciando o formulario principal
                Form1 principal = new Form1();
                principal.login = this;
                //Restrição de acesso
                switch (bd.RetornaDados("SELECT Cargo FROM Utilizador WHERE Nome = '" + metroTextBox1.Text + "'"))
                {
                    case "Gerente":
                        principal.efectuarEncomendaToolStripMenuItem.Visible = true;
                        principal.funcionárioToolStripMenuItem.Visible = true;
                        principal.produtoToolStripMenuItem.Visible = true;
                        principal.utilizadorToolStripMenuItem.Visible = true;
                        principal.alterarPreçosDosProdutosToolStripMenuItem.Visible = true;
                        principal.funcionárioToolStripMenuItem1.Visible = true;
                        principal.utilizadorToolStripMenuItem1.Visible = true;
                        principal.stockToolStripMenuItem.Visible = true;
                        break;
                    default:
                        principal.efectuarEncomendaToolStripMenuItem.Visible = false;
                        principal.funcionárioToolStripMenuItem.Visible = false;
                        principal.produtoToolStripMenuItem.Visible = false;
                        principal.utilizadorToolStripMenuItem.Visible = false;
                        principal.alterarPreçosDosProdutosToolStripMenuItem.Visible = false;
                        principal.funcionárioToolStripMenuItem1.Visible = false;
                        principal.utilizadorToolStripMenuItem1.Visible = false;
                        principal.stockToolStripMenuItem.Visible = false;
                        break;
                }
                //chamando o formulário principal
                principal.Show();
                this.Visible = false;
            }
            else {
                MetroFramework.MetroMessageBox.Show(this, "Nome de utilizador ou Palavra-Passe errados, verifique os dados inseridos.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sair do sistema
            DialogResult yn = MetroFramework.MetroMessageBox.Show(this, "Tem a certeza que deseja sair do sistema?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yn == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
