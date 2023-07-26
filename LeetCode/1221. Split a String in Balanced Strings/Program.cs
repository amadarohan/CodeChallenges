//Balanced strings are those that have an equal quantity of 'L' and 'R' characters.

//Given a balanced string s, split it into some number of substrings such that:

//Each substring is balanced.
//Return the maximum number of balanced strings you can obtain.
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.BalancedStringSplit("RLRRLLRLRL"));
        Console.WriteLine(solution.BalancedStringSplit("RLRRRLLRLL"));
        Console.WriteLine(solution.BalancedStringSplit("LLLLRRRR"));

    }
}
public sealed class Solution
{
    //public int BalancedStringSplit(string s)
    //{
    //    int result = 0;
    //    StringBuilder subs = new StringBuilder();
    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        subs.Clear();
    //        subs.Append(s[i]);
    //        for (int j = i+1; j < s.Length; j++)
    //        {
    //            var nextSubs = s.Substring(j, subs.Length);
    //            if (nextSubs != subs.ToString())
    //            {
    //                if (!nextSubs.Any(x=>x==subs[0])) {
    //                    result++;
    //                    i+= subs.Length*2-1; //this is not ok!
    //                    j= int.MaxValue-1;
    //                }
    //            }
    //            else
    //            {
    //                subs.Append(s[j]);
    //            }
    //        }
    //    }
    //    GC.Collect();
    //    return result;
    //}

    public int BalancedStringSplit(string s)
    {
        int result = 0;
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'R')
                count++;
            else
                count--;
            if (count == 0)
                result++;
        }
        return result;
    }
}

public sealed class FastestSolution
{
    public int BalancedStringSplit(string s)
    {
        int lcounter = 0, rcounter = 0, counter = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'R') rcounter++;
            else lcounter++;

            if (lcounter == rcounter) counter++;

        }
        return counter;

    }
}


public sealed class BestMemorySolution
{
    public int BalancedStringSplit(string s)
    {
        int count = 0;
        int countR = 0;
        int countL = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'R')
                countR++;
            else if (s[i] == 'L')
                countL++;

            if (countR == countL)
            {
                count++;
                countR = 0;
                countL = 0;
            }
        }
        return count;
    }

    public int BalancedStringSplitV2(string s)
    {
        int size = s.Length, a = 0, b = 0, count = 0;
        for (int i = 0; i < size; i++)
        {
            if (s[i] == 'L') a++;
            else b++;
            if (a == b)
            {
                count++;
                a = b = 0;
            }
        }
        return count;
    }
}

