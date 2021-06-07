using System;

namespace _8.Implementing_List_and_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);

            Console.WriteLine(myList.Contains(3));
            
        }
    }
}
