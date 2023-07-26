//Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.

//A string is represented by an array if the array elements concatenated in order forms the string.
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] testCase = new string[] { "ab", "c" };
        string[] testCase1 = new string[] { "a", "bc" };
        var result = solution.ArrayStringsAreEqual(testCase, testCase1);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        return string.Join("",word1) == string.Join("", word2);
    }
    //public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    //{
    //    int i = 0, j = 0;
    //    int index1 = 0, index2 = 0;
    //    while (i < word1.Length && j < word2.Length)
    //    {
    //        if (word1[i][index1] != word2[j][index2])
    //            return false;
    //        index1++;
    //        index2++;
    //        if (index1 == word1[i].Length)
    //        {
    //            i++;
    //            index1 = 0;
    //        }
    //        if (index2 == word2[j].Length)
    //        {
    //            j++;
    //            index2 = 0;
    //        }
    //    }
    //    return i == word1.Length && j == word2.Length;
    //}
}

public sealed class FastestSolution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {

        string empty1 = "";
        string empty2 = "";



        for (int i = 0; i < word1.Length; i++)
        {
            empty1 += word1[i];

        }

        for (int i = 0; i < word2.Length; i++)
        {

            empty2 += word2[i];
        }

        if (empty1 == empty2)
        {
            return true;
        }

        return false;
    }
}


public sealed class BestMemorySolution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        string str1 = string.Concat(word1);
        string str2 = string.Concat(word2);
        if (str1 == str2)
        {
            return true;
        }
        return false;
    }
}

