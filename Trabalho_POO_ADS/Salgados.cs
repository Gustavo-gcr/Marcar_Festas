using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class Salgados
    {
        private Dictionary<string, double> precoBaseSalgados;

        public Salgados()
        {
            precoBaseSalgados = new Dictionary<string, double>
        {
            {"Coxinha", 40.00},
            {"Kibe", 40.00},
            {"Empadinha", 40.00},
            {"Pão de queijo", 40.00},
            {"Croquete carne seca", 48.00},
            {"Barquetes legumes", 48.00},
            {"Empadinha gourmet", 48.00},
            {"Cestinha bacalhau", 48.00},
            {"Canapé", 60.00},
            {"Tartine", 60.00},
            {"Bruschetta", 60.00},
            {"Espetinho caprese", 60.00}
        };
        }

        public Dictionary<string, int> SolicitarQuantidadeComidas()
        {
            var comidasSelecionadas = new Dictionary<string, int>();

            

            foreach (var item in precoBaseSalgados)
            {
                Console.WriteLine($"{item.Key} - R${item.Value:F2} por pessoa");
                Console.Write($"Quantas pessoas para {item.Key}: ");
                int quantidade;
                while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
                {
                    Console.WriteLine("Entrada inválida. Digite um número inteiro positivo.");
                    Console.Write($"Quantas pessoas para {item.Key}: ");
                }

                if (quantidade > 0)
                {
                    comidasSelecionadas.Add(item.Key, quantidade);
                }
            }

            return comidasSelecionadas;
        }
    }
}
