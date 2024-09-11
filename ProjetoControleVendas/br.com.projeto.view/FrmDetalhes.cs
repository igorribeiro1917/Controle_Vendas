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
    public partial class FrmDetalhes : Form
    {
        int vendaid;
        public FrmDetalhes(int vendaid)
        {
            InitializeComponent();

            this.vendaid = vendaid;
        }

        private void FrmDetalhes_Load(object sender, EventArgs e)
        {
            ItemVendaDAO itemdao = new ItemVendaDAO();

            tabelaDetalhes.DataSource = itemdao.retornaItensPorVenda(vendaid);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
