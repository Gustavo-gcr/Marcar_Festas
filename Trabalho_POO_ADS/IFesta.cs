using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal abstract class Festa
    {
        public string Nome { get; set; }
        public int NumConvidados { get; set; }
        public DateTime Data { get; set; }
        public Espaco Espaco { get; set; }

        public abstract double CalcularPrecoTotal(Dictionary<string, int> comidas, Dictionary<string, int> bebidas);
    }
}
