using System;

namespace Stack
{
    public interface Stack
    {
        bool isEmpty();
        void push(int element);
        int pop();
    }

    public class BoundedStack : Stack
    {
        private int size;
        private int[] elements;

        public BoundedStack(int capacity)
        {
            elements = new int[capacity];
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void push(int element)
        {
            if(size == elements.Length)
                throw new OverflowException();
            elements[size++] = element;
        }

        public int pop()
        {
            if(size == 0)
                throw new UnderflowException();
            return elements[--size];
        }

        public class UnderflowException : Exception
        {
        }

        public class OverflowException : Exception
        {
        }
    }
    
}