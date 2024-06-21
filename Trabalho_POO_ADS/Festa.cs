using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal  class Festa
    {
        public string Nome { get; set; }
        public int NumConvidados { get; set; }
        public Espaco Espaco { get; set; }
        public DateTime Data { get; set; }
        public double PrecoTotal { get; set; }
        public string tipoFesta { get; set; }

    public Festa(string nome, int numConvidados, DateTime data,string tipofesta)
        {
            Nome = nome;
            NumConvidados = numConvidados;
            tipoFesta = tipofesta;
        }

    }
}
