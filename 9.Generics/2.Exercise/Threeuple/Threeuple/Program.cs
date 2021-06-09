using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomThreeuple<string, string,string> nameAndAddress = new CustomThreeuple<string, string,string>();

            nameAndAddress.item1 = $"{firstInput[0]} {firstInput[1]}";
            nameAndAddress.item2 = $"{firstInput[2]}";

            if (firstInput.Length > 4)
            {
                nameAndAddress.item3 = $"{firstInput[3]} {firstInput[4]} ";
            }
            else
            {
                nameAndAddress.item3 = $"{firstInput[3]}";
            }

            string[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomThreeuple<string, int, bool> nameAndLitersOfBeer = new CustomThreeuple<string, int, bool>();

            nameAndLitersOfBeer.item1 = secondInput[0];
            nameAndLitersOfBeer.item2 = int.Parse(secondInput[1]);

            if (secondInput[2].ToLower() == "not")
            {
                nameAndLitersOfBeer.item3 = false;
            }
            else
            {
                nameAndLitersOfBeer.item3 = true;
            }

            string[] thirdInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomThreeuple<string, double, string> nameBalanceAndBank = new CustomThreeuple<string, double,string>();

            nameBalanceAndBank.item1 = thirdInput[0];
            nameBalanceAndBank.item2 = double.Parse(thirdInput[1]);
            nameBalanceAndBank.item3 = thirdInput[2];

            Console.WriteLine($"{nameAndAddress.item1} -> {nameAndAddress.item2} -> {nameAndAddress.item3}");
            Console.WriteLine($"{nameAndLitersOfBeer.item1} -> {nameAndLitersOfBeer.item2} -> {nameAndLitersOfBeer.item3}");
            Console.WriteLine($"{nameBalanceAndBank.item1} -> {nameBalanceAndBank.item2} -> {nameBalanceAndBank.item3}");
        }
    }
}
