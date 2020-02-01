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
    public partial class User : Form
    {
        Conexao con;
        Usuario objUser;
        public User()
        {
            InitializeComponent();
            con = new Conexao();
            objUser = new Usuario();
        }

        public void lerDados()
        {
            objUser.id = int.Parse(txtId.ToString().Trim());
            objUser.Nome = txtNome.Text;
            objUser.email = txtEmail.Text;
            objUser.senha = txtSenha.Text;
            objUser.usuario = txtUsuario.Text;

            objUser.id_perfil = int.Parse(cmbPerfil.SelectedValue.ToString());
            if(rbAtivo.Checked)
            {
                objUser.status = true;
            }
            else
            {
                objUser.status = false;
            }

        }

        public void atualizargrid ()
        {
            List<Usuario> listusuario = new List<Usuario>();
            con.OpenConnection();
            String Mysql = $"SELECT * FROM tb_usuario";
            MySqlDataReader reader;
            reader = con.executeQuery(Mysql);
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    Usuario objuser1 = new Usuario();
                    objuser1.id = reader.GetInt32(0);
                    objuser1.Nome = reader.GetString(1);
                    objuser1.email = reader.GetString(2);
                    objuser1.usuario = reader.GetString(4);
                    objuser1.status = reader.GetBoolean(5);
                    objuser1.id_perfil = reader.GetInt32(6);
                    listusuario.Add(objuser1);
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Informaçoes invalidas");
            }
            DTWG_Usuario.DataSource = null;
            DTWG_Usuario.DataSource = listusuario;
        }

        private void User_Load(object sender, EventArgs e)
        {
            atualizargrid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
