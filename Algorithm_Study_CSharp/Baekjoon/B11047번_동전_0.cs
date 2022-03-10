using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B11047번_동전_0
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            var coins = new int[n];
            for(int i = 0; i < n; i++)
            {
                coins[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            int cnt = 0;
            for(int i = n - 1; i >= 0; i--)
            {
                while(true)
                {
                    sum += coins[i];
                    cnt++;
                    if (sum == k)
                        break;
                    else if(sum > k)
                    {
                        sum -= coins[i];
                        cnt--;
                        break;
                    }
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
