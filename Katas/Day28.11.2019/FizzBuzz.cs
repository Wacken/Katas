using System;

namespace Day28._11._2019
{
    public class FizzBuzz
    {
        public static string fizzBuzz(int number)
        {
            string output = String.Empty;
            if (number == 0)
                return "0";
            if (number % 3 == 0)
                output+= "Fizz";
            if (number % 5 == 0)
                output+= "Buzz";
            return !String.IsNullOrEmpty(output) ? output : number.ToString();
        }
    }
}