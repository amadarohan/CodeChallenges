
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCase = new int[] { 1, 2, 3, 4, 4, 3, 2, 1 };
        int[] result = solution.Shuffle(testCase, 4);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public int[] Shuffle(int[] nums, int n)
    {
        int[] result = new int[n];
        GC.Collect();
        return result;
    }
}

public sealed class FastestSolution
{
    
}


public sealed class BestMemorySolution
{
    
}

