using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 아이디어
/// 참고 : https://kbw1101.tistory.com/29
/// B[k] = S를 구한다.
/// S보다 작거나 같은 수가 k개 있다.
///
/// S보다 작거나 같은 수의 개수를 구하는 방법
///     - 각 행별로 S보다 작거나 같은 수의 개수를 구한다.
///     - 위에서 구한 값들을 모두 더한다.
///
/// 각 행마다 S보다 작거나 같은 수를 구하는 방법
///     - min(S / i, N)
///     - S를 i로 나눈 값에 나머지를 버린 값
/// i*1, i*2, i*3, i*4, ... , i*j => i*k (1 <= k <= j)
/// S는 i*k와 값이 같거나, i*k ~ i*(k+1)사이에 있다.
///     - 값이 같은 경우 -> i*k/i -> k개 만큼
///     - 사이에 있는 경우도 마찬가지로 k개 만큼
///
/// S보다 작거나 같은 수의 개수가 k개인 S를 찾아야 한다.
/// low = 1, high = k로 해서 이분 탐색// high를 n*n으로 해서 탐색하면 오답?
/// 1. 개수를 구한다.
/// 2. 개수가 k보다 같거나 크면 정답후보 -> 답을 저장하고, 상한을 낮춘다.
/// 3. 개수가 k보다 작으면 답이 될 수 없음 -> 하한을 올린다.
/// </summary>

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B1300번_K번째_수
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            int low = 1;
            int high = k;
            int answer = 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (GetCount(n, mid) >= k)
                {
                    answer = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            Console.WriteLine(answer);
        }

        /// <summary>
        /// 각 행별로 target 숫자보다 작거나 같은 수의 개수의 총합을 구한다.
        /// </summary>
        /// <param name="n">행의 개수</param>
        /// <param name="target">기준이 되는 수</param>
        /// <returns></returns>
        static int GetCount(int n, int target)
        {
            int res = 0;
            for (int i = 1; i <= n; i++)
            {
                res += Math.Min(n, target / i);
            }
            return res;
        }
    }
}

