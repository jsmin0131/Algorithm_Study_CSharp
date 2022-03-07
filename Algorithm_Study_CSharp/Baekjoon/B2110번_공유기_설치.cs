using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B2110번_공유기_설치
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);// 집의 개수
            int c = int.Parse(inputs[1]);// 공유기의 개수
            var x = new int[n];          // 집의 좌표

            for(int i = 0; i < n; i++)
            {
                x[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(x);

            int low = 0;
            int high = x.Max();
            int answer = 0;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                bool check = IsPossibleToPutRouter(x, c, mid);
                //Console.WriteLine($"low {low} high {high} mid {mid} check {check}");
                if (check)
                {
                    low = mid + 1;
                    answer = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            Console.WriteLine(answer);
        }

        static bool IsPossibleToPutRouter(int[] x, int numOfRouter, int minGap)
        {
            int lastPos = x[0];
            numOfRouter--;
            for (int i = 1; i < x.Length; i++)
            {
                int pos = x[i];
                //Console.WriteLine($"pos {pos} lastPos {lastPos} gap {pos - lastPos} minGap {minGap}");
                if (pos - lastPos >= minGap)
                {
                    lastPos = pos;
                    numOfRouter--;
                }
                if (numOfRouter == 0)
                    return true;
            }
            return false;
        }
    }
}
