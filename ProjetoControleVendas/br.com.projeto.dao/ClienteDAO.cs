using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    internal class ClienteDAO
    {
        private MySqlConnection conexao;



        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarCLiente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o comando sql - insert into 

                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                          values(@nome, @rg, @cpf, @email, @telefone, @celular,@cep,@endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2 passo - Organizar o comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Celular);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);

                //3 passo - Abrir a conexão e executar o comando sql 

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente cadastrado com sucesso!");

                //4 passo - fechar a conexão com o banco de dados 

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Cliente não cadastrado:" + error.Message);
            }
        }
        #endregion

        #region alterarCliente
        public void alterarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o comando sql - update

                string sql = @"update tb_clientes set nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular, cep=@cep, endereco = @endereco,
                             numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado where id = @id";

                //2 passo - Organizar o cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                
                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
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

                //3 passo - abrir conexao e executar comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente alterado com sucesso!");

                // 4 passo - fechar a conexão com o banco de dados

                conexao.Close();
            }
             catch(Exception error)
            {
                MessageBox.Show("Aconteceu algo de errado" + error.Message);
            }
        }
        #endregion

        #region excluirCliente
        public void excluirCliente(Cliente obj)
        {
            try
            {
                //passo 1 - definir comando sql - delete

                string sql = @"delete from tb_clientes where id = @id";

                //passo 2 - organizar o cmd sql
                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.Codigo);

                //passo 3 - executa comando sql
                
                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso!");
                
                //passo 4 - fechar conexao com banco de dados 
                
                conexao.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro:" + error.Message);
            }
        }   
        #endregion

        #region ListarClientes

        public DataTable listarClientes()
        {
            try
            {
                //passo 1 - Criar o DataTable e o comando SQL
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                //passo 2 - Organizar o comando sql e executar 
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //passo 3 - Criar o MySQLDataApter para preencher os dados no DataTable 
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //passo 4 - fechar a conexão com o banco de dados 
                conexao.Close();
                
                return tabelacliente;
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao executar o comando sql" + error.Message);
                return null;
            }
        }
        #endregion

        #region BuscarClientePorNome
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                //passo 1 - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = @"select * from tb_clientes where nome = @nome";

                //passo 2 - Organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //passo 3 - Criar o MySQLDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                
                //passo 4 - fechar a conexão com o banco de dados
                conexao.Close();
                
                return tabelacliente;
            }
            catch(Exception error)
            {
                MessageBox.Show("Pesquisa Inválida:" + error.Message);
                return null;
            }
        }
        #endregion

        #region ListarClientesPorNome
        public DataTable ListarClientesPorNome(string nome)
        {
            try
            {
                //passo 1 - Criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();
                string sql = @"select * from tb_clientes where nome like @nome";

                //passo 2 - Organizar o comando sql e executar 
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //passo 3 - Criar o MySqlDataAdapter para preencher o DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                //passo 4 - fechar a conexão com o banco de dados 
                conexao.Close();

                return tabelacliente;
            }
            catch(Exception error)
            {
                MessageBox.Show("Pesquisa Inválida:" + error.Message);
                return null;
            }
        }
        #endregion

        #region retornaClientePorCpf
        public Cliente retornaClientePorCpf(string cpf)
        {
            try
            {
                //passo 1 - Definir comando Sql e obj cliente
                Cliente obj = new Cliente();

                string sql = @"select * from tb_clientes where cpf = @cpf";

               //passo 2 - Organizar comando sql 
                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@cpf", cpf);

                //passo 3 - Abrir conexão com Banco de Dados 
                
                conexao.Open();

               //Passo 4 - MySqlDataReader recebera o dado resultante da execução do comando sql 
                
                MySqlDataReader rs = executacmd.ExecuteReader();

                //Passo 5 - Caso consiga ler o dado dentro do MySqlDataReader, capturar os dados da coluna id e nome e armazenar nos atributos 
                
                if (rs.Read() == true)
                {
                    obj.Codigo = rs.GetInt32("id");
                    obj.Nome = rs.GetString("nome");
                    conexao.Close();
                    return obj;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado");
                    conexao.Close();
                    return null;
                }
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
