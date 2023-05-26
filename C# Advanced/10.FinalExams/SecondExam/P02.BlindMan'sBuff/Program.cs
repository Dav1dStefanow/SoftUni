using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P02.BlindMan_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

            string[,] playground = new string[parameters[0], parameters[1]];

            int bRow = -1;
            int bCol = -1;

            int opponentsTouched = 0;
            int moves = 0;

            for (int i = 0; i < parameters[0]; i++)
            {
                string[] row = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < parameters[1]; j++)
                {
                    playground[i, j] = row[j].ToString();
                    if (playground[i, j] == "B")
                    {
                        bRow = i;
                        bCol = j;
                        playground[i, j] = "-";
                    }
                }
            }

            string direction;
            while ((direction = Console.ReadLine()) != "Finish")
            {
                if ((direction == "left" && bCol == 0) ||
                    (direction == "right" && bCol == playground.GetLength(1) - 1) ||
                    (direction == "up" && bRow == 0) ||
                    (direction == "down" && bRow == playground.GetLength(0) - 1))
                {
                    continue;
                }

                switch (direction)
                {
                    case "left":
                        if (playground[bRow, bCol - 1] == "O")
                        {
                            continue;
                        }
                        break;
                    case "right":
                        if (playground[bRow, bCol + 1] == "O")
                        {              
                            continue;  
                        }              
                        break;         
                    case "up":         
                        if (playground[bRow - 1, bCol] == "O")
                        {
                            continue;
                        }
                        break;
                    case "down":
                        if (playground[bRow + 1, bCol] == "O")
                        {
                            continue;
                        }
                        break;

                }

                moves++;
                switch (direction)
                {
                    case "left":
                        bCol--;
                        break;
                    case "right":
                        bCol++;
                        break;
                    case "up":
                       bRow--;
                        break;
                    case "down":
                        bRow++;
                        break;

                }

                if (playground[bRow, bCol] == "P")
                {
                    opponentsTouched++;
                    playground[bRow, bCol] = "-";

                    if (opponentsTouched == 3)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {moves}");
            
        }
    }
}
