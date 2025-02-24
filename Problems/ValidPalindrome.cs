using Common;

namespace Problems;

public class ValidPalindrome
{
    private bool BestSolution(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left])) left++; 
            while (left < right && !char.IsLetterOrDigit(s[right])) right--; 

            if (char.ToLower(s[left]) != char.ToLower(s[right])) 
                return false;

            left++;
            right--;
        }

        return true;
    }
    
    private bool Solution(string s)
    {
        var stringDictionary = new Dictionary<int, char>();
        var stringInvertedDictionary = new Dictionary<int, char>();

        var dictionaryLastIndex = 0;
        var invertedDictionaryLastIndex = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsLetterOrDigit(s[i]))
            {
                stringDictionary.Add(dictionaryLastIndex, char.ToLower(s[i]));
                dictionaryLastIndex++;
            }

            if (char.IsLetterOrDigit(s[i]))
            {
                stringInvertedDictionary.Add(invertedDictionaryLastIndex, char.ToLower(s[s.Length - 1 - i]));
                invertedDictionaryLastIndex++;
            }
        }

        for (var j = 0; j < stringDictionary.Count; j++)
        {
            if (stringDictionary[j] != stringInvertedDictionary[j])
                return false;
        }
        
        return true;
    }
    
    public void ExecuteSolution()
    {
        const string s = "A man, a plan, a canal: Panama";
        Console.WriteLine(Solution(s));
    }
}