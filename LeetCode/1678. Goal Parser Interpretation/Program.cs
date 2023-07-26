//You own a Goal Parser that can interpret a string command. The command consists of an alphabet of "G", "()" and/or "(al)" in some order. The Goal Parser will interpret "G" as the string "G", "()" as the string "o", and "(al)" as the string "al". The interpreted strings are then concatenated in the original order.

//Given the string command, return the Goal Parser's interpretation of command.
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        //var result = solution.Interpret("G()(al)");
        var result = solution.Interpret("G()()()()(al)");
        Console.WriteLine(result.ToString());

    }
}
public sealed class Solution
{
    public string Interpret(string command)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < command.Length; i++)
        {
            if (command[i] == 'G')
            {
                result.Append('G');
                continue;
            }
            else if (command[i + 1] == ')')
            {
                result.Append('o');
                i += 1;
                continue;
            }

            result.Append("al");
            i += 3;
        }


        GC.Collect();
        return result.ToString();
    }

    public string Interpretv2(string command)
    {
        return command.Replace("()", "o").Replace("(", "").Replace(")", "");
    }
}

public sealed class FastestSolution
{
    public string Interpret(string command)
    {
        StringBuilder builder = new();
        int position = 0;

        while (position < command.Length)
        {
            if (command[position] == 'G')
            {
                builder.Append("G");
                position++;
            }
            else if (command[position + 1] == 'a')
            {
                builder.Append("al");
                position = position + 4;
            }
            else
            {
                builder.Append("o");
                position = position + 2;
            }
        }

        return builder.ToString();
    }
}


public sealed class BestMemorySolution
{
    public string Interpret(string command)
    {
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < command.Length;)
        {
            if (command[i] == '(')
            {
                if (command[i + 1] == ')')
                {
                    s.Append('o');
                    i += 2;
                }
                else
                {
                    s.Append("al");
                    i += 4;
                }
            }
            else
            {
                s.Append("G");
                i++;
            }
        }
        return s.ToString();
    }

    public string Interpretv2(string command)
    {
        return command.Replace("()", "o").Replace("(al)", "al");
    }
}

