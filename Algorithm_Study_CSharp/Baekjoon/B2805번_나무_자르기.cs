using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B2805번_나무_자르기
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split();
            var n = int.Parse(inputs[0]);// 나무의 수 1 <= n <= 1,000,000
            var m = int.Parse(inputs[1]);// 집으로 가져가려고 하는 나무의 길이 1 <= m <= 2,000,000,000
            var trees = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);// 나무의 높이, 0 <= 높이 <= 1,000,000,000

            int low = 0;
            int high = trees.Max();
            int answer = 0;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                long lengthOfCutTrees = GetLengthOfCutTrees(trees, mid);
                //Console.WriteLine($"len : {lengthOfCutTrees, 3} low : {low, 3} high : {high, 3} mid : {mid, 3}");
                if(lengthOfCutTrees >= m)
                {
                    if (answer < mid)
                        answer = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            Console.WriteLine(answer);
        }

        static long GetLengthOfCutTrees(int[] trees, int h)
        {
            long res = 0;
            foreach(var tree in trees)
            {
                res += (tree - h) < 0 ? 0 : (tree - h);
            }
            return res;
        }
    }
}
