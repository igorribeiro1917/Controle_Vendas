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

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmPagamentos : Form
    {
        Cliente cliente = new Cliente(); 
        DataTable carrinho = new DataTable();
        DateTime dataatual;
        
        public FrmPagamentos(Cliente cliente, DataTable carrinho, DateTime dataatual)
        {
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dataatual = dataatual;
            InitializeComponent();
        }

        private void txtpreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            //Botão Finalizar Venda 

            try
            {
                decimal v_dinheiro; decimal v_cartao; decimal troco; decimal totalpago; decimal total;
                int qtd_estoque; int qtd_comprada; int estoque_atualizado;

                v_dinheiro = decimal.Parse(txtdinheiro.Text);
                v_cartao = decimal.Parse(txtcartao.Text);
                total = decimal.Parse(txttotal.Text);

                //Calcular o total pago

                totalpago = v_dinheiro + v_cartao;

               //Calcular o troco

                if(totalpago < total)
                {
                    MessageBox.Show("O total pago é menor do que o total da compra");
                }
                else
                {
                    troco = totalpago - total;

                    //Salvar Venda no Banco de Dados

                    Venda vendas = new Venda();

                    vendas.cliente_id = cliente.Codigo;
                    vendas.data_venda = dataatual;
                    vendas.total_venda = total;
                    vendas.observacao = txtobs.Text;

                    VendaDAO vdao = new VendaDAO();

                    txttroco.Text = troco.ToString();
                    
                    vdao.cadastraVenda(vendas);

                    //Cadastrar itens da venda
                    //Percorrendo os itens do carrinho(DataTable)

                    foreach(DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda();
                        item.venda_id = vdao.retornaIdDaUltimaVenda();
                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd = int.Parse(linha["Qtd"].ToString());
                        item.subtotal = decimal.Parse(linha["Subtotal"].ToString());

                        //Baixa no Estoque

                        ProdutoDAO produto_DAO = new ProdutoDAO();

                        qtd_estoque = produto_DAO.retornaEstoqueAtual(item.produto_id);
                        qtd_comprada = item.qtd;
                        estoque_atualizado = qtd_estoque - qtd_comprada;

                        produto_DAO.baixaEstoque(item.produto_id, estoque_atualizado);

                        ItemVendaDAO itemdao = new ItemVendaDAO();

                        itemdao.cadastrarItemVenda(item);
                    }
                    MessageBox.Show("Venda finalizada com sucesso");
                    
                    //Fecha a página de pagamento
                    
                    this.Dispose();

                    //Instancia um novo formulário de vendas
                    
                    new FrmVendas().ShowDialog();
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show("Está acontecendo algum erro:" + erro.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPagamentos_Load(object sender, EventArgs e)
        {
            //Carrega tela de pagamentos
            
            txtcartao.Text = "0.00";
            txtdinheiro.Text = "0.00";
            txtcartao.Text = "0.00";
        }
    }
}
