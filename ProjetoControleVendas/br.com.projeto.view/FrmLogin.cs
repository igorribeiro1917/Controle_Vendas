using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoControleVendas.br.com.projeto.dao;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            //Botão entrar

            string email = txtemail.Text;
            string senha = txtsenha.Text;

            FuncionarioDAO fdao = new FuncionarioDAO();

            if(fdao.efetuarLogin(email, senha) == true)
            {
               //Fecha a tela de login após a entrada do usuário
                
                this.Hide();
            }
        }
    }
}
