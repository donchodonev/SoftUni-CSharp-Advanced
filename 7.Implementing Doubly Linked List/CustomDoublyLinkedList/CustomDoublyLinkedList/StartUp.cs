using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var head = new Node(1);

            DoublyLinkedList linkedList = new DoublyLinkedList();
            linkedList.AddTail(new Node(1));
            linkedList.AddTail(new Node(2));
            linkedList.AddTail(new Node(3));
            linkedList.AddHead(new Node(0));


            int[] myArrayFromLinkedList = linkedList.ToArray();

            Console.WriteLine("ToArray method result");

            for (int i = 0; i < myArrayFromLinkedList.Length; i++)
            {
                Console.WriteLine(myArrayFromLinkedList[i]);
            }

            Console.WriteLine("ForEach method result");
            linkedList.ForEach(num => Console.WriteLine(num));

            linkedList.RemoveHead();
            linkedList.RemoveTail();

            Console.WriteLine("After removing head and tail");
            linkedList.ForEach(num => Console.WriteLine(num));


            linkedList.AddHead(new Node(0));
            linkedList.AddTail(new Node(3));

            Console.WriteLine("After adding head and tail anew");
            linkedList.ForEach(num => Console.WriteLine(num));

        }
    }
}
