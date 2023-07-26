class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //int[] testCase = new int[] { 2, 5, 1, 3, 4, 7 };
        //int[] result = solution.Shuffle(testCase,3);
        int[] testCase = new int[] { 1, 2, 3, 4, 4, 3, 2, 1 };
        int[] result = solution.Shuffle(testCase, 4);
        Console.WriteLine(result.ToString());

    }
}
public class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        int[] ans = new int[nums.Length];
        int i = 0;
        for (int index = 0; index < nums.Length; index+=2)
        {
            ans[index] = nums[i];
            ans[index+1] = nums[n+i];
            i++;
        }
        GC.Collect();
        return ans;
    }
}

public class BestRunTimeSolution
{
    public int[] Shuffle(int[] nums, int n)
    {

        int[] shuffleArr = new int[nums.Length];
        int p = nums.Length / 2;


        for (int i = 0, j = 0; i <= p - 1; i++, j += 2)
        {

            shuffleArr[j] = nums[i];
            shuffleArr[j + 1] = nums[n];
            n++;
        }
        return shuffleArr;

    }
}


