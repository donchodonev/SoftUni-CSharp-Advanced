using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList : IEnumerable
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public void AddHead(Node newHeadNode)
        {
            if (Count == 0)
            {
                Head = newHeadNode;
                Tail = newHeadNode;
            }
            else
            {
                //operation must be done in this exact order
                Node newHead = newHeadNode;

                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
            Count++;
        }

        public void AddTail(Node newTailNode)
        {
            if (Count == 0)
            {
                Head = newTailNode;
                Tail = newTailNode;
            }
            else
            {
                //operation must be done in this exact order
                Node newTail = newTailNode;

                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
            Count++;
        }
        public Node RemoveHead() 
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
                return null;
            }
            else if(Count == 1)
            {
                var firstElement = Head;
                Head = null;
                Tail = null;
                return firstElement;
            }
            else
            {
                var firstElement = Head;

                Head = Head.Next;
                Head.Previous = null;

                return firstElement;
            }
        }
        public Node RemoveTail()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
                return null;
            }
            else if (Count == 1)
            {
                var lastElement = Tail;

                Head = null;
                Tail = null;

                return lastElement;
            }
            else
            {
                var lastElement = Tail;

                Tail = Tail.Previous;

                Tail.Next = null;

                return lastElement;
            }
        }

        public void ForEach (Action<int> action)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];

            var currentNode = Head;

            int counter = 0;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                counter++;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public IEnumerator GetEnumerator()
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                yield return currentNode;

                currentNode = currentNode.Next;
            }
        }
    }
}
