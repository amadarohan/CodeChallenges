class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        string[] testCase = new string[] { "++X", "++X", "X++" };
        int result = solution.FinalValueAfterOperations(testCase);
        Console.WriteLine(result);

    }
}
public sealed class Solution
{
    private Dictionary<string, int> symbols = new Dictionary<string, int>();
    public Solution()
    {
        symbols.Add("X++", 1);
        symbols.Add("++X", 1);
        symbols.Add("--X", -1);
        symbols.Add("X--", -1);
    }
    public int FinalValueAfterOperations(string[] operations)
    {
        int result = 0;
        foreach (var item in symbols)
        {
            result += operations.Count(x => x == item.Key) * item.Value;
        }

        GC.Collect();
        return result;
    }
}
public sealed class FastestSolution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        int ans = 0;
        for (int i = 0; i < operations.Length; i++)
        {
            if (operations[i].Contains('-'))
            {
                ans--;
            }
            else
            {
                ans++;
            }
        }
        return ans;
    }
}
