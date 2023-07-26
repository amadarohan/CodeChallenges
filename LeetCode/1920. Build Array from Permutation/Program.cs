class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] testCase = new int[] { 0, 2, 1, 5, 3, 4 };
        int[] testCase = new int[] { 5, 0, 1, 2, 3, 4 };
        int[] result = solution.BuildArray(testCase);
        Console.WriteLine(result);

    }
}


public sealed class Solution
{
    public int[] BuildArray(int[] nums)
    {
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[nums[i]];
        }
        return result;
    }
}

public class BestMemorySolution
{
    public int[] BuildArray(ReadOnlySpan<int> nums)
    {
        Span<int> ans = stackalloc int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
            ans[i] = nums[nums[i]];

        GC.Collect();

        return ans.ToArray();
    }
}

public sealed class ChatGptOptimizedOfSolution
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            // store the result in the lower 16 bits
            nums[i] = nums[i] | (nums[nums[i]] << 16);
        }
        for (int i = 0; i < n; i++)
        {
            // right shift to get the final result
            nums[i] = nums[i] >> 16;
        }
        return nums;
    }
}

public class OneLineSolution
{
    public int[] BuildArray(int[] nums)
    {
        return nums.Select(x => nums[x]).ToArray();
    }
}
