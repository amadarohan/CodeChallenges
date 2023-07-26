//Sorting Big O Notation
//               Best   Average  Space

//Insertion Sort O(n)   O(n^2)   O(1)

//Insertion sort is a sorting algorithm that places an unsorted element at its suitable place in each iteration. Insertion sort works similarly as we sort cards in our hand in a card game. We assume that the first card is already sorted then, we select an unsorted card.
//for more detailed info:
//https://code-maze.com/insertion-sort-csharp/

class Program
{
    static void Main(string[] args)
    {
        InsertionSort solution = new InsertionSort();
        int[] testCase = new int[] { 2, 1, 5, 9, 7, 4, 6, 8, 3, 0 };
        int[] result = solution.Sort(testCase);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
public sealed class InsertionSort
{
    public int[] Sort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        for (int i = 1; i < array.Length; i++)
        {
            var targetValue = array[i];
            int j = i - 1;
            for (; j>=0 && array[j] > targetValue; j--)
            {
                array[j+1] = array[j];
            }
            array[j + 1] = targetValue;
        }

        return array;
    }

    public int[] SortArray(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }

        for (int i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var flag = 0;

            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = key;
                }
                else flag = 1;
            }
        }

        return array;
    }

}
