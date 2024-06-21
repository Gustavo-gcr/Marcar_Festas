using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class CalculoPreco
    {
        
        public void CalcularPrecoTotal(Espaco espaco, int tipoFesta, Dictionary<string, int> comidas, Dictionary<string, int> bebidas)
        {
            double precoEspaco = espaco != null ? espaco.Preco : 0;
            double precoItensFesta = 0;
            double precoComidas = 0;
            double precoBebidas = 0;

            if (tipoFesta != 5)
            {
                GerenciadorBebidas gerenciadorBebidas = new GerenciadorBebidas(tipoFesta);
                
                precoItensFesta = CalcularPrecoItensFesta(tipoFesta, espaco.Capacidade);

                
                precoComidas = CalcularPrecoComidas(comidas, tipoFesta);

               
                Dictionary<string, int> bebidasSelecionadas = gerenciadorBebidas.SolicitarQuantidadeBebidas();
                precoBebidas = gerenciadorBebidas.CalcularTotalBebida(bebidasSelecionadas);

                double precoTotal = precoEspaco + precoItensFesta + precoComidas + precoBebidas;

                Console.WriteLine($"Valor do espaço: R${precoEspaco:F2}");
                Console.WriteLine($"Valor total dos itens da festa: R${precoItensFesta:F2}");
                Console.WriteLine($"Valor total das bebidas: R${precoBebidas:F2}");
                Console.WriteLine($"Valor total das comidas: R${precoComidas:F2}");
                Console.WriteLine($"Valor total da festa: R${precoTotal:F2}");
            }
            else
            {
                Console.WriteLine($"Valor do espaço: R${precoEspaco:F2}");
            }
        }
       
        private double CalcularPrecoComidas(Dictionary<string, int> comidas, int festa)
        {
            double total = 0;
            double precoBase = 0;

            switch (festa)
            {
                case 1:
                    precoBase = 60;
                    break;
                case 2:
                    precoBase = 50;
                    break;
                case 3:
                    precoBase = 45;
                    break;
                case 4:
                    precoBase = 40;
                    break;
                case 5:
                    return 0;  
                default:
                    throw new ArgumentException("Tipo de festa não reconhecido.");
            }

            foreach (var comida in comidas)
            {
                total += precoBase * comida.Value;
            }

            return total;
        }
        private double CalcularPrecoComidas(Dictionary<string, int> comidas, TipoCasamento casamento)
        {
            double total = 0;
            double precoBase = 0;

            switch (casamento.Nome)
            {
                case "Standard":
                    precoBase = 60;
                    break;
                case "Luxo":
                    precoBase = 80;
                    break;
                case "Premium":
                    precoBase = 100;
                    break;
                case "Livre":
                    return 0;  
                default:
                    throw new ArgumentException("Tipo de casamento não reconhecido.");
            }

            foreach (var comida in comidas)
            {
                total += precoBase * comida.Value;
            }

            return total;
        }


        private double CalcularPrecoItensFesta(int festa, int capacidade)
        {
            double precoItemMesa = 0, precoDecoracao = 0, precoBolo = 0, precoMusica = 0;

            switch (festa)
            {
                case 1:
                    precoItemMesa = 100;
                    precoDecoracao = 100;
                    precoBolo = 20;
                    precoMusica = 30;
                    break;
                case 2:
                    precoItemMesa = 75;
                    precoDecoracao = 75;
                    precoBolo = 0;  
                    precoMusica = 25;
                    break;
                case 3:
                    precoBolo = 0;
                    precoItemMesa = 0;
                    precoDecoracao = 0;
                    precoMusica = 30;
                    break;
                case 4:
                    precoItemMesa = 50;
                    precoDecoracao = 50;
                    precoBolo = 10;
                    precoMusica = 20;
                    break;
                case 5:
                    precoItemMesa = 0;
                    precoDecoracao = 0;
                    precoBolo = 0;
                    precoMusica = 0;
                    break;
                default:
                    throw new ArgumentException("Tipo de festa não reconhecido.");
            }

            return (precoItemMesa + precoDecoracao + precoBolo + precoMusica) * capacidade;
        }

        private double CalcularPrecoItensFesta(TipoCasamento casamento, int capacidade)
        {
            double precoItemMesa = 0, precoDecoracao = 0, precoBolo = 0, precoMusica = 0;

            switch (casamento.Nome)
            {
                case "Standard":
                    precoItemMesa = 100;
                    precoDecoracao = 100;
                    precoBolo = 20;
                    precoMusica = 30;
                    break;
                case "Luxo":
                    precoItemMesa = 150;
                    precoDecoracao = 150;
                    precoBolo = 30;
                    precoMusica = 40;
                    break;
                case "Premium":
                    precoItemMesa = 200;
                    precoDecoracao = 200;
                    precoBolo = 40;
                    precoMusica = 50;
                    break;
                case "Livre":
                    precoItemMesa = 0;
                    precoDecoracao = 0;
                    precoBolo = 0;
                    precoMusica = 0;
                    break;
                default:
                    throw new ArgumentException("Tipo de casamento não reconhecido.");
            }

            return (precoItemMesa + precoDecoracao + precoBolo + precoMusica) * capacidade;
        }

        private double CalcularPrecoBebidas(Dictionary<string, int> bebidas, Festa festa)
        {
            double precoTotal = 0;
            double precoBase = 0;

            switch (festa.Nome)
            {
                case "Casamento":
                    precoBase = 100;
                    break;
                case "Formatura":
                    precoBase = 80;
                    break;
                case "FestaEmpresa":
                    precoBase = 60;
                    break;
                case "Aniversario":
                    precoBase = 50;
                    break;
                case "Livre":
                    return 0;  
                default:
                    throw new ArgumentException("Tipo de festa não reconhecido.");
            }

            foreach (var bebida in bebidas)
            {
                precoTotal += precoBase * bebida.Value;
            }

            return precoTotal;
        }

        private double CalcularPrecoBebidas(Dictionary<string, int> bebidas, TipoCasamento casamento)
        {
            double precoTotal = 0;
            double precoBase = 0;

            switch (casamento.Nome)
            {
                case "Standard":
                    precoBase = 100;
                    break;
                case "Luxo":
                    precoBase = 150;
                    break;
                case "Premium":
                    precoBase = 200;
                    break;
                case "Livre":
                    return 0;  
                default:
                    throw new ArgumentException("Tipo de casamento não reconhecido.");
            }

            foreach (var bebida in bebidas)
            {
                precoTotal += precoBase * bebida.Value;
            }

            return precoTotal;




        }
    }
}
