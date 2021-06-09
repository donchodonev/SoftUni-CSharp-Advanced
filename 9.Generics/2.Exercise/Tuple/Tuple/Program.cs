using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, string> nameAndAddress = new CustomTuple<string, string>();

            nameAndAddress.item1 = $"{firstInput[0]} {firstInput[1]}";
            nameAndAddress.item2 = $"{firstInput[2]}";

            string[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, int> nameAndLitersOfBeer = new CustomTuple<string, int>();

            nameAndLitersOfBeer.item1 = secondInput[0];
            nameAndLitersOfBeer.item2 = int.Parse(secondInput[1]);

            string[] thirdInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<int, double> integerAndDouble = new CustomTuple<int, double>();

            integerAndDouble.item1 = int.Parse(thirdInput[0]);
            integerAndDouble.item2 = double.Parse(thirdInput[1]);

            Console.WriteLine($"{nameAndAddress.item1} -> {nameAndAddress.item2}");
            Console.WriteLine($"{nameAndLitersOfBeer.item1} -> {nameAndLitersOfBeer.item2}");
            Console.WriteLine($"{integerAndDouble.item1} -> {integerAndDouble.item2}");
        }
    }
}
