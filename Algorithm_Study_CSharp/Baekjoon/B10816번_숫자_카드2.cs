using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Binary Search 방법 중 lower bound와 upper bound를 이용하는 문제

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B10816번_숫자_카드2
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            //var nums = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);

            //var m = int.Parse(Console.ReadLine());
            //var targets = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);

            //Array.Sort(nums);
            //var output = new StringBuilder();
            //for(int i = 0; i < m; i++)
            //{
            //    var lowerBound = LowerBound(nums, targets[i]);
            //    var upperBound = UpperBound(nums, targets[i]);
            //    output.Append($"{upperBound - lowerBound} ");
            //}
            //Console.WriteLine(output);
            int[] arr = new int[] { 1, 2, 3, 4, 4, 4, 4, 4, 7, 8 };
            Console.WriteLine(UpperBound(arr, 4));
        }

        // LowerBound는 중복된 값들이 첫번째로 등장하는 위치를 반환한다.
        // 값이 없는 경우는 바로 이전 값이 끝나고 난 뒤 위치를 반환
        // [1,2,3,4,4,4,4,6,7,8]
        // -> target : 4, return : 3
        // -> target : 5, return : 8
        // -> target : 9, return : 10
        static int LowerBound(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length;
            while(low < high)
            {
                int mid = (low + high) / 2;
                if(target <= arr[mid])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        // UppwerBound는 중복된 값들이 등장하고 난 다음 위치를 반환한다.
        // [1,2,3,4,4,4,4,6,7,8]
        // -> target : 4, return : 7
        // -> target : 5, return : 8
        // -> target : 9, return : 10
        static int UpperBound(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length;

            while(low < high)
            {
                int mid = (low + high) / 2;
                if(target < arr[mid])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }
    }
}
