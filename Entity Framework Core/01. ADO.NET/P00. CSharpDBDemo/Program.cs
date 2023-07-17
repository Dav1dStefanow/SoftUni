using Microsoft.Data.SqlClient;
using System;

namespace P00._CSharpDBDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=SoftUni;TrustServerCertificate=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                     string query = "UPDATE Employees SET Salary += 0.12";
                     SqlCommand sqlCommand = new SqlCommand(query, connection);
                     var rowsAffected = sqlCommand.ExecuteNonQuery();
                     Console.WriteLine(rowsAffected);
                
                     string query2 = "SELECT SUM(Salary) FROM Employees";
                     SqlCommand sqlCommand2 = new SqlCommand(query, connection);
                     Console.WriteLine(sqlCommand2.ExecuteScalar()); 
                

                string query3 = "SELECT * FROM Employees";
                SqlCommand sqlCommand3 = new SqlCommand(query, connection);
                using (SqlDataReader sqlReader = sqlCommand3.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        Console.WriteLine($"{sqlReader["FirstName"]} {sqlReader["LastName"]}");
                    }
                }
                connection.Close();
            }

            //Injection
            
                Console.Write("Please enter Username: ");
                var username = Console.ReadLine();
                Console.Write("Please enter Password: ");
                var password = Console.ReadLine();
            string conectionString2 = @"Server=.\SQLEXPRESS;Integrated Security=true;Database=Service;TrustServerCertificate=True;";
            using (var  conection = new SqlConnection(conectionString2))
            {
                conection.Open();
                var sqlCmd = new SqlCommand(
                    $"SELECT COUNT(*) FROM Users WHERE Username = @Username " +
                    $"AND Password = @Password",conection);
                sqlCmd.Parameters.Add(new SqlParameter("@Username", username));
                sqlCmd.Parameters.AddWithValue("@Password", password);
                var usersCount = (int)sqlCmd.ExecuteScalar();
                if(usersCount > 0)
                {
                    Console.WriteLine("Access granted! Welcome!");
                }
                else Console.WriteLine("Access denied!");
            }
        }
    }
}
