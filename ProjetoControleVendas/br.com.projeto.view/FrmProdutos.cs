using ProjetoControleVendas.br.com.projeto.dao;
using ProjetoControleVendas.br.com.projeto.model;
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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();

            //passo 1 - Carregar a listagem de fornecedores no combobox da página de produtos
            
            cbfornecedor.DataSource = f_dao.listarFornecedores();
           
            //passo 2 - Os nomes dos fornecedores serão exibidos para o usuário escolher
            
            cbfornecedor.DisplayMember = "nome";
            
            //passo 3 - Salvar o id correspondente ao nome escolhido no banco de dados 
            
            cbfornecedor.ValueMember = "id";

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.listarProdutos();
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
           //passo 1 - Receber todos os dados da tela 
            
            Produto obj = new Produto();
            obj.descricao = txtdesc.Text;
            obj.preco =decimal.Parse( txtpreco.Text);
            obj.qtdestoque = int.Parse(txtqtd.Text);
            obj.for_id = int.Parse(cbfornecedor.SelectedValue.ToString());

            //passo 2 - Criar o objeto dao 
            
            ProdutoDAO dao = new ProdutoDAO();

            dao.cadastraProduto(obj);

            tabelaProdutos.DataSource = dao.listarProdutos();

            new Helpers().LimparTela(this);
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void tabelaProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Recarregar os dados do DataGridView para os campos da página de Cadastro Produtos
            
            txtcodigo.Text = tabelaProdutos.CurrentRow.Cells[0].Value.ToString();
            txtdesc.Text = tabelaProdutos.CurrentRow.Cells[1].Value.ToString();
            txtpreco.Text = tabelaProdutos.CurrentRow.Cells[2].Value.ToString();
            txtqtd.Text = tabelaProdutos.CurrentRow.Cells[3].Value.ToString();
            cbfornecedor.Text = tabelaProdutos.CurrentRow.Cells[4].Value.ToString();

            //Alterar da página do DataGridView  para a página de Cadastro Produtos 
            
            tabProdutos.SelectedTab = tabPage1;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //Botão Editar
            
            Produto obj = new Produto();
            obj.descricao = txtdesc.Text;
            obj.preco = decimal.Parse(txtpreco.Text);
            obj.qtdestoque = int.Parse(txtqtd.Text);
            obj.for_id = int.Parse(cbfornecedor.SelectedValue.ToString());
            obj.id = int.Parse(txtcodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.alterarProduto(obj);

            //Recarregar DataGridView com dados atualizados 
            
            tabelaProdutos.DataSource = dao.listarProdutos();

            new Helpers().LimparTela(this);
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir 
            
            Produto obj = new Produto();
            obj.id = int.Parse(txtcodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.excluirProduto(obj);

            //Recarregar DataGridView atualizados 
            
            tabelaProdutos.DataSource = dao.listarProdutos();

            new Helpers().LimparTela(this);
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //Botão Pesquisar nome do produto

            string nome = txtpesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.buscarProdutoPorNome(nome);

            if(tabelaProdutos.Rows.Count == 0 || txtpesquisa.Text == string.Empty)
            {
                MessageBox.Show("Produto não encontrado");
                tabelaProdutos.DataSource = dao.listarProdutos();
            }
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProdutos.DataSource = dao.listarProdutosPorNome(nome);
        }
    }
}
