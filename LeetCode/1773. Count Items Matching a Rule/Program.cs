//You are given an array items, where each items[i] = [typei, colori, namei] describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.

//The ith item is said to match the rule if one of the following is true:

//ruleKey == "type" and ruleValue == typei.
//ruleKey == "color" and ruleValue == colori.
//ruleKey == "name" and ruleValue == namei.
//Return the number of items that match the given rule.

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

    

        IList<IList<string>> items = new List<IList<string>>();
        items.Add(new List<string>() { "phone", "blue", "pixel" });
        items.Add(new List<string>() { "computer", "silver", "lenovo" });
        items.Add(new List<string>() { "phone", "gold", "iphone" });
        
        //int result = solution.CountMatches(items, "type", "phone");
        int result = solution.CountMatches(items, "color", "silver");
        
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    private static readonly Dictionary<string, int> Rules = new Dictionary<string, int>
    {
        {"type", 0},
        {"color", 1},
        {"name", 2}
    };
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        int result = 0;
        
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i][Rules[ruleKey]] == ruleValue) {
                ++result;
            }
        }
        return result;
    }
}

public sealed class FastestSolution
{
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {

        List<int> list = new List<int>();
        int count = 0;


        if (ruleKey.Equals("color"))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i][1].Equals(ruleValue))
                {
                    count++;
                }
            }
        }
        else if (ruleKey.Equals("type"))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i][0].Equals(ruleValue))
                {
                    count++;
                }
            }
        }
        else if (ruleKey.Equals("name"))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i][2].Equals(ruleValue))
                {
                    count++;
                }
            }
        }

        return count;
    }

    public int CountMatches2(IList<IList<string>> items, string ruleKey, string ruleValue)
               => items.Where(x => x[0] == ruleValue && ruleKey == "type"
                                   ||
                                   x[1] == ruleValue && ruleKey == "color"
                                   ||
                                   x[2] == ruleValue && ruleKey == "name").Count();

}


public sealed class BestMemorySolution
{
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        int result = 0;

        int keyIndex = ruleKey switch
        {
            "type" => 0,
            "color" => 1,
            "name" => 2,
            _ => 3
        };

        for (int i = 0; i < items.Count; i++)
            if (items[i][keyIndex] == ruleValue)
                result++;

        return result;
    }
}

