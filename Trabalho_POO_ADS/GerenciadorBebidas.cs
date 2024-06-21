using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class GerenciadorBebidas
    {
        private Dictionary<string, double> precoBebidas;

        public GerenciadorBebidas(int tipoFesta)
        {
            switch (tipoFesta)
            {
                case 1:
                    precoBebidas = new Dictionary<string, double>
                    {
                        {"Água sem gás (1,5l)", 5.00},
                        {"Suco (1L)", 7.00},
                        {"Refrigerante (2l)", 8.00},
                        {"Cerveja Comum (600ml)", 20.00},
                        {"Cerveja Artesanal (600ml)", 30.00},
                        {"Espumante Nacional (750ml)", 80.00},
                        {"Espumante Importado (750ml)", 140.00}
                    };
                    break;
                case 2:
                    precoBebidas = new Dictionary<string, double>
                    {
                        {"Água sem gás (1,5l)", 5.00},
                        {"Suco (1L)", 7.00},
                        {"Refrigerante (2l)", 8.00},
                        {"Cerveja Comum (600ml)", 20.00},
                        {"Cerveja Artesanal (600ml)", 30.00},
                        {"Espumante Nacional (750ml)", 80.00},
                        {"Espumante Importado (750ml)", 140.00}
                    };
                    break;
                case 3:
                    precoBebidas = new Dictionary<string, double>
                    {
                        {"Água sem gás (1,5l)", 5.00},
                        {"Suco (1L)", 7.00},
                        {"Refrigerante (2l)", 8.00},
                        {"Cerveja Comum (600ml)", 20.00},
                        {"Cerveja Artesanal (600ml)", 30.00},
                        {"Espumante Nacional (750ml)", 80.00},
                        {"Espumante Importado (750ml)", 140.00}
                    };
                    break;
                case 4:
                    precoBebidas = new Dictionary<string, double>
                    {
                        {"Água sem gás (1,5l)", 5.00},
                        {"Suco (1L)", 7.00},
                        {"Refrigerante (2l)", 8.00},
                        {"Cerveja Comum (600ml)", 20.00},
                        {"Cerveja Artesanal (600ml)", 30.00},
                        {"Espumante Nacional (750ml)", 80.00},
                        {"Espumante Importado (750ml)", 140.00}
                    };
                    break;
                default:
                    throw new ArgumentException("Tipo de festa não reconhecido.");
            }
        }

        

     

        public Dictionary<string, int> SolicitarQuantidadeBebidas()
        {
            var bebidasSelecionadas = new Dictionary<string, int>();

            if (precoBebidas.Count > 0) 
            {
                Console.WriteLine("Escolha as bebidas para a festa:");

                foreach (var item in precoBebidas)
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
                        bebidasSelecionadas.Add(item.Key, quantidade);
                    }
                }
            }

            return bebidasSelecionadas;
        }

        public double CalcularTotalBebida(Dictionary<string, int> bebidas)
        {
            double total = 0;

            foreach (var bebida in bebidas)
            {
                total += bebida.Value * precoBebidas[bebida.Key];
            }

            return total;
        }
    }
}
