using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_ADS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorFesta gestor = new GestorFesta();
            ConexaoBanco conexaoBanco = new ConexaoBanco();

            char consulta = 's';

            do
            {
                try
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("1) Cadastrar nova Festa\n2) Exibir datas");
                    Console.WriteLine("--------------------------------------------");
                    int a = int.Parse(Console.ReadLine());
                    if(a == 2)
                    {
                        Console.WriteLine(gestor.CalendarioDatas());
                    }
                    else if(a == 1)
                    {
                        Console.WriteLine("--------------------------------------------");

                        Console.WriteLine("Insira o nome do cliente:");
                        string nomeCliente = Console.ReadLine();
                        Console.WriteLine("Insira o número de convidados:");
                        int numConvidados = int.Parse(Console.ReadLine());

                        Agendar agendar = new Agendar();
                        agendar.Nome = nomeCliente;
                        agendar.NumConvidados = numConvidados;

                        agendar.ImprimirDatasDisponiveis();

                        Console.WriteLine("\nPor favor, escolha uma data para o evento:");
                        Console.WriteLine("Insira o número correspondente à data desejada:");
                        int escolhaData = int.Parse(Console.ReadLine());
                        DateTime dataEscolhida = agendar.ProximasDatasDisponiveis()[escolhaData];

                        Espaco espacoDisponivel = gestor.ProcurarEspacoDisponivel(numConvidados, dataEscolhida);
                        if (espacoDisponivel == null)
                        {
                            throw new Exception("Nenhum espaço disponível para a data e número de convidados informados.");
                        }

                        Console.WriteLine("--------------------------------------------");

                        Console.WriteLine("Escolha o tipo de festa:");
                        Console.WriteLine("1. Casamento");
                        Console.WriteLine("2. Formatura");
                        Console.WriteLine("3. Festa de empresa");
                        Console.WriteLine("4. Festa de aniversário");
                        Console.WriteLine("5. Livre");

                        Console.WriteLine("--------------------------------------------");

                        int tipoFesta = int.Parse(Console.ReadLine());

                        Festa festa;
                        switch (tipoFesta)
                        {
                            case 1:
                                Console.WriteLine("Opção CASAMENTO escolhida!");
                                festa = new Casamento(nomeCliente, numConvidados, dataEscolhida,"Casamento");

                                break;
                            case 2:
                                Console.WriteLine("Opção FORMATURA escolhida!");
                                festa = new Formatura(nomeCliente, numConvidados, dataEscolhida,"Formatura");
                                break;
                            case 3:
                                Console.WriteLine("Opção FESTA DE EMPRESA escolhida!");
                                festa = new FestaEmpresa(nomeCliente, numConvidados, dataEscolhida, "Festa Empresa");
                                break;
                            case 4:
                                Console.WriteLine("Opção FESTA DE ANIVERSÁRIO escolhida!");
                                festa = new Aniversario(nomeCliente, numConvidados, dataEscolhida, "Aniversário");
                                break;
                            case 5:
                                Console.WriteLine("Opção LIVRE escolhida!");
                                festa = new Livre(nomeCliente, numConvidados, dataEscolhida,"Livre");
                                break;
                            default:
                                Console.WriteLine("Opção incorreta!");
                                continue;
                        }



                        if (tipoFesta == 5)
                        {
                            Console.WriteLine("LIVRE: esse espaço nao da direito a bebida e comida");
                        }
                        else
                        {
                            // Solicitar informações sobre comidas e bebidas
                            Dictionary<string, int> comidas = new Dictionary<string, int>();
                            Dictionary<string, int> bebidas = new Dictionary<string, int>();

                            Console.WriteLine("Escolha os salgados para a festa:");
                            Salgados salgados = new Salgados();
                            comidas = salgados.SolicitarQuantidadeComidas();

                            Console.WriteLine("Escolha as bebidas para a festa:");
                            GerenciadorBebidas gerenciadorBebidas = new GerenciadorBebidas(tipoFesta);
                            bebidas = gerenciadorBebidas.SolicitarQuantidadeBebidas();
                            // Calcular e imprimir detalhes da festa
                            CalculoPreco cal = new CalculoPreco();
                            cal.CalcularPrecoTotal(espacoDisponivel, tipoFesta, comidas, bebidas);
                        }


                        // Tentar marcar a festa
                        bool festaMarcada = gestor.MarcarFesta(festa, dataEscolhida);
                        Console.WriteLine("PASSEI POR AQUI");
                        if (festaMarcada)
                        {
                            Console.WriteLine("Festa marcada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Desculpe, não foi possível marcar a festa.");
                        }
                    }
                    else
                    {
                        throw new Exception("Não existe essa opção");
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

                Console.WriteLine("--------------------------------------------");

                do
                {
                    Console.WriteLine("Consulta realizada com sucesso. Se quiser continuar digite (s) se quiser finalizar digite (n).");
                    consulta = char.Parse(Console.ReadLine().ToLower());
                    if (consulta != 's' && consulta != 'n')
                    {
                        Console.WriteLine("Entrada inválida. Digite 's' para continuar ou 'n' para finalizar.");
                    }
                } while (consulta != 's' && consulta != 'n');

            } while (consulta != 'n');
            Console.WriteLine("Fim da Execução do programa, obrigado pela participação!");
            Console.ReadKey();
        }
    }
}










