static void Main(string[] args)
{
    MySolution solution = new MySolution();
    bool result = solution.IsPalindrome(121);
    Console.WriteLine(result);
}

public class MySolution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;
        if (x > 0 && x < 10)
            return true;

        var reversed = ReverseIt(x);

        if(x==reversed)
            return true;
        else
            return false;
    }
    private int ReverseIt(int x)
    {
        int temp = x;
        int rev = 0, digit = 0;
        while (temp > 0)
        {
            digit = temp % 10;
            rev = rev * 10 + digit;
            temp = temp / 10;
        }
        return rev;
    }
}

public class BestSolution
{
    public bool IsPalindrome(int x)
    {
        int r = 0, c = x;
        while (c > 0)
        {
            r = r * 10 + c % 10;
            c /= 10;
        }
        return r == x;
    }
}



