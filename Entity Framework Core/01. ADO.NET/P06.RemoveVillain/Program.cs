using Microsoft.Data.SqlClient;
using System;

namespace P06.RemoveVillain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS; Database=MinionsDB; Integrated Security=true; TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int villainID = int.Parse(Console.ReadLine());

            string name;
            GetVillainNameById(connection, villainID, out name);
            if(name == null) 
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                int minionsSurvingCount;
                GetMinionsServingCount(connection, villainID, out minionsSurvingCount);
                ReleaseMinions(connection, villainID);
                Console.WriteLine(DeleteVillain(connection, villainID, name));

                Console.WriteLine($"{minionsSurvingCount} minions were released.");
            }
        }
        public static void GetVillainNameById(SqlConnection connection, int villainID, out string name)
        {

            string getVillainNameString = @"SELECT Name FROM Villains WHERE Id = @VillainId";
            SqlCommand getVillainName = new SqlCommand(getVillainNameString, connection);
            getVillainName.Parameters.Add(new SqlParameter("@VillainId", villainID));

            name = (string)getVillainName.ExecuteScalar();
        }
        public static string DeleteVillain(SqlConnection connection, int villainID, string name)
        {
            string deleteVillainString = @"DELETE FROM Villains WHERE Id = @VillainId";
            SqlCommand deleteVillain = new SqlCommand(deleteVillainString, connection);
            deleteVillain.Parameters.Add(new SqlParameter("@VillainId", villainID));
            deleteVillain.ExecuteNonQuery();
            return $"{name} was deleted.";
        }
        public static void GetMinionsServingCount(SqlConnection connection, int villainID, out int count)
        {
            string getMinionsCountString =
            @"SELECT COUNT(*) 
            FROM MinionsVillains 
            WHERE VillainId = @VillainId";
            SqlCommand getMinionsCount = new SqlCommand(getMinionsCountString, connection);
            getMinionsCount.Parameters.Add(new SqlParameter("@VillainId", villainID));

            count = (int)getMinionsCount.ExecuteScalar();
        }
        public static void ReleaseMinions(SqlConnection connection, int villainID)
        {
            string releaseString = @"DELETE FROM MinionsVillains WHERE VillainId = @VillainId";
            SqlCommand releaseMinions = new SqlCommand(releaseString, connection);
            releaseMinions.Parameters.Add(new SqlParameter("@VillainId", villainID));
            releaseMinions.ExecuteNonQuery();
        }
    }
}
