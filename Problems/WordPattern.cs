using Common;

namespace Problems;

public class WordPattern
{ 
    // Given a pattern and a string s, find if s follows the same pattern.
    // Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s. Specifically:
    // Each letter in pattern maps to exactly one unique word in s.
    // Each unique word in s maps to exactly one letter in pattern.
    // No two letters map to the same word, and no two words map to the same letter.
    
    private bool Solution(string pattern, string s)
    {
        var stringArray = s.Split(" ");
        if (stringArray.Length != pattern.Length)
            return false;
        
        var patternFirstOccurrencesDictionary = new Dictionary<char, int>();
        var patternFirstOccurrences = new int[pattern.Length];
        
        var stringFirstOccurrencesDictionary = new Dictionary<string, int>();
        var stringFirstOccurrences = new int[pattern.Length];
        
        for (var i = 0; i < pattern.Length; i++)
        {
            if (!patternFirstOccurrencesDictionary.ContainsKey(pattern[i]))
                patternFirstOccurrencesDictionary[pattern[i]] = i;

            if (!stringFirstOccurrencesDictionary.ContainsKey(stringArray[i]))
                stringFirstOccurrencesDictionary[stringArray[i]] = i;
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            patternFirstOccurrences[i] = patternFirstOccurrencesDictionary[pattern[i]];
            stringFirstOccurrences[i] = stringFirstOccurrencesDictionary[stringArray[i]];
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            if (stringFirstOccurrences[i] != patternFirstOccurrences[i])
                return false;
        }
        
        return true;
    }
    
    public void ExecuteSolution()
    {
        const string pattern = "abba";
        const string s = "dog cat cat dog";
        Console.WriteLine(Solution(pattern, s));
    }
}