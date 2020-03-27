using System;

namespace FizzBuzz
{
    public class Stack
    {
        private int size = 0;
        private int[] element = new int[2];

        public int pop()
        {
            if(isEmpty())
                throw new UnderflowException();
            return element[--size];
        }

        public void push(int value)
        {
            element[size++] = value;
        }

        public bool isEmpty()
        {
            return size == 0;
        }
        
        public class UnderflowException : Exception
        {
        }
    }
}