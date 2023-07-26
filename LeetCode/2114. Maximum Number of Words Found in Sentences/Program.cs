//A sentence is a list of words that are separated by a single space with no leading or trailing spaces.

//You are given an array of strings sentences, where each sentences[i] represents a single sentence.

//Return the maximum number of words that appear in a single sentence.
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //string[] testCase = new string[] { "alice and bob love leetcode", "i think so too", "this is great thanks very much" };
        string[] testCase = new string[] { "please wait", "continue to fight", "continue to win" };
        int result = solution.MostWordsFound(testCase);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public int MostWordsFound(string[] sentences)
    {
        int result = 0;

        foreach (var item in sentences)
        {
            var wordsCount = item.Count(x => x == ' ');
            if (wordsCount > result)
            {
                result = wordsCount;
            }
        }

        return ++result;
    }
    //public int MostWordsFoundv2(string[] sentences)
    //{
    //    return sentences.Max(s => s.Count(c => c == ' ')) + 1;
    //}
}

public sealed class FastestSolution
{
    public int MostWordsFound(string[] sentences)
    {
        int max = 0;
        foreach (var item in sentences)
        {
            var stringItems = item.Split(' ').Length;
            if (stringItems > max) max = stringItems;
        }
        return max;
    }
}


public sealed class BestMemorySolution
{
    public int MostWordsFound(string[] sentences)
    {
        int maxCount = 0;
        for (int i = 0; i < sentences.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < sentences[i].Length; j++)
            {
                if (sentences[i][j] == ' ')
                    count++;
            }
            maxCount = Math.Max(maxCount, count);
        }
        return maxCount + 1;
    }
}

