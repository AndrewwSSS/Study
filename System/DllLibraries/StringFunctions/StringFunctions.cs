using System.Linq;
using System.Text.RegularExpressions;

namespace String_Functions
{
    public static class StringFunctions
    {
        public static bool StringIsPalindrome(string str)
        {
            str = str.Replace(" ", "");

            string reversStr = new string(str.Reverse().ToArray());

            if (str == reversStr)
                return true;
            else
                return false;


        }

        public static string ReversString(string str) {
            return new string(str.Reverse().ToArray());
        }

        public static int CountSentences(string str)
        {
            str = Regex.Replace(str, " {2,}", " ");
            string[] lines = str.Trim(' ').Split(' ');
            
            int NumberOfSentences = 0, CurrWordsInSentence = 0;

            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i].Count((symbol) => symbol == '!' || symbol == '?' || symbol == '.') == lines[i].Length)
                {
                    if (CurrWordsInSentence > 0)
                    {
                        NumberOfSentences++;      
                    }
                }
                else
                {
                    CurrWordsInSentence++;

                    if ((lines[i].Contains('.') || lines[i].Contains('!') || lines[i].Contains('?')) && CurrWordsInSentence != 0)
                    {
                        NumberOfSentences++;
                        CurrWordsInSentence = 0;
                    }

                }
            }

            return NumberOfSentences;
        }
    }
}
