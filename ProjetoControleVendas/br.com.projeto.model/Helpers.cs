﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.model
{
    internal class Helpers
    {
        public void LimparTela(Form tela)
        {
            foreach(Control ctrpai in tela.Controls)
            {
                foreach(Control ctr1 in ctrpai.Controls)
                {
                    if(ctr1 is TabPage)
                    {
                        foreach(Control ctr2 in ctr1.Controls)
                        {
                            if(ctr2 is TextBox)
                            {
                                //Limpar o meu campo de texto
                                
                                (ctr2 as TextBox).Text = string.Empty;
                            }
                            if(ctr2 is MaskedTextBox)
                            {
                                //Limpar o meu campo de texto com mascara de formatação 
                                
                                (ctr2 as MaskedTextBox).Text = string.Empty;
                            }
                            if(ctr2 is ComboBox)
                            {
                                (ctr2 as ComboBox).Text = string.Empty;
                            }
                        }
                    }
                }
            }
        }







    }
}
