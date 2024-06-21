using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho_POO_ADS
{
    internal class ConexaoBanco
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        string data_source = "datasource=localhost;username=root;password=Hacker.123;database=db_festa";

        public ConexaoBanco()
        {
            conexao = new MySqlConnection(data_source);
        }
        public void PuxarDados(List<Festa> lista)
        {

            try
            {
                conexao.Open();
                string sql = "SELECT f.*, e.Identificador, e.Capacidade, e.Preco, e.Disponivel, f.TipoFesta FROM festa f INNER JOIN Espaco e ON f.EspacoId = e.Identificador";
                comando = new MySqlCommand(sql, conexao);
                
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        string Nome = reader["Nome"].ToString();
                        int NumConvidados = (int)reader["NumConvidados"];
                        double PrecoTotal = (double)reader["PrecoTotal"];
                        DateTime Data = (DateTime)reader["Data"];
                        string TipoFesta = (string)reader["TipoFesta"];

                        char Identificador = Convert.ToChar(reader["Identificador"]);
                        int Capacidade = (int)reader["Capacidade"];
                        double Preco = (double)reader["Preco"];
                        bool Disponivel = (bool)reader["Disponivel"];

                        Espaco espaco = new Espaco(Identificador,Capacidade,Preco);
                        Festa festa = new Festa(Nome,NumConvidados,Data,TipoFesta);
                        festa.PrecoTotal = PrecoTotal;
                        espaco.Disponivel = Disponivel;
                        festa.Espaco = espaco;

                        lista.Add(festa);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
        public void InserirDados(List<Festa> lista)
        {
            try
            {
                conexao.Open();
                    Festa festa = lista.LastOrDefault();
                    string Nome = festa.Nome;
                    int NumConvidados = festa.NumConvidados;
                    double PrecoTotal = festa.PrecoTotal;
                    DateTime Data = festa.Data;

                    char Identificador = festa.Espaco.Identificador;
                    int Capacidade = festa.Espaco.Capacidade;
                    double Preco = festa.Espaco.Preco;
                    bool Disponivel = festa.Espaco.Disponivel;
                    string tipoFesta = festa.tipoFesta;

                    
                    string sqlEspaco = "INSERT INTO Espaco (Identificador, Capacidade, Preco, Disponivel) VALUES (@Identificador, @Capacidade, @Preco, @Disponivel)";
                    using (MySqlCommand comando = new MySqlCommand(sqlEspaco, conexao))
                    {
                        comando.Parameters.AddWithValue("@Identificador", Identificador);
                        comando.Parameters.AddWithValue("@Capacidade", Capacidade);
                        comando.Parameters.AddWithValue("@Preco", Preco);
                        comando.Parameters.AddWithValue("@Disponivel", Disponivel);
                        comando.ExecuteNonQuery();
                    }

                    
                    string sqlFesta = "INSERT INTO Festa (Nome, NumConvidados, Data, PrecoTotal, EspacoId, TipoFesta) VALUES (@Nome, @NumConvidados, @Data, @PrecoTotal, @EspacoId, @TipoFesta)";
                    using (MySqlCommand comando = new MySqlCommand(sqlFesta, conexao))
                    {
                        comando.Parameters.AddWithValue("@Nome", Nome);
                        comando.Parameters.AddWithValue("@NumConvidados", NumConvidados);
                        comando.Parameters.AddWithValue("@Data", Data);
                        comando.Parameters.AddWithValue("@PrecoTotal", PrecoTotal);
                        comando.Parameters.AddWithValue("@EspacoId", Identificador);
                        comando.Parameters.AddWithValue("@TipoFesta", tipoFesta); 
                        comando.ExecuteNonQuery();
                    }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }




    }
}
