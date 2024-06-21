using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class Aniversario : Festa
    {
        public Aniversario(string nome, int numConvidados, DateTime data, string tipofesta)
       : base(nome, numConvidados, data, tipofesta)
        {
            tipoFesta = "Aniversario";
        }
    }
}
