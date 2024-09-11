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
    internal class ItemVendaDAO
    {
        private MySqlConnection conexao;

        public ItemVendaDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region cadastrarItemVenda
        public void cadastrarItemVenda(ItemVenda obj)
        {
            try
            {
                //Passo 1 - Criar comando sql

                string sql = @"insert into tb_itensvendas (venda_id,produto_id,qtd,subtotal) 
                               values(@venda_id,@produto_id,@qtd,@subtotal)";

                //Passo 2 - Organizar o comando sql

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@venda_id", obj.venda_id);
                executacmd.Parameters.AddWithValue("@produto_id", obj.produto_id);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtd);
                executacmd.Parameters.AddWithValue("@subtotal", obj.subtotal);

                //Passo 3 - Abrir conexao e executar comando sql

                conexao.Open();
                executacmd.ExecuteNonQuery();
                MessageBox.Show("Item de venda cadastrado com sucesso");

                conexao.Close();
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo algum erro:" + erro.Message);
            }
        }
        #endregion

        #region retornaItensPorVenda

        public DataTable retornaItensPorVenda(int vendaid)
        {
            try
            {
                DataTable tabelaitemvenda = new DataTable();

                string sql = @" select i.id as 'Código',
                                       p.descricao as 'Descrição',
                                       i.qtd as 'Quantidade',
                                       p.preco as 'Preço', 
                                       i.subtotal as 'Subtotal'  
                                       from  tb_itensvendas as i join tb_produtos as p on (i.produto_id = p.id)
                                       where i.venda_id = @venda_id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@venda_id", vendaid);
                    
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaitemvenda);

                conexao.Close();

                return tabelaitemvenda;
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
