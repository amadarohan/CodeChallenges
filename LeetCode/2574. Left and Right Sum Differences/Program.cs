//2574.Left and Right Sum Differences
//Easy
//578
//42
//Companies
//Given a 0-indexed integer array nums, find a 0-indexed integer array answer where:

//answer.length == nums.length.
//answer[i] = | leftSum[i] - rightSum[i] |.
//Where:

//leftSum[i] is the sum of elements to the left of the index i in the array nums. If there is no such element, leftSum[i] = 0.
//rightSum[i] is the sum of elements to the right of the index i in the array nums. If there is no such element, rightSum[i] = 0.
//Return the array answer.



//Example 1:

//Input: nums = [10, 4, 8, 3]
//Output: [15,1,11,22]
//Explanation: The array leftSum is [0, 10, 14, 22] and the array rightSum is [15, 11, 3, 0].
//The array answer is [|0 - 15|,|10 - 11|,|14 - 3|,|22 - 0|] = [15, 1, 11, 22].

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCase = new int[] { 10, 4, 8, 3 };
        //int[] testCase = new int[] { 1 ,2};
        int[] result = solution.LeftRightDifference(testCase);
        Console.WriteLine(result);

    }
}
public sealed class Solution
{
    //public int[] LeftRightDifference1(int[] nums)
    //{
    //    int[] result = new int[nums.Length];
    //    int[] LeftSum = new int[nums.Length];
    //    int[] RightSum = new int[nums.Length];

    //    if (nums.Length > 1) {
    //        for (int i = 1; i <= nums.Length-1; i++)
    //        {
    //            //left
    //            LeftSum[i] += LeftSum[i-1]+ nums[i - 1];//[10,4,8,3]
    //            //right
    //            RightSum[(nums.Length - 1) - i] += nums[nums.Length - i]+ RightSum[nums.Length - i];//[0, 1, 2, 3]
    //        }
    //        for (int i = 0; i < nums.Length; i++)
    //        {
    //            result[i] = Math.Abs(LeftSum[i] - RightSum[i]);
    //        }
    //        return result;
    //    }

    //    result[0] = 0;
    //    return result;
    //}

    public int[] LeftRightDifference(int[] nums)
    {
        int[] result = new int[nums.Length];
        int leftSum = 0;
        int rightSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            rightSum -= nums[i];
            result[i] = Math.Abs(leftSum - rightSum);
            leftSum += nums[i];
        }

        return result;
    }
}

public sealed class FastestSolution
{
    public int[] LeftRightDifference(int[] nums)
    {
        int[] answer = new int[nums.Length];
        int rightSum = 0;
        for (int i = 0; i < nums.Length; i++)
            rightSum += nums[i];

        int leftSum = 0;
        for (int i = 0; i < answer.Length; i++)
        {
            if (i > 0)
                leftSum += nums[i - 1];
            rightSum -= nums[i];

            answer[i] = Math.Abs(leftSum - rightSum);
        }
        return answer;
    }
}


public sealed class BestMemorySolution
{
    public int[] LeftRigthDifference(int[] nums)
    {
        //int[] f = new int[nums.Length];
        int a = 0, b = nums.Sum();

        for (int i = 0; i < nums.Length; i++)
        {
            a += nums[i];
            b -= nums[i];
            nums[i] = Math.Abs(a - b - nums[i]);

        }
        return nums;
    }
}

