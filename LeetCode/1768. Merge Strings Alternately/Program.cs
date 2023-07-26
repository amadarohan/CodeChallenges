//You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.

//Return the merged string.



//Example 1:

//Input: word1 = "abc", word2 = "pqr"
//Output: "apbqcr"
//Explanation: The merged string will be merged as so:
//word1: a b   c
//word2:    p q   r
//merged: a p b q c r
//Example 2:

//Input: word1 = "ab", word2 = "pqrs"
//Output: "apbqrs"
//Explanation: Notice that as word2 is longer, "rs" is appended to the end.
//word1:  a b
//word2:    p q   r s
//merged: a p b q   r s
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //var result = solution.MergeAlternately("abc", "pqr");
        //var result = solution.MergeAlternately("ab", "pqrs");
        var result = solution.MergeAlternately("abcd", "pq");
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public string MergeAlternately(string word1, string word2)
    {

        StringBuilder result = new StringBuilder();
        var indexer = word1.Length>word2.Length?word1.Length : word2.Length;
        var counter = 0;
        for (int i = 0; i < indexer; i++)
        {
            counter = i;
            if (i <word1.Length)
            {
                result.Append(word1[i]);
            }
            
            if (i < word2.Length) {
                result.Append(word2[i]);
            }
        }
        counter++;
        if (counter< word2.Length) {
            result.Append(word2.Substring(counter, word2.Length - (counter)));
        }
        if (counter < word1.Length)
        {
            result.Append(word1.Substring(counter, word1.Length - (counter)));
        }
        return result.ToString();
    }
}

public sealed class FastestSolution
{
    public string MergeAlternately(string word1, string word2)
    {
        char[] array = new char[word1.Length + word2.Length];
        int i2 = 0;
        int index = 0;

        if (word1.Length >= word2.Length)
        {
            for (int i = 0; i < word1.Length; i++)
            {
                array[index++] = word1[i];
                if (word2.Length > i2)
                {
                    array[index++] = word2[i2++];
                }
            }
        }

        else
        {
            for (int i = 0; i < word2.Length; i++)
            {
                if (word1.Length > i2)
                {
                    array[index++] = word1[i2++];
                }
                array[index++] = word2[i];
            }
        }
        return new string(array);
    }
}


public sealed class BestMemorySolution
{
    public string MergeAlternately(string word1, string word2)
    {
        // first method poped on my head is using nested loop
        //first one loop through the first word and the nested/ second one for the word2
        //Append the first word1 index 0 to index 0 char of the word2 
        // if the length isn't eq then add the remaning at the end of marged string 
        StringBuilder result = new StringBuilder();
        string remaning = "";
        int size1 = word1.Length;
        int size2 = word2.Length;
        int i = 0;
        int j = 0;
        while (i < size1 && j < size2)
        {
            result.Append(word1[i++]);
            result.Append(word2[j++]);
        }
        if (i < size1)
        {
            remaning = word1.Substring(i);
        }
        else if (j < size2)
        {
            remaning = word2.Substring(j);
        }
        if (remaning.Length > 0)
        {
            result.Append(remaning);
        }
        return result.ToString();
    }
}

