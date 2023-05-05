 
            int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = n[0]; int cols = n[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int[] subMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int subMatrixRow = subMatrix[0];
            int subMatrixCol = subMatrix[1];

            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - subMatrixRow + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subMatrixCol + 1; col++)
                {
                    var sum = 0;
                    for(int i = 0; i < subMatrixRow; i++)
                    {
                        for (int j = 0; j < subMatrixCol; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }
            for(int row = maxSumRow; row < maxSumRow + subMatrixRow; row++)
            {
                for(int col = maxSumCol; col < maxSumCol + subMatrixCol; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}