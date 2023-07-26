//You 're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.

//Letters are case sensitive, so "a" is considered a different type of stone from "A".

namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.NumJewelsInStones("aA", "aAAbbbb");
            Console.WriteLine(result);

            Console.WriteLine(solution.NumJewelsInStones("z","ZZ"));
        }
    }

    public class Solution
    {
        //public int NumJewelsInStones(string jewels, string stones)
        //{

        //    IDictionary<char, int> jewelsDic = new Dictionary<char, int>();
        //    for (int i = 0; i < jewels.Length; i++)
        //    {
        //        jewelsDic.Add(jewels[i], 1);
        //    }

        //    int sum = 0;

        //    for (int i = 0; i < stones.Length; i++)
        //    {
        //        if (jewelsDic.ContainsKey(stones[i])){
        //            sum++;
        //        }
        //    }
        //    return sum;
        //}

        public int NumJewelsInStones(string jewels, string stones)
        {
            HashSet<char> jewelsSet = new HashSet<char>(jewels);
            int sum = 0;
            foreach (char stone in stones)
            {
                if (jewelsSet.Contains(stone))
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}


public class BestRunTimeSolution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        int result = 0;
        foreach (char s in stones)
        {
            if (jewels.Contains(s)) result++;
        }
        return result;
    }
}

public class BestMemorySolution
{
    public int NumJewelsInStones2(string jewels, string stones)
    {
        return stones.Count(x => jewels.Contains(x));
    }
    public int NumJewelsInStones(string jewels, string stones)
    {

        int sum = 0;

        for (int i = 0; i < stones.Length; i++)
        {
            for (int j = 0; j < jewels.Length; j++)
            {
                if (stones[i] == jewels[j])
                {
                    sum++;
                }
            }
        }
        GC.Collect();
        return sum;
    }
}



