using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class Data
    {
        public int start;
        public int end;

        public Data(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }

    class DataComparer : IComparer<Data>
    {
        public int Compare(Data d1, Data d2)
        {
            if (d1.start > d2.start)
                return 1;
            else if (d1.start == d2.start)
            {
                if (d1.end > d2.end)
                    return 1;
                else if (d1.end == d2.end)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
    }

    class B1931번_회의실_배정
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var listOfData = new List<Data>();

            for(int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var start = int.Parse(input[0]);
                var end = int.Parse(input[1]);

                listOfData.Add(new Data(start, end));
            }

            listOfData.Sort(new DataComparer());
            //foreach (var data in listOfData)
            //{
            //    Console.WriteLine($"{data.start} {data.end}");
            //}

            var Q = new Queue<Data>(listOfData);

            var lastData = Q.Dequeue();
            int cnt = 1;

            while (Q.Count > 0)
            {
                var curData = Q.Dequeue();
                if (lastData.end <= curData.start)
                {
                    lastData = curData;
                    cnt++;
                }
                else if (lastData.end >= curData.end)
                {
                    lastData = curData;
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
