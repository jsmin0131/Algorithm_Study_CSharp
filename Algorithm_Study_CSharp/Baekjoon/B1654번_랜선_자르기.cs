using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// upper bound를 찾는 문제
// 탐색시 판단 기준이 무엇인지
// 탐색 범위를 어떻게 좁혀나갈 것인지
//
// 오답 이유 : 문제에서 자료형을 주의깊게 보지 않았다.
// 랜선의 길이가 2^32-1이므로 랜선끼리 덧셈 연산을 할 때, int범위를 초과할 수 있다.

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B1654번_랜선_자르기
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var k = int.Parse(input[0]);// 1이상 10000이하
            var n = int.Parse(input[1]);// 1이상 1000000이하, k <= n
            var LANCables = new long[k];

            for(int i = 0; i < k; i++)
            {
                LANCables[i] = int.Parse(Console.ReadLine());
            }

            long low = 1;
            long high = LANCables.Max();
            long answer = 0;

            while(low <= high)
            {
                long targetLen = (low + high) / 2;
                long numOfCables = GetNumOfCablesAfterCutting(LANCables, targetLen);
                //Console.WriteLine(numOfPiece + " targetLen : " + targetLen + " low : " + low + " high : " + high);
                if(numOfCables < n)
                {
                    high = targetLen - 1;
                }
                else
                {
                    if (answer < targetLen)
                        answer = targetLen;
                    low = targetLen + 1;
                }
            }
            Console.WriteLine(answer);
        }

        static long GetNumOfCablesAfterCutting(long[] cables, long targetLen)
        {
            long res = 0;
            foreach(var cable in cables)
            {
                res += cable / targetLen;
            }
            return res;
        }
    }
}
