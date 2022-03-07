using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B1300번_K번째_수
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var arr = new int[n + 1, n + 1];
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    arr[i, j] = i * j;
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            var ptr = new int[n + 1];
            for (int i = 1; i <= n; i++)
                ptr[i] = 1;

            int resIdx = 0;
            for(int i = 1; i <= k; i++)
            {
                resIdx = FindMinPtr(arr, ptr, n);
                Console.WriteLine(resIdx);
            }
            Console.WriteLine(arr[resIdx, ptr[resIdx]]);
        }

        static int FindMinPtr(int[,] arr, int[] ptr, int n)
        {
            int minIdx = 1;
            for(int i = 2; i <= n; i++)
            {
                if (ptr[i] > n || ptr[minIdx] > n) continue;
                if (arr[minIdx, ptr[minIdx]] > arr[i, ptr[i]])
                {
                    minIdx = i;
                }
            }
            ptr[minIdx]++;
            return minIdx;
        }
    }
}
