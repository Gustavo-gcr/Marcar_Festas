using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho_POO_ADS
{
    internal class GestorFesta
    {
        private List<Espaco> espacos;
        private static List<Festa> festas;
        private ConexaoBanco conexaoBanco;

        public GestorFesta()
        {
            InicializarEspacos();
            conexaoBanco = new ConexaoBanco();
            festas = new List<Festa>();
            conexaoBanco.PuxarDados(festas);
        }

        private void InicializarEspacos()
        {
            espacos = new List<Espaco>
        {       new Espaco('A', 100, 10000),
                new Espaco('B', 100, 10000),
                new Espaco('C', 100, 10000),
                new Espaco('D', 100, 10000),
                new Espaco('E', 200, 17000),
                new Espaco('F', 200, 17000),
                new Espaco('G', 50, 8000),
                new Espaco('H', 500, 35000)
        };
        }

        public string CalendarioDatas()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in festas)
            {
                sb.Append(item.Data.ToString());
                sb.Append(item.tipoFesta.ToString());
            }
            return sb.ToString();
        }

        public void ListarEspacosDisponiveis(DateTime data, int numConvidados)
        {
            var espacosDisponiveis = espacos.Where(e => e.Capacidade >= numConvidados && !FestaMarcadaNoDia(e, data));

            Console.WriteLine("Espaços disponíveis para a data escolhida:");
            foreach (var espaco in espacosDisponiveis)
            {
                Console.WriteLine($"{espaco.Identificador} - Capacidade: {espaco.Capacidade}");
            }
        }

        private bool FestaMarcadaNoDia(Espaco espaco, DateTime data)
        {
            return festas.Any(f => f.Espaco == espaco && f.Data.Date == data.Date);
        }

        public bool MarcarFesta(Festa festa, DateTime data)
        {
            
            if (festas.Any(f => f.Data == data))
            {
                Console.WriteLine("Data já está ocupada.");
                return false;
            }

            
            Espaco espaco = ProcurarEspacoDisponivel(festa.NumConvidados, data);
            if (espaco == null)
            {
                Console.WriteLine("Não há espaço disponível para o número de convidados informado.");
                return false;
            }

            
            festa.Espaco = espaco;
            festa.Data = data;
            festas.Add(festa);
            Console.WriteLine($"Festa marcada com sucesso para o espaço {espaco.Identificador}.");
            conexaoBanco.InserirDados(festas);

            return true;
        }
        public Espaco ProcurarEspacoDisponivel(int numConvidados, DateTime data)
        {
            if (numConvidados <= 0 || numConvidados > 500)
            {
                throw new Exception("Número de convidados inválido. Deve ser entre 1 e 500.");
            }

            
            var espacosReservados = festas
                .Where(festa => festa.Data.Date == data.Date)
                .Select(festa => festa.Espaco.Identificador)
                .ToList();

            
            if (numConvidados <= 50)
            {
                foreach (var espaco in espacos)
                {
                    if (espaco.Identificador == 'G' && !espacosReservados.Contains(espaco.Identificador))
                    {
                        return espaco;
                    }
                }
            }
            else if (numConvidados <= 100)
            {
                foreach (var espaco in espacos)
                {
                    if ((espaco.Identificador == 'A' || espaco.Identificador == 'B' || espaco.Identificador == 'C' || espaco.Identificador == 'D')
                        && !espacosReservados.Contains(espaco.Identificador))
                    {
                        return espaco;
                    }
                }
            }
            else if (numConvidados <= 200)
            {
                foreach (var espaco in espacos)
                {
                    if ((espaco.Identificador == 'E' || espaco.Identificador == 'F')
                        && !espacosReservados.Contains(espaco.Identificador))
                    {
                        return espaco;
                    }
                }
            }
            else if (numConvidados <= 500)
            {
                foreach (var espaco in espacos)
                {
                    if (espaco.Identificador == 'H' && !espacosReservados.Contains(espaco.Identificador))
                    {
                        return espaco;
                    }
                }
            }

            throw new Exception("Não há espaço disponível para o número de convidados informado.");



        }

       
        
    }
}