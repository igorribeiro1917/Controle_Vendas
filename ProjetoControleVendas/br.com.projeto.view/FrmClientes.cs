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
using ProjetoControleVendas.br.com.projeto.model;
using static System.Net.WebRequestMethods;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Botao Pesquisar
            
            string nome = txtpesquisa.Text;

            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.BuscarClientePorNome(nome);

            if(tabelaCliente.Rows.Count == 0 || txtpesquisa.Text == string.Empty)
            {
                //Recarregar o datagridview

                MessageBox.Show("Cliente não encontrado.");
                tabelaCliente.DataSource = dao.listarClientes();
            }
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            //1 passo - Receber os dados proveniente da tela de cliente,para dentro do objeto modelo de cliente 
            
            Cliente obj = new Cliente();
            obj.Nome = txtnome.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Complemento = txtcomp.Text;
            obj.Estado = txtuf.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Endereco = txtendereco.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Cep = txtcep.Text;

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o método cadastrarCliente
            
            ClienteDAO cliente = new ClienteDAO();

            cliente.cadastrarCliente(obj);

            //3 passo - Recarregar DataGridView atualizado(novo cliente cadastrado)
            
            tabelaCliente.DataSource = cliente.listarClientes();
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar a linha selecionada com o mouse no datagridview e retornar as informações para área de dados pessoais 

            txtcodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            txtuf.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para a guia Dados Pessoais

            tabClientes.SelectedTab = tabPage1;
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //Botao Excluir
            
            Cliente obj = new Cliente();
            
            //pegar Codigo
            obj.Codigo = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.excluirCliente(obj);

            //Recarregar o datagridview atualizado(com a exclusão do cliente)
            tabelaCliente.DataSource = dao.listarClientes();

            new Helpers().LimparTela(this);
        
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();

            obj.Nome = txtnome.Text;
            obj.Email = txtemail.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Complemento = txtcomp.Text;
            obj.Estado = txtuf.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Endereco = txtendereco.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Cep = txtcep.Text;
            obj.Codigo = int.Parse(txtcodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            //Recarregar o DataGridView atualizado(com o cliente editado)

            tabelaCliente.DataSource = dao.listarClientes();

            new Helpers().LimparTela(this);
        }

        private void txtpesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtpesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão de pesquisar Cep

            try
            {
                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet ds = new DataSet();

                ds.ReadXml(xml);

                txtendereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtcomp.Text = ds.Tables[0].Rows[0]["complemento"].ToString();
                txtbairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = ds.Tables[0].Rows[0]["localidade"].ToString();
                txtuf.Text = ds.Tables[0].Rows[0]["uf"].ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show("Cep não encontrado, digite manualmente" + error);
            
            }
            
            
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            //Botão Novo

            new Helpers().LimparTela(this);
        }
    }
}
