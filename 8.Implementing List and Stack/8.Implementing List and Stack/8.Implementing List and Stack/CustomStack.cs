using System;
using System.Collections.Generic;
using System.Text;

namespace _8.Implementing_List_and_Stack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] internalArray { get; set; } = new int[InitialCapacity];
        public int Count { get; private set; }
        public int Capacity { get; private set; } = InitialCapacity;

        public void Resize()
        {
            int[] newIntArr = new int[Capacity * 2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                newIntArr[i] = internalArray[i];
            }

            internalArray = newIntArr;
            Capacity *= 2;
        }
        public void Push(int number)
        {
            if (Count == Capacity)
            {
                Resize();
            }

            internalArray[Count] = number;

            Count++;
        }
        public int Pop()
        {
            int poppedNum = internalArray[Count - 1];

            internalArray[Count - 1] = 0;

            Count--;

            return poppedNum;
        }
        public int Peek()
        {
            return internalArray[Count - 1]; ;
        }
    }
}
