using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{

    public abstract class TipoCasamento
    {
        public string Nome { get; set; }
        public TipoCasamento(string nome)
        {
            Nome = nome;
        }
    }
}

