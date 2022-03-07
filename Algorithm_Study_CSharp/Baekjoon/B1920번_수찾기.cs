using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Study_CSharp.Baekjoon
{
    class B1920번_수찾기
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);
            Array.Sort(nums);

            int m = int.Parse(Console.ReadLine());
            int[] targets = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);

            var output = new StringBuilder();
            for(int i = 0; i < m; i++)
            {
                if (BinarySearch(RecursiveBinarySearch, nums, targets[i]))
                    output.Append("1\n");
                else
                    output.Append("0\n");
            }
            Console.WriteLine(output);
        }

        static bool BinarySearch(Func<int[], int, int, int, bool> searchFunc, int[] arr, int target)
        {
            int start = 0;
            int end = arr.Length - 1;
            return searchFunc(arr, start, end, target);
        }

        static bool RecursiveBinarySearch(int[] nums, int start, int end, int target)
        {
            if (start > end)
                return false;
            int mid = (start + end) / 2;
            if (target == nums[mid])
                return true;
            if (target < nums[mid])
                return RecursiveBinarySearch(nums, start, mid - 1, target);
            else
                return RecursiveBinarySearch(nums, mid + 1, end, target);
        }

        static bool IterativeBinarySearch(int[] nums, int start, int end, int target)
        {
            while(start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                    return true;
                else if(target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return false;
        }
    }
}
