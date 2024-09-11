using ProjetoControleVendas.br.com.projeto.dao;
using ProjetoControleVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtuf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.nivel_acesso = cbnivel.SelectedItem.ToString();
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Complemento = txtcomp.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.SelectedItem.ToString();
            obj.cargo = cbcargo.SelectedItem.ToString();

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.cadastrarFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionario();
        }

        private void tabelaFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            tabelaFuncionario.DefaultCellStyle.ForeColor = Color.Black;
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.listarFuncionario();
        }

        private void tabelaFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = tabelaFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtsenha.Text = tabelaFuncionario.CurrentRow.Cells[5].Value.ToString();
            cbcargo.Text = tabelaFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbnivel.Text = tabelaFuncionario.CurrentRow.Cells[7].Value.ToString();
            txttelefone.Text = tabelaFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtcelular.Text = tabelaFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtcep.Text = tabelaFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtendereco.Text = tabelaFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtnumero.Text = tabelaFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtcomp.Text = tabelaFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtbairro.Text = tabelaFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtcidade.Text = tabelaFuncionario.CurrentRow.Cells[15].Value.ToString();
            txtuf.Text = tabelaFuncionario.CurrentRow.Cells[16].Value.ToString();

            tabFuncionario.SelectedTab = tabPage1;
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //Botao Excluir

            Funcionario obj = new Funcionario();
            obj.Codigo = int.Parse(txtcodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.excluirFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionario();

            new Helpers().LimparTela(this);
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //Botao Editar

            Funcionario obj = new Funcionario();

            obj.Codigo = int.Parse(txtcodigo.Text);
            obj.Nome = txtnome.Text;
            obj.Rg = txtrg.Text;
            obj.Cpf = txtcpf.Text;
            obj.Email = txtemail.Text;
            obj.senha = txtsenha.Text;
            obj.cargo = cbcargo.Text;
            obj.nivel_acesso = cbnivel.Text;
            obj.Telefone = txttelefone.Text;
            obj.Celular = txtcelular.Text;
            obj.Cep = txtcep.Text;
            obj.Endereco = txtendereco.Text;
            obj.Numero = int.Parse(txtnumero.Text);
            obj.Complemento = txtcomp.Text;
            obj.Bairro = txtbairro.Text;
            obj.Cidade = txtcidade.Text;
            obj.Estado = txtuf.Text;

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.alterarFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionario();

            new Helpers().LimparTela(this);
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            //Botão pesquisar 

            string nome = txtpesquisa.Text;

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.buscaFuncionarioPorNome(nome);

            if(tabelaFuncionario.Rows.Count == 0 || txtpesquisa.Text == string.Empty)
            {

                MessageBox.Show("Funcionário não encontrado.");
                
                //Recarregar o DataGridView
                tabelaFuncionario.DataSource = dao.listarFuncionario();
            }
        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome ="%"+ txtpesquisa.Text +"%";

            FuncionarioDAO dao = new FuncionarioDAO();

            tabelaFuncionario.DataSource = dao.listarFuncionariosPorNome(nome);
        }

        private void btnbusar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botao Consultar CEP 

                string cep = txtcep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtendereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtbairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtcidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtcomp.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtuf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
    }
}
