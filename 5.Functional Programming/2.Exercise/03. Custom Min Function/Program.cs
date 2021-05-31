using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> printSmallest = nums =>
             {

                 int smallestNum = int.MaxValue;

                 foreach (var num in nums)
                 {
                     if (num < smallestNum)
                     {
                         smallestNum = num;
                     }
                 }
                 return smallestNum;
             };
            Console.WriteLine(printSmallest(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }
    }
}
