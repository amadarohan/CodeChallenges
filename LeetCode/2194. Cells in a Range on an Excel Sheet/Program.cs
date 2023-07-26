using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //var result = solution.CellsInRange("K1:L2");
        var result = solution.CellsInRange("A1:F1");
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public IList<string> CellsInRange(string s)
    {
        IList<string> result = new List<string>();
      
        var nums = int.Parse(s[1].ToString());
        var nume = int.Parse(s[4].ToString());
        for (char c = s[0]; c <= s[3]; c++)
        {
            for (int i = nums; i <= nume; i++)
            {
                result.Add(c.ToString() + i);
            }
        }

        return result;
    }
}

public sealed class FastestSolution
{
    public IList<string> CellsInRange(string s)
    {
        var range = s.Split(":");
        var startCol = Convert.ToChar(range[0].Substring(0, 1));
        var startRow = Convert.ToInt32(range[0].Substring(1));
        var endCol = Convert.ToChar(range[1].Substring(0, 1));
        var endRow = Convert.ToInt32(range[1].Substring(1));

        var output = new string[(endCol - startCol + 1) * (endRow - startRow + 1)];
        var sb = new StringBuilder();
        int index = 0;
        for (char col = startCol; col <= endCol; col++)
        {
            for (int row = startRow; row <= endRow; row++)
            {
                sb.Append(col).Append(row);
                output[index++] = sb.ToString();
                sb.Clear();
            }
        }
        return output;
    }

    public IList<string> CellsInRange2(string s)
    {
        List<string> cellsInRange = new();

        for (int j = 0; j <= s[3] - s[0]; j++)
        {
            for (int i = s[1] - '0'; i < s[4] - '/'; i++)
            {
                cellsInRange.Add($"{(char)(s[0] + j)}{i}");
            }
        }

        return cellsInRange;
    }

    public IList<string> CellsInRange3(string s)
    {

        byte[] ascii = Encoding.ASCII.GetBytes(s);
        List<string> resultList = new();

        int charlen = ascii[3] - ascii[0];

        for (int i = 0; i <= charlen; i++)
        {
            for (int j = 0; j <= s[4] - s[1]; j++)
            {
                resultList.Add($"{Convert.ToChar(ascii[0] + i)}{s[1] - 48 + j}");
            }
        }
        return resultList;
    }

}


public sealed class BestMemorySolution
{
    public IList<string> CellsInRange(string s)
    {
        var list = new char[] {'A', 'B', 'C', 'D', 'E', 'F','G', 'H', 'I', 'J',
        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        int f = s[1] - '0';
        int l = s[4] - '0';
        int firstIndex = Array.FindIndex<char>(list, x => x == s[0]);
        int lastIndex = Array.FindIndex<char>(list, x => x == s[3]);
        int counter = 0;
        var str = new string[(lastIndex - firstIndex + 1) * (l - f + 1)];
        for (int i = firstIndex; i < lastIndex + 1; i++)
        {
            for (int j = f; j < l + 1; j++)
            {
                str[counter++] = $"{list[i]}{j}";
            }
        }
        return str;
    }

    public IList<string> CellsInRange2(string s)
    {
        List<string> cellsInRange = new();

        for (int j = 0; j <= s[3] - s[0]; j++)
        {
            for (int i = s[1] - '0'; i < s[4] - '/'; i++)
            {
                cellsInRange.Add($"{(char)(s[0] + j)}{i}");
            }
        }

        return cellsInRange;
    }
}

