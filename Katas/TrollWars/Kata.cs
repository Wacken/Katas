namespace TrollWars
{
    public static class Kata
    {
        static string[] vowels = new string[10] {"a", "i", "u", "e", "o","A","I","U","E","O"};

        public static string Disemvowel(string str)
        {
            if (isVowel(str))
                return "";
            return str;
        }

        static bool isVowel(string str)
        {
            foreach (var vowel in vowels)
                if (str.Contains(vowel))
                    return true;

            return false;
        }
    }
}