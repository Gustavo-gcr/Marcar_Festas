using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{

    internal class Espaco
    {
        public char Identificador { get;  set; }
        public int Capacidade { get;  set; }
        public double Preco { get;  set; }

        public bool Disponivel {  get;  set; }


        public Espaco(char identificador, int capacidade, double preco)
        {
            Identificador = identificador;
            Capacidade = capacidade;
            Preco = preco;
        }
    }
}


