using System;

namespace Lab2_Variant24_Recursion
{
    class Program
    {
        static void RotateLayer(int[,] matrix, int first, int last, int k)
        {
            if (k >= last)
            {
                return;
            }

            int offset = k - first;

            int top = matrix[first, k];                                
            matrix[first, k] = matrix[last - offset, first];           
            matrix[last - offset, first] = matrix[last, last - offset]; 
            matrix[last, last - offset] = matrix[k, last];              
            matrix[k, last] = top;                                     

            RotateLayer(matrix, first, last, k + 1);
        }

        static void RotateRight90(int[,] matrix, int n, int layer)
        {
            if (layer >= n / 2)
            {
                return; 
            }

            RotateLayer(matrix, layer, n - 1 - layer, layer);
            RotateRight90(matrix, n, layer + 1);
        }

        static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть розмір матриці M: ");
            int m = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[m, m];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("\nПочаткова матриця:");
            PrintMatrix(matrix, m);

            RotateRight90(matrix, m, 0);

            Console.WriteLine("\nМатриця після повороту на 90 градусів вправо (рекурсія):");
            PrintMatrix(matrix, m);

            Console.ReadKey();
        }
    }
}