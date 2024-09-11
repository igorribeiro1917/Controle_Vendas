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

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class FrmHistorico : Form
    {
        DataTable historicovenda = new DataTable();
        
        public FrmHistorico()
        {
            InitializeComponent();

            historicovenda.Columns.Add("Código", typeof(int));
            historicovenda.Columns.Add("Data da Venda", typeof(string));
            historicovenda.Columns.Add("Cliente", typeof(string));
            historicovenda.Columns.Add("Total", typeof(decimal));
            historicovenda.Columns.Add("Obs", typeof(string));

            tabelaHistorico.DataSource = historicovenda;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            DateTime datainicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy-MM-dd"));
            DateTime datafim = Convert.ToDateTime(dtFim.Value.ToString("yyyy-MM-dd"));

            VendaDAO vdao = new VendaDAO();

            tabelaHistorico.DataSource = vdao.listarVendasPorPeriodo(datainicio, datafim);
            
        }

        private void FrmHistorico_Load(object sender, EventArgs e)
        {
            //Exibe todas as vendas antes da consulta 
            
            VendaDAO vdao = new VendaDAO();

            tabelaHistorico.DataSource = vdao.listarVendas();
        }

        private void tabelaHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1 Passo - Abrir um outro formulário
            //Passando o id da venda
            
            int venda_id = int.Parse(tabelaHistorico.CurrentRow.Cells[0].Value.ToString());

            FrmDetalhes tela = new FrmDetalhes(venda_id);

            // 2 Passo - Pegar as informações do DataGridView da tela de histórico e transferir para página de detalhes

            DateTime datavenda = Convert.ToDateTime(tabelaHistorico.CurrentRow.Cells[1].Value.ToString());

            tela.txtdata.Text = datavenda.ToString("dd/MM/yyyy");
            tela.txtcliente.Text = tabelaHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txttotal.Text = tabelaHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtobs.Text = tabelaHistorico.CurrentRow.Cells[4].Value.ToString();
            
            tela.ShowDialog();
        }
    }
}
