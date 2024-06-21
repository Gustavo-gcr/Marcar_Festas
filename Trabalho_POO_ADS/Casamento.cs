using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class Casamento : Festa
    {
        public Casamento(string nome, int numConvidados, DateTime data, string tipofesta)
       : base(nome, numConvidados, data, tipofesta)
        {
            tipoFesta = "Casamento";
        }
    }
}
