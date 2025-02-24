using Common;

namespace Problems;

public class ValidAnagram
{
    // Given two strings s and t, return true if t is an anagram of s, and false otherwise.
    private bool Solution(string s, string t)
    {
        if (s.Length != t.Length) 
            return false;

        var charOccurrencesFirstString = new Dictionary<char, int>();
        var charOccurrencesSecondString = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (!charOccurrencesFirstString.ContainsKey(s[i]))
                charOccurrencesFirstString[s[i]] = 1;
            else
                charOccurrencesFirstString[s[i]]++;
            
            if (!charOccurrencesSecondString.ContainsKey(t[i]))
                charOccurrencesSecondString[t[i]] = 1;
            else
                charOccurrencesSecondString[t[i]]++;
        }

        foreach (var t1 in s)
        {
            if (!charOccurrencesSecondString.ContainsKey(t1))
                return false;
            
            if (charOccurrencesFirstString[t1] != charOccurrencesSecondString[t1])
                return false;
        }
        
        return true;
    }
    
    public void ExecuteSolution()
    {
        const string s = "rat";
        const string t = "car";
        Console.WriteLine(Solution(s, t));
    }
}