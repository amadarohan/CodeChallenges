//Given an array of integers nums, return the number of good pairs.

//A pair (i, j) is called good if nums[i] == nums[j] and i<j.

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] testCase = new int[] { 1, 2, 3, 1, 1, 3 };
        int result = solution.NumIdenticalPairs(testCase);
        Console.WriteLine(result.ToString());

    }
}
public class Solution
{
    //public int NumIdenticalPairs(int[] nums)
    //{
    //    int result = 0;

    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        for (int j = i+1; j < nums.Length; j++)
    //        {
    //            if (nums[i] == nums[j] && i < j)
    //            {
    //                result++;
    //            }
    //        }
    //    }

    //    return result;
    //}

    public int NumIdenticalPairs(int[] nums)
    {
        int result = 0;
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }

        foreach (int key in freq.Keys)
        {
            int n = freq[key];
            result += n * (n - 1) / 2;
        }

        return result;
    }
}

public class FastestSolution
{
    public int NumIdenticalPairs(int[] nums)
    {
        var map = new Dictionary<int, int>(nums.Length);
        var pair = 0;

        foreach (var num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 1);
            else
                map[num] += 1;
        }

        foreach (var num in map)
        {
            var n = num.Value;
            pair += n * (n - 1) / 2;
        }

        return pair;
    }
}
