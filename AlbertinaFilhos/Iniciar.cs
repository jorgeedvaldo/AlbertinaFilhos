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
    public partial class Iniciar : Form
    {
        public Iniciar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Width < 261)
            {
                panel1.Width += 2;
            }
            else {
                timer1.Enabled = false;
                Login login = new Login();
                login.Show();
                this.Visible = false;
            }
        }

        private void Iniciar_Load(object sender, EventArgs e)
        {

        }
    }
}
