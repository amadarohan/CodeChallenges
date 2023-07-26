//You are given a string s and an integer array indices of the same length. The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.

////Return the shuffled string.
using System.Text;
///
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCase = new int[] { 4, 5, 6, 7, 0, 2, 1, 3 };
        var result = solution.RestoreString("codeleet", testCase);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    //public string RestoreStringv2(string s, int[] indices)
    //{
    //    var result = new StringBuilder();
    //    var sorted = new SortedDictionary<int, char>();
    //    for (int i = 0; i < indices.Length; i++)
    //    {
    //        sorted.Add(indices[i], s[i]);
    //    }
    //    foreach (var item in sorted)
    //    {
    //        result.Append(item.Value);
    //    }

    //    GC.Collect();
    //    return result.ToString();
    //}
    public string RestoreString(string s, int[] indices)
    {
        char[] sArray = s.ToCharArray();
        Array.Sort(indices, sArray);
        return new string(sArray);
    }
}

public sealed class FastestSolution
{
    public string RestoreString(string s, int[] indices)
    {
        string b = new string(s);
        char[] c = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            c[indices[i]] = s[i];
        }
        return new string(c);
    }
}


public sealed class BestMemorySolution
{
    public string RestoreString(string s, int[] indices)
    {
        List<char> Output = Enumerable.Repeat(' ', s.Length).ToList();
        for (int i = 0; i < s.Length; i++)
        {
            Output[indices[i]] = s[i];
        }
        GC.Collect();
        return string.Join("", Output.ToArray());
    }

    public string RestoreString2(string s, int[] indices)
    {
        StringBuilder str2 = new StringBuilder(s);
        for (int i = 0; i < s.Length; i++)
        {
            str2[indices[i]] = s[i];
        }
        GC.Collect();
        return str2.ToString();
    }
}

