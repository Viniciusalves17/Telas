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
    public partial class FrmCadastro : Form
    {
        Usuario objcadast;
        Conexao con;
        public FrmCadastro()   
        {
            InitializeComponent();
        }
        private void lerdados()
        {
            objcadast = new Usuario();
            objcadast.id = int.Parse(txt_id_cadast.Text.Trim());
            objcadast.Nome = txt_nome_cadast.Text;
            objcadast.email = txt_email_cadast.Text;
            objcadast.usuario = txt_Usuario_cadast.Text.Trim();
            objcadast.senha = txt_senha_cadast.Text.Trim();
            objcadast.id_perfil = int.Parse(CMB_ID_Perfil.SelectedValue.ToString());

        }
        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            lerdados();
            String Mysql = $"inset int tb_usuario values =' {objcadast.id}' , ' {objcadast.Nome}";
            MySqlDataReader reader;
            reader = con.executeQuery(Mysql);
            if (con.executeQuery(Mysql)== null)
            {
                MessageBox.Show("Seus Dados foram Salvos !!!");
            } 
            else
            {
                MessageBox.Show("Erro ! Os dados não foram Salvos");
            }

            private void carregarbox ()
        {
            List<Perfil> Listperfil = new List<Perfil>();
            con.OpenConnection();
            MySqlDataReader reader;
            String Mysql = $" SELECT * FROM tb_perfil";
            reader = con.executeQuery(Mysql);
            if (reader.HasRows)
                {
                while (reader.Read())
                {
                    Perfil perfil1 = new Perfil();
                    perfil1.id_perfil = reader.GetInt32(0);
                    perfil1.nome = reader.GetString(1);
                    Listperfil.Add(perfil1);
                }
            }
            else
            {
                Console.WriteLine("Não retornou os dados");
            }
            reader.Close();
            CMB_ID_Perfil.DataSource = Listperfil;
            CMB_ID_Perfil.DisplayMember = "nome";
            CMB_ID_Perfil.ValueMember = "id";
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            carregarbox();
        }
    }
      
      
    }
}
