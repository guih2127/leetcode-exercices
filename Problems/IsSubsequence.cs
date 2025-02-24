namespace Problems;

public class IsSubsequence
{
    // Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
    // A subsequence of a string is a new string that is formed from the
    // original string by deleting some (can be none) of the characters without disturbing the relative positions
    // of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
    
    private bool Solution(string s, string t)
    {
        var i = 0;

        if (s.Length == 0)
        {
            return true;
        }
        
        for (var j = 0; j < t.Length; j++)
        {
            if (s[i] == t[j])
            {
                if (i == s.Length - 1)
                {
                    return true;
                }
                i++;
            }
        }

        return false;
    }
    
    public void ExecuteSolution()
    {
        const string s = "b";
        const string t = "abc";
        Console.WriteLine(Solution(s, t));
    }
}