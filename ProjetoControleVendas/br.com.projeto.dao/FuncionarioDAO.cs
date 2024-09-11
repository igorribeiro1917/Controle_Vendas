using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;
using ProjetoControleVendas.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    internal class FuncionarioDAO
    {
        private MySqlConnection conexao;

        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #region cadastrarFuncionario
        public void cadastrarFuncionario(Funcionario obj)
        {
            try
            {
                //passo 1 - criar comando sql

                string sql = @"insert into tb_funcionarios(nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado) 
                    values(@nome,@rg,@cpf,@email,@senha,@cargo,@nivel,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                //passo 2 - organizar comando sql 

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel", obj.nivel_acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);


                //passo 3 - abrir conexão e executar comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário cadastrado com sucesso!");

                //passo 4 - fechar conexão

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion
        #region listarFuncionario

        public DataTable listarFuncionario()
        {
            try
            {
                //passo 1 - Definir o dataTable e o comando sql

                DataTable tabelafuncionario = new DataTable();

                string sql = @"select * from tb_funcionarios";

                //passo 2 - Executar o comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //passo 3 - Definir o MySqlDataAdapter para preencher o DataTable com os resultados da execução o cmd sql

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                //passo 4 - Fecha conexão com o Banco de Dados e retorna o DataTable com os resultados 

                conexao.Close();

                return tabelafuncionario;
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error);
                return null;
            }
        }
        #endregion

        #region alterarFuncionario

        public void alterarFuncionario(Funcionario obj)
        {
            try
            {
                //passo 1 - Definir o comando sql 

                string sql = @"update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email,senha=@senha,cargo=@cargo,nivel_acesso=@nivel,telefone=@telefone, celular=@celular,
                              cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado where id=@codigo";

                //passo 2 - organizar comando sql 

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.Nome);
                executacmd.Parameters.AddWithValue("@rg", obj.Rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                executacmd.Parameters.AddWithValue("@email", obj.Email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel", obj.nivel_acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.Celular);
                executacmd.Parameters.AddWithValue("@cep", obj.Cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.Numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.Complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.Estado);
                executacmd.Parameters.AddWithValue("@codigo", obj.Codigo);

                //passo 3 - Executar comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Funcionario alterado com sucesso");

                //passso 4 - fechar conexao com o banco de dados 

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro:" + error.Message);
            }
        }
        #endregion

        #region excluirFuncionario
        public void excluirFuncionario(Funcionario obj)
        {
            try
            {
                //passo 1 - definir comando sql

                string sql = @"delete from tb_funcionarios where id=@codigo";

                //passo 2 - organizar comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@codigo", obj.Codigo);

                //passo 3 - exeutar comando sql 

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário excluído com sucesso");

                //passo 4 - fechar conexao com banco de dados

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro:" + error.Message);
            }
        }
        #endregion

        #region buscaFuncionarioPorNome
        public DataTable buscaFuncionarioPorNome(string nome)
        {
            try
            {
                //passo 1 - Definir o DataTable e o comando sql 
                
                DataTable busca = new DataTable();

                string sql = @"select * from tb_funcionarios where nome = @nome";
                 
                //passo 2 - Organizar o comando sql e executar comando 
                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //passo 3 - Definir o MySqlDataAdapter para preencher o DataTable com o resultado da execução do comando sql 
                
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(busca);

                //passo 4 - fechar conexão com o banco de dados 
                
                conexao.Close();

                return busca;

            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion

        #region listarFuncionariosPorNome
        public DataTable listarFuncionariosPorNome(string nome)
        {
            try
            {
                //passo 1 - Definir o DataTable e o comando sql
                
                DataTable busca = new DataTable();

                string sql = @"select * from tb_funcionarios where nome like @nome";

                //passo 2 - Organizar comando sql e executar o comando sql
                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

               //passo 3 - Definir o MySqlDataAdapter para preencher o DataTable com o resultado da execução do comando sql
                
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(busca);

                //passo 4 - Fechar conexão com o banco de dados 
                
                conexao.Close();

                return busca;

            }
             catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion

        #region efetuarLogin
        public bool efetuarLogin(string email, string senha)
        {
            try
            {
                // 1 passo - Criar o comando sql

                string sql = @"select * from tb_funcionarios where email = @email and senha = @senha";

                // 2 passo - Organizar comando sql e executar

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@email", email);
                executacmd.Parameters.AddWithValue("@senha", senha);

                conexao.Open();
                
                MySqlDataReader dr = executacmd.ExecuteReader();

                if(dr.Read() == true)
                {
                    string nivel = dr.GetString("nivel_acesso");
                    string nome = dr.GetString("nome");
                   
                    
                    //O login foi realizado com sucesso
                    MessageBox.Show("Seja bem vindo:" + nome);

                    //Distribuição de funcionalidade conforme nivel de acesso

                    FrmMenu telamenu = new FrmMenu();

                    telamenu.txtusuario.Text = nome;

                    if (nivel.Equals("Administrador") == true)
                    {
                        //Abrir a tela completa do menu principal
                        
                       telamenu.Show();
                    }
                    else if(nivel.Equals("Usuário") == true)
                    {
                        //Personalizar o que o vendendor/estagiario tem acesso no menu

                        telamenu.menuProdutos.Visible = false;
                        telamenu.menuFuncionario.Visible = false;
                        telamenu.menuCadastroFornecedores.Enabled = false;
                        
                        //Abrir o menu principal com restrições
                        
                        telamenu.Show();
                    }
                    conexao.Close();
                    return true;
                }
                else
                {
                    //A senha ou email digitado errado
                    MessageBox.Show("Senha ou email incorreto");
                    conexao.Close();
                    return false;
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo o erro:" + erro.Message);
                conexao.Close();
                return false;
            }
        }
      #endregion




    }









}
