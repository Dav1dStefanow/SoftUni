using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace P05.ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS; Integrated Security=true; Database=MinionsDB; TrustServerCertificate=True;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string country = Console.ReadLine();
            string result = PrintTownNamesFromCountry(sqlConnection, country);
            Console.WriteLine(result);
        }
        public static string PrintTownNamesFromCountry(SqlConnection sqlConnection, string countryName)
        {
            string query = @"SELECT UPPER(t.Name) AS Name FROM Towns AS t
            JOIN Countries AS c ON c.Id = t.CountryCode
            WHERE c.Name = @CountryName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@CountryName", countryName));

            StringBuilder sq = new StringBuilder();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    sq.AppendLine($"{reader["Name"]}");
                }
            }
            return sq.ToString();
        }
    }
}
