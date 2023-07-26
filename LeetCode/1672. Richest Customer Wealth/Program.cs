//You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the i​​​​​​​​​​​th​​​​ customer has in the j​​​​​​​​​​​th​​​​ bank. Return the wealth that the richest customer has.

//A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //var testCase = new int[][] {
        //                            new int[] {1, 2, 3},
        //                            new int[] {3, 2, 1}
        //                            };
        var testCase = new int[][] {
                                    new int[] {1, 5},
                                    new int[] {7,3},
                                    new int[] {3, 5}
                                    };
        int result = solution.MaximumWealth(testCase);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    //public int MaximumWealth(int[][] accounts)
    //{
    //    int result = 0,temp=0;
    //    for (int i = 0; i < accounts.Length; i++)
    //    {
    //        temp = accounts[i].Sum();
    //        if (temp>result)
    //            result = temp;
    //    }
    //    return result;
    //}

    public int MaximumWealth(int[][] accounts)
    {
        int result = 0;
        int temp = 0;
        for (int i = 0; i < accounts.Length; i++)
        {
            
            for (int j = 0; j < accounts[i].Length; j++)
            {
                temp += accounts[i][j];
            }
            if (temp > result)
                result = temp;
            temp = 0;
        }
        return result;
    }
}

public sealed class FastestSolution
{
    public int MaximumWealth(int[][] accounts)
    {
        int biggestWealth = 0;

        for (int i = 0; i < accounts.Length; i++)
        {
            int wealth = accounts[i].Sum();
            if (wealth > biggestWealth) biggestWealth = wealth;
        }

        return biggestWealth;
    }
}


public sealed class BestMemorySolution
{
    public int MaximumWealth(int[][] accounts)
    {
        var richest = 0;

        for (var i = 0; i < accounts.Length; i++)
        {
            var sum = 0;

            for (var j = 0; j < accounts[i].Length; j++)
            {
                sum += accounts[i][j];
            }

            if (sum >= richest) richest = sum;
        }

        GC.Collect();
        return richest;
    }

    public int MaximumWealthv2(int[][] accounts)//worst but its linq
    {
        return accounts.Select(x => x.Sum()).Max();
    }
}

