using NUnit.Framework;
using MySql.Data.MySqlClient;
using System;

namespace TestProject1
{
    public class EspacoTests
    {
        private MySqlConnection connection;

        [SetUp]
        public void Setup()
        {
            string connectionString = "Server=localhost;Database=db_festa;User ID=root;Password=your_password;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        [TearDown]
        public void TearDown()
        {
            connection.Close();
        }

        [Test]
        public void InserirEspacoTest()
        {
            string identificador = "ESP001";
            int capacidade = 100;
            double preco = 200.0;
            bool disponivel = true;

            string query = "INSERT INTO Espaco (Identificador, Capacidade, Preco, Disponivel) VALUES (@Identificador, @Capacidade, @Preco, @Disponivel)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Identificador", identificador);
            cmd.Parameters.AddWithValue("@Capacidade", capacidade);
            cmd.Parameters.AddWithValue("@Preco", preco);
            cmd.Parameters.AddWithValue("@Disponivel", disponivel);

            int result = cmd.ExecuteNonQuery();

            Assert.AreEqual(1, result, "A inserção do espaço falhou.");
        }

        [Test]
        public void VerificarEspacoInseridoTest()
        {
            string identificador = "ESP001";
            string query = "SELECT * FROM Espaco WHERE Identificador = @Identificador";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Identificador", identificador);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Assert.IsTrue(reader.HasRows, "O espaço não foi encontrado.");
                while (reader.Read())
                {
                    Assert.AreEqual(identificador, reader["Identificador"]);
                    Assert.AreEqual(100, reader["Capacidade"]);
                    Assert.AreEqual(200.0, reader["Preco"]);
                    Assert.AreEqual(true, reader["Disponivel"]);
                }
            }
        }
    }
}