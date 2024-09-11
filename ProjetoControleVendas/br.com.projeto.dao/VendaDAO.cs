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

namespace ProjetoControleVendas.br.com.projeto.dao
{
    internal class VendaDAO
    {
        private MySqlConnection conexao;

        public VendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region cadastraVenda
        public void cadastraVenda(Venda obj)
        {
            try
            {
                //Passo 1 - Definir comando o sql

                string sql = @"insert into tb_vendas (cliente_id,data_venda,total_venda,observacoes)
                               values(@cliente_id,@data_venda,@total_venda,@obs)";

                //Passo 2 - Organizar comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@cliente_id", obj.cliente_id);
                executacmd.Parameters.AddWithValue("@data_venda", obj.data_venda);
                executacmd.Parameters.AddWithValue("@total_venda", obj.total_venda);
                executacmd.Parameters.AddWithValue("@obs", obj.observacao);

                //Passo 3 - Abrir conexão e executar comando sql 

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Venda cadastrada com sucesso");

                conexao.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show("Está acontecendo algum erro:" + error.Message);
            }
        }
        #endregion

        #region retornaIdDaUltimaVenda

        public int retornaIdDaUltimaVenda()
        {
            try
            {
                int idultimavenda = 0;

                //1 passo - Definir o comando sql 

                string sql = @"select max(id) id from tb_vendas";

                //2 passo - Organizar comando sql e executar

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                //3 passo - Abrir conexão com o banco de dados

                conexao.Open();

                //4 passo - O MySqlDataReader receberá o dado resultando da execução do comando sql 

                MySqlDataReader rs = executacmd.ExecuteReader();

                // 5 passo - Caso consiga ler os dados dentro do MySqlDataReader capturar os dados necessários nos atributos do obj

                if(rs.Read() == true)
                {
                    idultimavenda = rs.GetInt32("id");
                    conexao.Close();
                    return idultimavenda;
                }
                else
                {
                    MessageBox.Show("Id da última venda não encontrado");
                    conexao.Close();
                    return 0;
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo algum erro:" + erro.Message);
                return 0;
            }
        }
        #endregion

        #region listarVendasPorPeriodo
        public DataTable listarVendasPorPeriodo(DateTime datainicio,DateTime datafim)
        {
            try
            {
                DataTable tabelahistorico = new DataTable();

                string sql = @"select  v.id as 'Código', 
                                       v.data_venda as 'Data da Venda',
                                       c.nome as 'Cliente',
                                       v.total_venda as 'Total',
                                       v.observacoes as 'Obs'
                                       from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)
                                       where v.data_venda between @datainicio and @datafim";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@datainicio", datainicio);
                executacmd.Parameters.AddWithValue("@datafim", datafim);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelahistorico);

                conexao.Close();

                return tabelahistorico;
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo o erro:" + erro.Message);
                return null; 
            }
        }
        #endregion

        #region listarVendas
        public DataTable listarVendas()
        {
            try
            {
                DataTable tabelavendas = new DataTable();

                string sql = @"select  v.id as 'Código', 
                                       v.data_venda as 'Data da Venda',
                                       c.nome as 'Cliente',
                                       v.total_venda as 'Total',
                                       v.observacoes as 'Obs' 
                                       from tb_vendas as v join tb_clientes as c 
                                       on (v.cliente_id = c.id)";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelavendas);
                conexao.Close();

                return tabelavendas;
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo o erro:" + erro.Message);
                conexao.Close();
                return null;
            }
            
        }
        
        
        #endregion





    }
}
