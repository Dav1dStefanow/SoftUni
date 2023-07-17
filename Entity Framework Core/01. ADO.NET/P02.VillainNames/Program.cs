using Microsoft.Data.SqlClient;
using System;

namespace P02.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS; Integrated Security=true; Database=MinionsDB; TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT v.Name, COUNT(m.Name) AS MinionsCount FROM Villains AS v
            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
            JOIN Minions AS m ON m.Id = mv.MinionId
            GROUP BY v.Name";

            SqlCommand command = new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }
        }
    }
}
