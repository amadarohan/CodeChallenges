class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] testCase = new int[] { 0, 2, 1, 5, 3, 4 };
        int[] testCase = new int[] { 1,2,1 };
        int[] result = solution.GetConcatenation(testCase);
        Console.WriteLine(result);

    }
}
public sealed class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        var result = new int[nums.Length * 2];
        Array.Copy(nums, 0, result, 0, nums.Length);
        Array.Copy(nums, 0, result, nums.Length, nums.Length);
        return result;
    }
}

public class FastestSolution
{
    public int[] GetConcatenation(int[] nums)
    {
        int[] ans = new int[2 * nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = nums[i];
            ans[i + nums.Length] = nums[i];
        }
        return ans;
    }
}
public class BestMemorySolution
{
    public int[] GetConcatenation(int[] nums)
    {
        int[] ans = new int[2 * nums.Length];
        for (int i = 0; i < nums.Length; ++i)
        {
            ans[i] = nums[i];
            ans[i + nums.Length] = nums[i];
        }
        GC.Collect();
        return ans;
    }
}

public class SecondBestMemorySolution
{
    public int[] GetConcatenation(int[] nums)
    {
        var res = new int[nums.Length * 2];
        nums.CopyTo(res, 0);
        nums.CopyTo(res, nums.Length);
        GC.Collect();
        return res;
    }
}
