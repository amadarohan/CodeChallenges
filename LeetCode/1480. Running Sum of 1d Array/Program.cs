//Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).

//Return the running sum of nums.
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCase = new int[] { 1, 2, 3, 4 };
        int[] result = solution.RunningSum(testCase);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public int[] RunningSum(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            nums[i] = sum;
        }
        return nums;
    }
}

public sealed class FastestSolution
{
    public int[] RunningSum(int[] nums)
    {
        var meme = new List<int>();
        var total = 0;

        foreach (var num in nums)
        {
            total = total + num;
            meme.Add(total);
        }
        return meme.ToArray();
    }

    public int[] RunningSum2(int[] nums)
    {
        var prefix = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
            prefix[i] = i > 0 ? prefix[i - 1] + nums[i] : nums[i];

        return prefix;
    }

}


public sealed class BestMemorySolution
{
    public int[] RunningSum(int[] nums)
    {
        var resultArray = new int[nums.Length];

        var currentRunningSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            currentRunningSum += nums[i];
            resultArray[i] = currentRunningSum;
        }
        return resultArray;
    }

    public int[] RunningSum2(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] + nums[i - 1];
        }

        return nums;
    }
}

