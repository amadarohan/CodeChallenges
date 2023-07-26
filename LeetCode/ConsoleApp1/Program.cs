//You are given the strings key and message, which represent a cipher key and a secret message, respectively. The steps to decode message are as follows:

//Use the first appearance of all 26 lowercase English letters in key as the order of the substitution table.
//Align the substitution table with the regular English alphabet.
//Each letter in message is then substituted using the table.
//Spaces ' ' are transformed to themselves.
//For example, given key = "happy boy" (actual key would have at least one instance of each letter in the alphabet), we have the partial substitution table of ('h' -> 'a', 'a' -> 'b', 'p' -> 'c', 'y' -> 'd', 'b' -> 'e', 'o' -> 'f').
//Return the decoded message.

using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        var result = solution.DecodeMessage("the quick brown fox jumps over the lazy dog", "vkbs bs t suepuv");
        var result2 = solution.DecodeMessage("eljuxhpwnyrdgtqkviszcfmabo", "zwx hnfx lqantp mnoeius ycgk vcnjrdb");
        Console.WriteLine(result.ToString());
        Console.WriteLine(result2.ToString());

    }
}
public sealed class Solution
{
    //public string DecodeMessage(string key, string message)
    //{
    //    StringBuilder result = new StringBuilder();
    //    key = new string(key.Replace(" ","").ToCharArray().Distinct().ToArray());
    //    Dictionary<char, char> cipherKeys = new Dictionary<char, char>();
       
    //    for (int i = 0; i < 26; i++)
    //    {
    //        cipherKeys.Add( key[i], (char)('a' + i));
    //    }
    //    cipherKeys.Add(' ', ' ');
    //    foreach (var item in message)
    //    {
    //            result.Append(cipherKeys[item]);
    //    }

    //    GC.Collect();
    //    return result.ToString();
    //}
    public string DecodeMessage(string key, string message)
    {
        char[] result = new char[message.Length];
        key = new string(key.Replace(" ", "").Distinct().ToArray());
        Dictionary<char, char> cipherKeys = new Dictionary<char, char>();

        for (int i = 0; i < key.Length; i++)
        {
            cipherKeys.Add(key[i], (char)('a' + i));
        }
        cipherKeys.Add(' ', ' ');
        for (int i = 0; i < message.Length; i++)
        {
            result[i] = cipherKeys[message[i]];
        }

        return new string(result);
    }
}

public sealed class FastestSolution
{
    public string DecodeMessage(string key, string message)
    {
        var map = new Dictionary<char, char>(26);
        var sb = new StringBuilder();

        var letter = 'a';

        map.Add(' ', ' ');

        for (int i = 0; i < key.Length; i++)
        {
            if (!map.ContainsKey(key[i]) && key[i] != ' ')
            {
                map.Add(key[i], letter++);
            }
        }

        foreach (var c in message)
        {
            if (map.ContainsKey(c))
            {
                sb.Append(map[c]);
            }

        }

        return sb.ToString();
    }
}


public sealed class BestMemorySolution
{
    public string DecodeMessage(string key, string message)
    {
        int index = 0;
        char[] table = new char[26];
        char[] result = new char[message.Length];
        foreach (var chr in key)
        {
            if (!char.IsLetter(chr))
                continue;
            int i = chr - 'a';
            if (table[i] == '\0')
                table[i] = (char)('a' + index++);
        }
        for (int i = 0; i < result.Length; i++)
            if (char.IsLetter(message[i]))
                result[i] = table[message[i] - 'a'];
            else
                result[i] = message[i];
        return new string(result);
    }
}

