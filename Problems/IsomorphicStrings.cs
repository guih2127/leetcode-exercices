using Common;

namespace Problems;

public class IsomorphicStrings
{
    private bool Solution(string s, string t)
    {
        var stringsLength = s.Length;
        var firstOccurrencesDictionary = new Dictionary<char, int>();
        var firstOccurrencesArray = new int[stringsLength];
        var secondOccurrencesDictionary = new Dictionary<char, int>();
        var secondOccurrencesArray = new int[stringsLength];
        
        for (var i = 0; i < stringsLength; i++)
        {
            if (!firstOccurrencesDictionary.ContainsKey(s[i]))
            {
                firstOccurrencesDictionary[s[i]] = i;
            }
            
            if (!secondOccurrencesDictionary.ContainsKey(t[i]))
            {
                secondOccurrencesDictionary[t[i]] = i;
            }
        }

        for (var j = 0; j < stringsLength; j++)
        {
            firstOccurrencesArray[j] = firstOccurrencesDictionary[s[j]];
            secondOccurrencesArray[j] = secondOccurrencesDictionary[t[j]];
        }

        for (var k = 0; k < stringsLength; k++)
        {
            if (firstOccurrencesArray[k] != secondOccurrencesArray[k])
                return false;
        }

        return true;
    }

    public void ExecuteSolution()
    {
        const string s = "aab";
        const string t = "bba";
        Console.WriteLine(Solution(s, t));
    }
}