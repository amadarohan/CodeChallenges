//A sentence is a list of words that are separated by a single space with no leading or trailing spaces. Each word consists of lowercase and uppercase English letters.

//A sentence can be shuffled by appending the 1-indexed word position to each word then rearranging the words in the sentence.

//For example, the sentence "This is a sentence" can be shuffled as "sentence4 a3 is2 This1" or "is2 sentence4 This1 a3".
//Given a shuffled sentence s containing no more than 9 words, reconstruct and return the original sentence.
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //var result = solution.SortSentence("is2 sentence4 This1 a3"); 
        var result = solution.SortSentence("Myself2 Me1 I4 and3"); 
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public string SortSentence(string s)
    {
        SortedDictionary<int, string> sParts = new SortedDictionary<int, string>();
        var sSections = s.Split(' ');
        foreach (var sSection in sSections)
        {
            sParts.Add(int.Parse(sSection[sSection.Length - 1].ToString()), sSection.Substring(0, sSection.Length - 1));
        }

        StringBuilder result = new StringBuilder();
        foreach (var sortedSection in sParts)
        {
            result.Append(sortedSection.Value.ToString() + " ");
        }
        GC.Collect();
        return result.ToString().Trim();
    }


}

public sealed class FastestSolution
{
    public string SortSentence2(string s)
    {
        var sortedString = new StringBuilder();
        int index = 1;

        var words = s.Split(' ').ToList();

        while (index <= words.Count)
        {
            foreach (var word in words)
            {
                var lastChar = word[^1];
                var converted = (int)Char.GetNumericValue(lastChar);

                if (converted == index)
                {
                    sortedString.Append($" {word[..^1]}");
                    index++;
                }
            }
        }

        return sortedString.ToString().Trim();
    }
    public string SortSentence(string s)
    {
        string[] inputWords = s.Split(' ');
        string[] outputWords = new string[inputWords.Length];
        string result = "";

        for (int i = 0; i < inputWords.Length; i++)
        {
            for (int j = 0; j < inputWords.Length; j++)
            {
                char[] wordChar = inputWords[j].ToCharArray();

                for (int k = 0; k < wordChar.Length; k++)
                {
                    if (Char.IsDigit(wordChar[k]))
                    {
                        if ((int)Char.GetNumericValue(wordChar[k]) == i + 1)
                        {
                            outputWords[i] = inputWords[j];
                            break;
                        }
                    }
                }
            }
        }

        string resultDigits = string.Join(" ", outputWords);

        foreach (char c in resultDigits)
        {
            if (!Char.IsDigit(c))
            {
                result += c;
            }
        }

        return result;
    }
}


public sealed class BestMemorySolution
{
    public string SortSentence(string s)
    {
        string[] arr = s.Split(' ');
        string[] arr2 = new string[arr.Length];
        StringBuilder result = new StringBuilder();
        foreach (string current in arr)
        {
            int indx = current[current.Length - 1] - '1';
            arr2[indx] = current.Remove(current.Length - 1);
        }
        for (int i = 0; i < arr2.Length; i++)
        {
            if (i < arr2.Length - 1)
                result.Append(arr2[i] + " ");
            else
                result.Append(arr2[i]);
        }
        return result.ToString();
    }
}

