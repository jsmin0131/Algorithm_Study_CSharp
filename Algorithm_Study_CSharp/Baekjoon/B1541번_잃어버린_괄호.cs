using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B1541번_잃어버린_괄호
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var ops = new List<char>();
            ops.Add(' ');

            foreach(var c in input)
            {
                if (c == '+' || c == '-')
                    ops.Add(c);
            }

            var nums = input
                .Replace('+', ' ')
                .Replace('-', ' ')
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = nums[0];
            bool IsThereMinus = false;
            for(int i = 1; i < nums.Count; i++)
            {
                if(ops[i] == '+')
                {
                    if (IsThereMinus)
                    {
                        sum -= nums[i];
                    }
                    else
                    {
                        sum += nums[i];
                    }
                }
                else
                {
                    IsThereMinus = true;
                    sum -= nums[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
