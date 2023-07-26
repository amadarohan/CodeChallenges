using System.Diagnostics.Metrics;

//There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, and an integer extraCandies, denoting the number of extra candies that you have.

//Return a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, they will have the greatest number of candies among all the kids, or false otherwise.

//Note that multiple kids can have the greatest number of candies.

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] testCase = new int[] { 2, 3, 5, 1, 3 };
        //var result = solution.KidsWithCandies(testCase, 3);
        int[] testCase = new int[] { 4, 2, 1, 1, 2 };
        var result = solution.KidsWithCandies(testCase, 1);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    //public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    //{
    //    bool[] result = Enumerable.Repeat(true, candies.Length).ToArray();

    //    for (int i = 0; i < candies.Length; i++)
    //    {
    //        for (int j = 0; j < candies.Length; j++)
    //        {
    //            if (candies[i] + extraCandies < candies[j])
    //            {
    //                result[i] = false;
    //                break;
    //            }
    //        }

    //    }

    //    GC.Collect();
    //    return result;
    //}

    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        int maxCandies = candies.Max();
        bool[] result = new bool[candies.Length];
        for (int i = 0; i < candies.Length; i++)
        {
            result[i] = candies[i] + extraCandies >= maxCandies;
        }
        GC.Collect();
        return result;
    }

}


public class FastestSolution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        List<bool> result = new List<bool>();
        int max = candies.Max();
        for (int i = 0; i < candies.Length; i++)
        {
            if (candies[i] + extraCandies >= max)
                result.Add(true);
            else result.Add(false);
        }
        return result;
    }
}

public class BestMemorySolution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = candies.Max() - extraCandies;
        return candies.Select(c => c >= max).ToList();
    }
}