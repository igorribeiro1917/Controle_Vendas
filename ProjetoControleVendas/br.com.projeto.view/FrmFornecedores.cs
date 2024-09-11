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
using static System.Net.WebRequestMethods;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnbusar_Click(object sender, EventArgs e)
        {
            //Botao Buscar CEP

            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";

                DataSet ds = new DataSet();
                ds.ReadXml(xml);

                txtendereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = ds.Tables[0].Rows[0]["localidade"].ToString();
                txtcomp.Text = ds.Tables[0].Rows[0]["complemento"].ToString();
                txtuf.Text = ds.Tables[0].Rows[0]["uf"].ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show( "Está acontecedo algum erro:"+ error.Message);
            }
            
            
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //Botão Salvar

            Fornecedor obj = new Fornecedor();

            obj.Nome = txtnome.Text;
            obj.cnpj = txtcnpj.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Complemento = txtcomp.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.Text;

            FornecedorDAO dao = new FornecedorDAO();

            dao.cadastrarFornecedor(obj);

            tabelaFornecedores.DataSource = dao.listarFornecedores();

            new Helpers().LimparTela(this);
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            //Carregar todos os Fornecedores

            FornecedorDAO dao = new FornecedorDAO();

           tabelaFornecedores.DataSource = dao.listarFornecedores();
        }

        private void tabelaFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txttelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtcelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtendereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtnumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtcomp.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtcidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            txtuf.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

            tabFornecedor.SelectedTab = tabPage1;

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //Botão Excluir
            
            Fornecedor obj = new Fornecedor();

            obj.Codigo = int.Parse(txtcodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();

            dao.excluirFornecedor(obj);

            tabelaFornecedores.DataSource = dao.listarFornecedores();

            new Helpers().LimparTela(this);
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();

            obj.Nome = txtnome.Text;
            obj.cnpj = txtcnpj.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero =int.Parse(txtnumero.Text);
            obj.Complemento = txtcomp.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.Text;
            obj.Codigo = int.Parse(txtcodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();

            dao.alterarFornecedor(obj);

            tabelaFornecedores.DataSource = dao.listarFornecedores();

            new Helpers().LimparTela(this);
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtpesquisa.Text;

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.BuscarFuncionarioPorNome(nome);
            
            if(tabelaFornecedores.Rows.Count == 0 || txtpesquisa.Text == string.Empty)
            {
                MessageBox.Show("Fornecedor não encontrado");
                dao.listarFornecedores();
            }
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            FornecedorDAO dao = new FornecedorDAO();

            tabelaFornecedores.DataSource = dao.ListarFuncionariosPorNome(nome);
        }
    }
}
