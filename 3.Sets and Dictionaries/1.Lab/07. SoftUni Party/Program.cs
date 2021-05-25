using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> createdNormalReservations = new HashSet<string>();
            HashSet<string> createdVIPReservations = new HashSet<string>();

            HashSet<string> fulfilledNormalReservations = new HashSet<string>();
            HashSet<string> fulfilledVIPReservations = new HashSet<string>();

            bool party = false;

            while (input != "END")
            {
                if (input == "PARTY")
                {
                    party = true;
                    input = Console.ReadLine();
                    continue;
                }

                if (party)
                {
                    if (char.IsDigit(input[0]))
                    {
                        fulfilledVIPReservations.Add(input);
                    }
                    else
                    {
                        fulfilledNormalReservations.Add(input);
                    }
                }
                else
                {
                    if (char.IsDigit(input[0]))
                    {
                        createdVIPReservations.Add(input);
                    }
                    else
                    {
                        createdNormalReservations.Add(input);
                    }
                }

                input = Console.ReadLine();

            }

            //remove fulfilled reservations so we're left with just the unfulfilled ones and then print them
            //as per exercise's task by creating a subset of all created reservations
            //no loss in data experienced as we still hold all reservations made
            //but are split in two hash sets - one with the fulfilled ones and one with the unfulfilled

            createdNormalReservations.ExceptWith(fulfilledNormalReservations);
            createdVIPReservations.ExceptWith(fulfilledVIPReservations);

            Console.WriteLine($"{createdNormalReservations.Count() + createdVIPReservations.Count()}");

            foreach (var reservationNumber in createdVIPReservations)
            {
                Console.WriteLine(reservationNumber);
            }
            foreach (var reservationNumber in createdNormalReservations)
            {
                Console.WriteLine(reservationNumber);
            }
        }
    }
}
