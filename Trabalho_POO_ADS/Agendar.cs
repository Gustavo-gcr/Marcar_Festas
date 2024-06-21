using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class Agendar
    {
        private List<DateTime> datasDisponiveis;

        public string Nome { get; set; }
        public int NumConvidados { get; set; }

        public Agendar()
        {
            datasDisponiveis = new List<DateTime>();
            InicializarDatasDisponiveis();
        }
        private void InicializarDatasDisponiveis()
        {
            DateTime dataAtual = DateTime.Today.AddDays(30); // Primeira data disponível em 30 dias
            int count = 0;

            while (datasDisponiveis.Count < 12)
            {
                if (dataAtual.DayOfWeek == DayOfWeek.Friday || dataAtual.DayOfWeek == DayOfWeek.Saturday)
                {
                    datasDisponiveis.Add(dataAtual);
                    count++;
                }
                dataAtual = dataAtual.AddDays(1);
            }
        }

        public void ImprimirDatasDisponiveis()
        {
            Console.WriteLine("Próximas 12 sextas-feiras e sábados disponíveis:");

            for (int i = 0; i < datasDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {datasDisponiveis[i].ToString("dd/MM/yyyy")} ({datasDisponiveis[i].DayOfWeek})");
            }
        }

        public List<DateTime> ProximasDatasDisponiveis()
        {
            return datasDisponiveis;
        }
    }
}




