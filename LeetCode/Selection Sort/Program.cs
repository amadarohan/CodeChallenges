//Sorting Big O Notation
//               Best   Average  Space

//Selection Sort O(n^2) O(n^2)   O(1)

//Selection sort is a simple sorting algorithm that sorts an array by repeatedly finding the minimum element from the unsorted part of the array and putting it at the beginning. The algorithm maintains two subarrays in a given array. One subarray is already sorted and the other subarray is unsorted. In every iteration of selection sort, the minimum element from the unsorted subarray is picked and moved to the sorted subarray.
//for more detailed info:
//https://code-maze.com/csharp-selection-sort/
class Program
{
    static void Main(string[] args)
    {
        SelectionSort solution = new SelectionSort();
        int[] testCase = new int[] { 2, 1, 5, 9, 7, 4, 6,8, 3, 0 };
        int[] result = solution.Sort(testCase);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
public sealed class SelectionSort
{
    public int[] Sort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            var min = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min]) {
                    min = j;
                }
            }

            if (min != i) {
                //var temp = array[i];
                //array[i] = array[min];
                //array[min] = temp;
                
                array[i] = array[min] + array[i];
                array[min] = array[i] - array[min];
                array[i] = array[i] - array[min];
            }
        }
        
        return array;
    }
}
