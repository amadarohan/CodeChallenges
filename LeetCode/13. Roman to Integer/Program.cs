namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.RomanToInt("IX");
            Console.WriteLine(result);

            Console.WriteLine(solution.RomanToInt("III"));
            Console.WriteLine(solution.RomanToInt("IV"));
            Console.WriteLine(solution.RomanToInt("XXVII"));

        }
    }


    public sealed class Solution
    {
        // Create a new dictionary
        private Dictionary<char, int> symbols = new Dictionary<char, int>();
        public Solution()
        {
            // Add key-value pairs
            symbols.Add('I', 1);
            symbols.Add('V', 5);
            symbols.Add('X', 10);
            symbols.Add('L', 50);
            symbols.Add('C', 100);
            symbols.Add('D', 500);
            symbols.Add('M', 1000);
        }

        public int RomanToInt(string s)
        {
            int value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 >= s.Length)
                {
                    value += symbols[s[i]];
                    break;
                }

                if (symbols[s[i]] < symbols[s[i + 1]]) // if the char is less than its next char then it must subtracted, IX is 4, I is 1 and X is 5 so I - X = 4, But XI is 6.
                {
                    value -= symbols[s[i]];
                }
                else
                {
                    value += symbols[s[i]];
                }
            }
            return value;
        }
    }


    //best in memory:
    public class BestInMemorySolution
    {
        public int RomanToInt(string s)
        {
            var dict = new Dictionary<string, int>
        {
            {"M", 1000},
            {"CM", 900},
            {"D",  500},
            {"CD", 400},
            {"C",  100},
            {"XC",  90},
            {"L",   50},
            {"XL",  40},
            {"X",   10},
            {"IX",   9},
            {"V",    5},
            {"IV",   4},
            {"I",    1}
        };

            int result = 0;
            while (s.Length > 0)
            {
                int value = 0;
                if (s.Length >= 2)
                {
                    var firstTwo = s.Substring(0, 2);
                    if (dict.TryGetValue(firstTwo, out value))
                    {
                        s = s.Substring(2, s.Length - 2);
                        result += value;
                        continue;
                    }
                }
                var firstOne = s.Substring(0, 1);
                value = dict[firstOne];
                s = s.Substring(1, s.Length - 1);
                result += value;
            }

            return result;
        }
    }

    //best in runtime
    public class BestInRunTimeSolution
    {
        static IDictionary<char, int> romanNum = new Dictionary<char, int>() {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
        public int RomanToInt(string s)
        {
            char[] numerals = s.ToCharArray();
            int sum = 0, addition = 0;

            for (int i = 0; i < numerals.Length; i++)
            {
                if (i < numerals.Length - 1 && romanNum[numerals[i]] < romanNum[numerals[i + 1]] && romanNum[numerals[i]].ToString()[0] == '1')
                {
                    addition = romanNum[numerals[i + 1]] - romanNum[numerals[i]];
                    i++;
                }
                else
                    addition = romanNum[numerals[i]];

                Console.WriteLine(addition);

                sum += addition;
            }
            return sum;
        }
    }
}



