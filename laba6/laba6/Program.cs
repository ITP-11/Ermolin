using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РаундРобин
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, k = 0, u = 0;
            int kv = 3;
            int G = 0;
            int min = 0;
            int v = 0, sum = 0;
            int i = 0;
            int s = 0;
            Console.WriteLine("введите количество процессов");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите квант времени");
            kv = Convert.ToInt32(Console.ReadLine());
            m = 2;
            int[,] A = new int[n, m];

            int[] B = new int[n];

            for (i = 0; i < n; i++)
            {
                Console.WriteLine("Введите время входа p{0}", i);
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = Convert.ToInt32(Console.ReadLine());
                    if (j == 0) Console.WriteLine("Ведите время работы p{0}", i);
                }
            }
            for (i = 0; i < n; i++)
            {
                B[i] = A[i, 1];
            }

            for (i = 0; i < n; i++)
            {
                sum = sum + A[i, 1];
            }

            int[,] D = new int[n, sum * sum];

            i = 0;
            while (sum > k)
            {
                if (A[i, 1] > 0 && A[i, 0] <= k)
                {
                    v = 1;
                    int c = k;
                    if (A[i, 1] < kv)
                    {
                        min = k + A[i, 1];
                        k = k + A[i, 1];
                        A[i, 1] = 0;
                    }
                    else
                    {
                        min = k + kv;
                        k = k + kv;
                        A[i, 1] = A[i, 1] - kv;
                    }
                    for (int j = c; j < min; j++)
                    {
                        D[i, j] = 1;
                    }
                }

                if (i < n - 1)
                {
                    i++;
                }
                else
                {
                    i = 0;
                    if (v == 0)
                    {
                        sum++;
                        k++;
                    }
                    v = 0;
                }
            }

            for (i = 0; i < n; i++)
            {
                k = 0;
                int z = A[i, 0];
                while (k != B[i])
                {
                    if (D[i, z] == 1)
                    {
                        k++;
                    }
                    else
                    {
                        D[i, z] = 2;
                    }
                    z++;
                }
            }
            Console.WriteLine();
            Console.Write("----");
            for (i = 0; i < sum - 1; i++)
            {
                    Console.Write("----", i + 1);
            }
            Console.Write("\n");
            Console.Write("|# |");
            for (i = 0; i < sum - 1; i++)
            {
                if(i<9)
                Console.Write(" {0,1} |", i + 1);
                else
                Console.Write(" {0,2}|", i + 1);
            }

            Console.WriteLine();
             
            for (i = 0; i < n; i++)
            {
                int I = 0;
                
                Console.Write("----");
                for (int t = 0; t < sum - 1; t++)
                {
                    Console.Write("----", t + 1);
                }
                Console.Write("\n");
                Console.Write("|p{0}|", i);
               
                for (int j = 1; j < sum; j++)
                {
                    if (D[i, j] == 1)
                    {
                        Console.Write(" И |");
                        I++;
                    }
                    else if (D[i, j] == 2)
                    {       
                        Console.Write(" Г |");
                        G++;
                    }
                    else
                    {
                        Console.Write("   |");
                    } 
                }
                Console.WriteLine();
            }
            
            Console.Write("----");
            for (i = 0; i < sum - 1; i++)
            {
                Console.Write("----", i + 1);
            }
            Console.WriteLine();
            u = 0;
            min = 0;
            for (i = 0; i < n; i++)
            {
                for (int j = 0; j < sum; j++)
                {
                    if (D[i, j] == 1 || D[i, j] == 2) u++;
                }             
                min = min + u;
                Console.WriteLine("Время выполнения p{0}: {1}", i, u);
                u = 0;
            }

            Console.WriteLine("Среднее время выполнения {0}", (double)min/ n); 
            u = 0;
            min = 0;
            for (i = 0; i < n; i++)
            {
                for (int j = 0; j < sum; j++)
                {
                    if (D[i, j] == 2) u++;
                }
                min = min + u;
                Console.WriteLine("Время ожидания p{0}: {1}", i, u);
                u = 0;
            }
            Console.WriteLine("Среднее время ожидания: {0}", (double)G / n);
            Console.ReadKey();
        }
    }
}