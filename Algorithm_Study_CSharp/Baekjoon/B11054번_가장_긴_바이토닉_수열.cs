using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B11054번_가장_긴_바이토닉_수열
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var increasingDP = new int[n];
            var decreasingDP = new int[n];

            increasingDP[0] = 1;
            for(int i = 1; i < n; i++)
            {
                int max = 0;
                for(int j = 0; j <= i - 1; j++)
                {
                    if(arr[i] > arr[j] && max <= increasingDP[j])
                    {
                        max = increasingDP[j];
                    }
                }
                increasingDP[i] = max + 1;
            }

            decreasingDP[arr.Length - 1] = 1;
            for (int i = arr.Length-2; i >= 0; i--)
            {
                int max = 0;
                for (int j = arr.Length - 1; j >= i; j--)
                {
                    if (arr[i] > arr[j] && max <= decreasingDP[j])
                    {
                        max = decreasingDP[j];
                    }
                }
                decreasingDP[i] = max + 1;
            }


            int answer = 1;
            for(int i = 0; i < n; i++)
            {
                int tmp = increasingDP[i] + decreasingDP[i] - 1;
                if (answer < tmp)
                    answer = tmp;
            }
            Console.WriteLine(answer);
        }
    }
}
