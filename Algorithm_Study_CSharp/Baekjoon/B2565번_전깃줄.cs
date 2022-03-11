using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class Data
    {
        public int source;
        public int target;

        public Data(int source, int target)
        {
            this.source = source;
            this.target = target;
        }
        public Data(int[] input) : this(input[0], input[1]) { }
    }

    class DataComparer : IComparer<Data>
    {
        public int Compare(Data a, Data b)
        {
            if (a.source > b.source)
                return 1;
            else if (a.source < b.source)
                return -1;
            else
                return 0;
        }
    }

    class B2565번_전깃줄
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Data>();

            for(int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                list.Add(new Data(input));
            }
            list.Sort(new DataComparer());

            var dp = new int[n];
            dp[0] = 1;
            int answer = 1;

            for(int i = 1; i < n; i++)
            {
                int max = 0;
                for(int j = 0; j <= i - 1; j++)
                {
                    if(list[i].target > list[j].target && max <= dp[j])
                    {
                        max = dp[j];
                    }
                }
                dp[i] = max + 1;
                if (answer < dp[i])
                    answer = dp[i];
            }
            answer = n - answer;
            Console.WriteLine(answer);
        }
    }
}
