using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menuFuncionario_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //Pegando data atual

            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void menuConsultaClientes_Click(object sender, EventArgs e)
        {
            //Abre a tela de cadastro de cliente

            FrmClientes tela = new FrmClientes();
            tela.ShowDialog();
        }

        private void consultaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre a tela de cadastro na página de consulta de cliente

            FrmClientes tela = new FrmClientes();
            tela.tabClientes.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroFuncionario_Click(object sender, EventArgs e)
        {
            //Abrir a tela de cadastro de funcionários

            FrmFuncionarios tela = new FrmFuncionarios();
            tela.ShowDialog();
        }

        private void menuConsultaFuncionario_Click(object sender, EventArgs e)
        {
            //Abrir a tela de consulta de funcionarios

            FrmFuncionarios tela = new FrmFuncionarios();
            tela.tabFuncionario.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroFornecedores_Click(object sender, EventArgs e)
        {
            //Abrir a tela de cadastro de fornecedores

            FrmFornecedores tela = new FrmFornecedores();
            tela.ShowDialog();
        }

        private void menuConsultaFornecedores_Click(object sender, EventArgs e)
        {
            //Abrir a tela de consulta de fornecedores

            FrmFornecedores tela = new FrmFornecedores();
            tela.tabFornecedor.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroProdutos_Click(object sender, EventArgs e)
        {
            //Abrir a tela de cadastro de produtos

            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();

        }

        private void menuConsultaProdutos_Click(object sender, EventArgs e)
        {
            //Abrir a tela de consulta de produtos

            FrmProdutos tela = new FrmProdutos();
            tela.tabProdutos.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuNovaVenda_Click(object sender, EventArgs e)
        {
            //Abre a tela de registro de vendas

            FrmVendas tela = new FrmVendas();
            tela.ShowDialog();
        }

        private void menuHistoricoVenda_Click(object sender, EventArgs e)
        {
            //Abre a tela de historico de venda

            FrmHistorico tela = new FrmHistorico();
            tela.ShowDialog();
        }
        private void menuConfiguracaoSair_Click(object sender, EventArgs e)
        {
            //Message Box de avuso para fechamento do sistema

            DialogResult resultado = MessageBox.Show("Você deseja sair?", "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                //Fecha Aplicação
                
                Application.Exit();
            }
        }
        private void menuConfiguracaoTrocaUsuario_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
