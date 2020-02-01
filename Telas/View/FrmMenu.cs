using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Telas.View
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

        
            
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Usuario_Click(object sender, EventArgs e)
        {
            User use = new User();
            use.Show();
            this.Visible = false;
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastro use = new FrmCadastro();
            use.Show();
        }
    }
}
