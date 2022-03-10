using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B11053번_가장_긴_증가하는_부분_수열
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);
            int[] dp = new int[n];// dp[i] : i번째 원소까지 LIS의 길이

            int res = 0;
            // arr를 순회하면서 arr[i]원소가 가질 수 있는 LIS의 값은 무엇인지 찾는다.
            for (int i = 0; i < n; i++)
            {
                // 0 ~ i - 1 까지 dp를 순회하면서 LIS의 최대값을 찾는다.
                // 또한, LIS를 만족해야 하므로 arr[i]가 arr[j]보다는 커야 한다.
                int max = 0;
                for (int j = 0; j <= i - 1; j++)
                {
                    if (arr[j] < arr[i] && dp[j] >= max)
                        max = dp[j];
                }
                dp[i] = max + 1;
                // 가장 마지막 원소가 최대값이라는 보장이 없으므로 dp[i]중에서 최대값을 찾아야 한다.
                if (res < dp[i])
                    res = dp[i];
            }
            Console.WriteLine(res);
            //foreach(var elem in dp)
            //{
            //    Console.Write(elem + " ");
            //}
        }
    }
}
