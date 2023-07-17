using Microsoft.Data.SqlClient;
using System;
using System.Net.Http.Headers;

namespace P03.MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS; Integrated Security=true; Database=MinionsDB; TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int villainId = int.Parse(Console.ReadLine());

            string commandString = @"SELECT v.Name AS VillainName, m.Name AS MinionName, m.Age AS MinionAge FROM Villains AS v
            JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
            JOIN Minions AS m ON m.Id = mv.MinionId
            WHERE v.Id = @Id
            ORDER BY v.Name";

            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.Add(new SqlParameter("@Id", villainId));

            string query = "SELECT COUNT(*) FROM Villains WHERE Id = @Id";
            SqlCommand command2 = new SqlCommand(query, connection);
            command2.Parameters.Add(new SqlParameter("@Id", villainId));
            int result = (int)command2.ExecuteScalar();
            if (result == 1)
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    Console.WriteLine($"Villain: {reader["VillainName"]}");
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }

                    int count = 1;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{count}. {reader["MinionName"]} {reader["MinionAge"]}");
                        count++;
                    }
                }
            }
            else Console.WriteLine($"No villain with ID {villainId} exists in the database.");

        }
    }
}
