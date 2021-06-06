using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public int Value { get; set; }
    }
}
