using System;
using System.Collections.Generic;

namespace _8.Implementing_List_and_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack myStack = new CustomStack();

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            Console.WriteLine(myStack.Peek());
        }
    }
}
