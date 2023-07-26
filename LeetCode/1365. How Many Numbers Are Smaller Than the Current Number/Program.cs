//Given the array nums, for each nums[i] find out how many numbers in the array are smaller than it. That is, for each nums[i] you have to count the number of valid j's such that j != i and nums[j] < nums[i].

//Return the answer in an array.
class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCase = new int[] { 8, 1, 2, 2, 3 };
        int[] result = solution.SmallerNumbersThanCurrent(testCase);
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int[] result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i]> nums[j]) {
                    result[i]++;
                }
            }
        }
        return result;
    }

    public int[] SmallerNumbersThanCurrent2(int[] nums)
    {
        // create a sorted copy of the array
        int[] sorted = new int[nums.Length];
        Array.Copy(nums, sorted, nums.Length);
        Array.Sort(sorted);

        // create a dictionary to store the rank of each number
        Dictionary<int, int> rank = new Dictionary<int, int>();
        for (int i = 0; i < sorted.Length; i++)
        {
            // avoid duplicate keys
            if (!rank.ContainsKey(sorted[i]))
            {
                rank.Add(sorted[i], i);
            }
        }

        // create the result array
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            // look up the rank of each number in the dictionary
            result[i] = rank[nums[i]];
        }

        return result;
    }
}

public sealed class FastestSolution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var freqArray = new int[101];
        foreach (var number in nums)
        {
            freqArray[number]++;
        }

        for (int i = 1; i < freqArray.Length; i++)
        {
            freqArray[i] += freqArray[i - 1];
        }

        var results = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                results[i] = 0;
            }
            else
            {
                results[i] = freqArray[nums[i] - 1];
            }
        }

        return results;
    }

    public int[] SmallerNumbersThanCurrent2(int[] nums)
    {
        int[] res = new int[101];
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            res[nums[i]] += 1;
        }
        for (int i = 1; i < res.Length; i++)
        {
            res[i] += res[i - 1];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = (nums[i] == 0) ? 0 : res[nums[i] - 1];
        }
        return result;
    }
}

public sealed class BestMemorySolution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        int[] output = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < nums.Length; j++)
            { // ой)
                if (nums[j] < nums[i])
                {
                    count++;
                }


            }
            output[i] = count;
        }
        return output;
    }


    public int[] SmallerNumbersThanCurrent2(int[] nums)//worst
    {
        var sorted = nums.OrderBy(x => x)
            .Select((current, index) => new { Item = current, Index = index })
            .DistinctBy(x => x.Item)
            .ToDictionary(x => x.Item, x => x.Index);

        return nums.Select(x => sorted[x]).ToArray();
    }
}

