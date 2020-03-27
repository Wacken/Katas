using System;
using System.Text;

namespace FizzBuzz
{
    public static class FizzBuzzC
    {
        public static string of(int value)
        {
            var returnValueBuilder = new StringBuilder();
            if (value == 0)
                return "0";
            if (value % 3 == 0)
                returnValueBuilder.Append("Fizz");
            if (value % 5 == 0)
                returnValueBuilder.Append("Buzz");
            
            var returnValue = returnValueBuilder.ToString();
            return !string.IsNullOrEmpty(returnValue) ? returnValue : value.ToString();
        }
    }
}