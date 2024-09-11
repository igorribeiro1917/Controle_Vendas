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
    public partial class FrmVendas : Form
    {
        //Objetos Cliente e ClienteDAO

        Cliente cliente = new Cliente();
        ClienteDAO cdao = new ClienteDAO();

        //Objetos Produto e ProdutoDAO

        Produto produto = new Produto();
        ProdutoDAO pdao = new ProdutoDAO();

        //Variaveis 
        int qtd;
        decimal preco;
        decimal subtotal;
        decimal total;

        //Representacao do DataGridView na memoria

        DataTable carrinho = new DataTable();
        
        public FrmVendas()
        {
            InitializeComponent();

            //Adicionando as colunas que serão exibidas no DataGridView 
            
            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("SubTotal", typeof(decimal));

            tabelaVendas.DataSource = carrinho;
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //KeyChar = Retorna a tecla apertada pelo usuário "13" = Representação numérica da tecla ENTER

            if (e.KeyChar == 13)
            {
                cliente = cdao.retornaClientePorCpf(txtcpf.Text);
                
                if (cliente != null)
                {
                    txtnome.Text = cliente.Nome;
                }
                else
                {
                    txtcpf.Clear();
                    txtcpf.Focus();
                }
            }
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                produto = pdao.retornaProdutoPorCodigo(int.Parse(txtcodigo.Text));

                if (produto != null)
                {
                    txtdesc.Text = produto.descricao;
                    txtpreco.Text = produto.preco.ToString();
                }
                else
                {
                    txtcodigo.Clear();
                    txtcodigo.Focus();
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                //Botão Adicionar Item 

                qtd = int.Parse(txtqtd.Text);
                preco = Decimal.Parse(txtpreco.Text);
                subtotal = preco * qtd;
                total += subtotal;

                //Adicionar Produto no carrinho

                carrinho.Rows.Add(int.Parse(txtcodigo.Text), txtdesc.Text, qtd, preco, subtotal);

                txttotal.Text = total.ToString();

                //Limpar Campos

                txtcodigo.Clear();
                txtdesc.Clear();
                txtqtd.Clear();
                txtpreco.Clear();

                txtcodigo.Focus();
            }
            catch(Exception erro)
            {
                MessageBox.Show("Digite o código do pruduto");
            }
        }

        private void btnremover_Click(object sender, EventArgs e)
        {
            //Botão Remover Item

            //passo 1 - Acessar o valor da coluna subtotal do DataGridView
            
            decimal subproduto = decimal.Parse(tabelaVendas.CurrentRow.Cells[4].Value.ToString());

            //passo 2 - Acessar o índice da linha selecionada no DataGridView 
            
            int indice = tabelaVendas.CurrentRow.Index;

            //passo 3 - Acessar o conteúdo da linha no DataTable por meio do índice 
            
            DataRow linha = carrinho.Rows[indice];

            //passso 4 - Remover a linha do DataTable
            
            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            //passo 5 - Subtrair o preço do produto removido do total 
            
            total -= subproduto;

            txttotal.Text = total.ToString();

            MessageBox.Show("Item Removido do carrinho com sucesso");

        }

        private void btnpagamento_Click(object sender, EventArgs e)
        {
            //Botão Pagamento

            DateTime dataatual = DateTime.Parse(txtdata.Text);

            FrmPagamentos tela = new FrmPagamentos(cliente,carrinho,dataatual);

            //Passando o total da tela de vendas para a tela de pagamento 

            tela.txttotal.Text = total.ToString();
            
            tela.ShowDialog();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            //Pegando a data atual

            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void txtcpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
