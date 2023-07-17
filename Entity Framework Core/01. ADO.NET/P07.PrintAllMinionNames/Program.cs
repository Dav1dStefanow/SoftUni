using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.PrintAllMinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS; Database=MinionsDB; Integrated Security=true; TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int count;
            FindAllMinionsCount(connection, out count);
            string result = PrintAllMinions(connection, count);
            Console.WriteLine(result);
        }
        public static void FindAllMinionsCount(SqlConnection connection, out int count)
        {
            string query = @"SELECT COUNT(*) FROM Minions";
            SqlCommand command = new SqlCommand(query, connection);
            count = (int)command.ExecuteScalar();
        }
        public static string PrintAllMinions(SqlConnection connection, int count)
        {
            StringBuilder sb = new StringBuilder();
            string query = @"SELECT Name FROM Minions";
            SqlCommand command = new SqlCommand(query, connection);
            var minions = new List<string>();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            for (int i = 0; i < count / 2; i++)
            {
                sb.AppendLine(minions[i]);
                sb.AppendLine(minions[minions.Count - i - 1]);
            }
            return sb.ToString();
        }
    }
}
