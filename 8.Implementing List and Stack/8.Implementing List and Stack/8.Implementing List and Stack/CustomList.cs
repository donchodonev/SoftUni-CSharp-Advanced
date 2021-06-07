using System;

namespace _8.Implementing_List_and_Stack
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] internalArray;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public CustomList()
        {
            internalArray = new int[InitialCapacity];
            Capacity = InitialCapacity;
        }
        public CustomList(int size)
            : this()
        {
            if (size == 0)
            {
                internalArray = new int[InitialCapacity];
                Capacity = InitialCapacity;
                return;
            }
            internalArray = new int[size];
            Capacity = size;
        }

        public int this[int index]
        {
            get
            {
                if (index >= Count || index < 0 || Count == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return internalArray[index];
            }
            set
            {
                if (index >= Count || index < 0 || Count == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                internalArray[index] = value;
            }
        }
        private void Resize()
        {
            int[] newArr = new int[Capacity * 2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                newArr[i] = internalArray[i];
            }

            internalArray = newArr;
            Capacity = internalArray.Length;
        }
        public void Add(int num)
        {
            if (Count >= Capacity)
            {
                Resize();
            }
            internalArray[Count] = num;
            Count++;
        }

        public void ShiftToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                internalArray[i] = internalArray[i + 1];
            }
        }
        public void Shrink()
        {
            int[] newArray = new int[internalArray.Length / 2];

            for (int i = 0; i < internalArray.Length / 2; i++)
            {
                newArray[i] = internalArray[i];
            }

            internalArray = newArray;
            Capacity = internalArray.Length;
        }
        public int RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int valueToRemove = internalArray[index];
            internalArray[index] = 0;
            ShiftToLeft(index);

            Count--;

            if (Count <= Capacity / 4)
            {
                Shrink();
            }

            return valueToRemove;
        }
        public void InstertAt(int index, int number)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            ShiftToRight(index);

            internalArray[index] = number;

            Count++;
        }
        public void ShiftToRight(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == Capacity)
            {
                Resize();
            }


            int[] newIntArray = new int[Capacity];


            for (int i = 0; i < internalArray.Length; i++)
            {
                for (int v = 0; v < newIntArray.Length; v++,i++)
                {
                    if (index == v)
                    {
                        v++;
                    }
                    newIntArray[v] = internalArray[i];
                }
            }

            internalArray = newIntArray;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (internalArray[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= Count || firstIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (secondIndex >= Count || secondIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int firstIndexValue = internalArray[firstIndex];
            int secondIndexValue = internalArray[secondIndex];

            internalArray[firstIndex] = secondIndexValue;
            internalArray[secondIndex] = firstIndexValue;
        }
    }
}
