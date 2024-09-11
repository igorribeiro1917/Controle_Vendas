using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    internal class ProdutoDAO
    {
        public MySqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }
        #region cadastraProduto
        public void cadastraProduto(Produto obj)
        {
            try
            {
                //passo 1 - definir comando sql

                string sql = @"insert into tb_produtos (descricao,preco,qtd_estoque,for_id) value(@descricao,@preco,@qtd,@for_id)";

                //passo 2 - organizar e executar comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado com sucesso");

                //passo 3 - Fechar conexão com banco de dados 

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion

        #region listarProdutos
        public DataTable listarProdutos()
        {
            try
            {
                //Passo 1 - Criar DataTable e definir o comando SQL 

                DataTable tabelaproduto = new DataTable();

                string sql = @"select tb_produtos.id as 'Código',
                              tb_produtos.descricao as 'Descrição',
                              tb_produtos.preco as 'Preço(R$)',
                              tb_produtos.qtd_estoque as 'Qtd Estoque', 
                              tb_fornecedores.nome as 'Fornecedor' 
                              from tb_produtos join tb_fornecedores 
                              on (tb_produtos.for_id = tb_fornecedores.id);";

                //Passo 2 - Organizar e executar comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Passo 3 - Criar o MySqlDataAdapter para preencher o DataTable

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);

                //Passo 4 - Fechar conexão com o banco de dados 

                conexao.Close();

                return tabelaproduto;
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro:" + error.Message);
                return null;
            }
        }
        #endregion

        #region alterarProduto
        public void alterarProduto(Produto obj)
        {
            try
            {
                //Passo 1 - Definir comando sql

                string sql = @"update tb_produtos set descricao=@descricao,preco=@preco,qtd_estoque=@qtd,for_id=@for_id where id=@id";

                //Passo 2 - Organizar comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);
                executacmd.Parameters.AddWithValue("@id", obj.id);

                //Passo 3 - Executar comando sql 

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Produto alterado com sucesso");

                //Passo 4 - Fechar conexão com o Banco de Dados 

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion

        #region excluirProduto
        public void excluirProduto(Produto obj)
        {
            try
            {
                //Passo 1 - Definir comando sql

                string sql = @"delete from tb_produtos where id=@id";

                //Passo 2 - Organiza e executa comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Produto excluído com sucesso");

                //Passo 3 - Fecha conexao

                conexao.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
            }
        }
        #endregion

        #region buscarProdutoPorNome
        public DataTable buscarProdutoPorNome(string nome)
        {
            try
            {

                //Passo 1 - Criar DataTable e definir comando sql

                DataTable tabelaproduto = new DataTable();

                string sql = @"select tb_produtos.id as 'Código',
                              tb_produtos.descricao as 'Descrição',
                              tb_produtos.preco as 'Preço(R$)',
                              tb_produtos.qtd_estoque as 'Qtd Estoque', 
                              tb_fornecedores.nome as 'Fornecedor' 
                              from tb_produtos join tb_fornecedores 
                              on (tb_produtos.for_id = tb_fornecedores.id) where tb_produtos.descricao = @nome;";

                //Passo 2 - Organizar comando sql e executar

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                //Passo 3 - Criar o MySqlDataAdapter para preencher o DataTable com os resultados da execução do sql

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);

                //Passo 4 - Fechar conexão com o banco de dados 

                conexao.Close();

                return tabelaproduto;
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion

        #region listarProdutosPorNome
        public DataTable listarProdutosPorNome(string nome)
        {
            try
            {
                DataTable tabelaproduto = new DataTable();

                string sql = @"select tb_produtos.id as 'Código',
                              tb_produtos.descricao as 'Descrição',
                              tb_produtos.preco as 'Preço(R$)',
                              tb_produtos.qtd_estoque as 'Qtd Estoque', 
                              tb_fornecedores.nome as 'Fornecedor' 
                              from tb_produtos join tb_fornecedores 
                              on (tb_produtos.for_id = tb_fornecedores.id) where tb_produtos.descricao like @nome;";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);

                conexao.Close();

                return tabelaproduto;
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }

        }
        #endregion

        #region retornaProdutoPorCodigo
        public Produto retornaProdutoPorCodigo(int codigo)
        {
            try
            {
                //Passo 1 - Definir comando sql e criar objeto produto

                Produto produto = new Produto();
                string sql = @"select * from tb_produtos where id=@id";

                //Passo 2 - Organizar comando sql e executar

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@id", codigo);
                conexao.Open();


                //Passo 3 - MySqlDataReader recebera o dado resultante da execução do comando sql 

                MySqlDataReader rs = executacmd.ExecuteReader();

                 //Passo 4 - Caso consiga ler o dado dentro do MySqlDataReader, acesar os dados das colunas id,descricao,preco
                // e armazenar nos atributos do obj Produto
                if (rs.Read() == true)
                {
                    produto.id = rs.GetInt32("id");
                    produto.descricao = rs.GetString("descricao");
                    produto.preco = rs.GetDecimal("preco");

                    conexao.Close();

                    return produto;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado");

                    conexao.Close();
                    
                    return null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro" + error.Message);
                return null;
            }
        }
        #endregion

        #region baixaEstoque
        public void baixaEstoque(int idproduto, int qtdestoque)
        {
            try
            {
                //passo 1 - Definir comando sql 

                string sql = @"update tb_produtos set qtd_estoque = @qtd where id=@id";

                //passo 2 - organiza comando sql 

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@qtd", qtdestoque);
                executacmd.Parameters.AddWithValue("@id", idproduto);

                //passo 3 - abre conexao e executa sql

                conexao.Open();
                executacmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo o erro:" + erro);
                conexao.Close();
            }
        }
        #endregion

        #region retornaEstoqueAtual
        public int retornaEstoqueAtual(int idproduto)
        {
            try
            {
                string sql = @"select qtd_estoque from tb_produtos where id = @id";
                int qtd_estoque = 0;
                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
               executacmd.Parameters.AddWithValue("@id", idproduto);

                conexao.Open();
                
                MySqlDataReader rs = executacmd.ExecuteReader();

                if(rs.Read() == true)
                {
                    qtd_estoque = rs.GetInt32("qtd_estoque");
                    conexao.Close();
                }
                return qtd_estoque;
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo o erro:" + erro.Message);
                conexao.Close();
                return 0;
            }
        }
       #endregion
    }
}
