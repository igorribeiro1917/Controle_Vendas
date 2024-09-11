using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleVendas.br.com.projeto.model
{
    internal class Produto
    {
        public int id { get; set; }

        public string descricao { get; set; }

        public decimal preco { get; set; }

        public int qtdestoque { get; set; }

        public int for_id { get; set; }
    }
}
