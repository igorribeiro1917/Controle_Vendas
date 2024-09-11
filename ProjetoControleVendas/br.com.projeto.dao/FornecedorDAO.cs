using MySql.Data.MySqlClient;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    internal class FornecedorDAO
    {
        private MySqlConnection conexao;

        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #region cadastrarFornecedor
        public void cadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"insert into tb_fornecedores(nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                         values(@nome,@cnpj,@email,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Fornecedor cadastrado com sucesso");

                conexao.Close();
            }
             catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro"+ error.Message);
            }
        }
        #endregion

        #region listarFornecedores
        public DataTable listarFornecedores()
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                string sql = @"select * from tb_fornecedores";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexao.Close();

                return tabelafornecedor;
            }
             catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion

        #region alterarFornecedor

        public void alterarFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"update tb_fornecedores set nome=@nome,cnpj=@cnpj,email=@email,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,
                          numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado where id=@id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);
                executacmd.Parameters.AddWithValue("@id", obj.Codigo); 

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Fornecedor alterado com sucesso");

                conexao.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion

        #region excluirFornecedor
        public void excluirFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"delete from tb_fornecedores where id=@id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Fornecedor removido com sucesso");

                conexao.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion

        #region BuscarFuncionarioPorNome
        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                string sql = @"select * from tb_fornecedores where nome = @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexao.Close();

                return tabelafornecedor;
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion
        #region ListarFuncionariosPorNome
        public DataTable ListarFuncionariosPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                string sql = @"select * from tb_fornecedores where nome like @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexao.Close();

                return tabelafornecedor;
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
      #endregion 





    }
}
