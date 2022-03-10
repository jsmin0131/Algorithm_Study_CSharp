using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B13305번_주유소
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var lensOfRoad = Console.ReadLine().Split().Select(ulong.Parse).ToList();
            var pricesPerLitter = Console.ReadLine().Split().Select(ulong.Parse).ToList();

            ulong sum = pricesPerLitter[0] * lensOfRoad[0];
            ulong curPrice = pricesPerLitter[0];
            for(int i = 1; i < n - 1; i++)
            {
                if(curPrice > pricesPerLitter[i])
                {
                    curPrice = pricesPerLitter[i];
                }
                sum += (curPrice * lensOfRoad[i]);
            }
            Console.WriteLine(sum);
        }
    }
}