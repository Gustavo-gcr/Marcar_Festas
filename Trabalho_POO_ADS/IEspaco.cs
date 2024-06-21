using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{

    internal class Espaco
    {
        public char Identificador { get; private set; }
        public int Capacidade { get; private set; }
        public double Preco { get; private set; }
        public bool Disponivel { get; set; }
        public List<DateTime> DatasIndisponiveis { get; set; }
        public Espaco(char identificador, int capacidade, double preco)
        {
            Identificador = identificador;
            Capacidade = capacidade;
            Preco = preco;
            Disponivel = true;
            DatasIndisponiveis = new List<DateTime>();
        }
        public bool IsDisponivel(DateTime data)
        {
            return !DatasIndisponiveis.Contains(data);
        }
    }
}

