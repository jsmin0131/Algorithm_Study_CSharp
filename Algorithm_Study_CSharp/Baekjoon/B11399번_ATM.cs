using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B11399번_ATM
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var result = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .Aggregate(
                new { Sum = 0, Idx = 0 },
                (cur, next) => new { Sum = cur.Sum + (n - cur.Idx) * next, Idx = cur.Idx + 1 })
                .Sum;
            Console.WriteLine(result);
        }
    }
}
