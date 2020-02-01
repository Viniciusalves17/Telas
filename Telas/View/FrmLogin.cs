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

namespace Telas
{
    public partial class FrmLogin : Form
    {

        Usuario objUsuario;
        Conexao con;
        public FrmLogin()
        {
        
            InitializeComponent();
            con = new Conexao();
        }

        private void lerdados()
        {
            objUsuario = new Usuario();
            objUsuario.usuario = Txt_Usuario.Text.Trim () ;
            objUsuario.senha = Txt_senha.Text.Trim () ;

            String CrypSenha = CrypHash.ComputeSha256Hash(objUsuario.senha);
            con.OpenConnection();

            
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            
            lerdados();
            String CrypSenha = CrypHash.ComputeSha256Hash(objUsuario.senha);

            String Mysql = $"SELECT * FROM tb_usuario WHERE usuario = '{objUsuario.usuario}' AND senha ='{CrypSenha}' ";
            MySqlDataReader reader;
            reader = con.executeQuery(Mysql);
            if (reader.HasRows)
            {
                Telas.View.FrmMenu menu = new View.FrmMenu();
                menu.Show();
                this.Visible = false;
                MessageBox.Show("login com sucesso");
            }
            else
            {
                MessageBox.Show("login incorreto");
            }
         
        }
    }
}
