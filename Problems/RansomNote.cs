namespace Problems;

// Given two strings ransomNote and magazine,
// return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
// Each letter in magazine can only be used once in ransomNote.
public class RansomNote
{
    private bool BadSolution(string ransomNote, string magazine)
    {
        var magazineArray = magazine.ToCharArray();
        var ransomNoteArray = ransomNote.ToCharArray();
        var hashTable = new Dictionary<char, int>();

        foreach (var t in magazineArray)
        {
            if (!hashTable.TryAdd(t, 1))
            {
                hashTable[t]++;
            }
        }
        Console.WriteLine(String.Join(", ", hashTable));
        
        foreach (var t in ransomNoteArray)
        {
            if (hashTable.ContainsKey(t))
            {
                hashTable[t]--;
                if (hashTable[t] < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
    
    private void ExecuteSolution(Func<string, string, bool> solution)
    {
        var ransomNote = "aa";
        var magazine = "aab";
        
        Console.WriteLine(solution(ransomNote, magazine));
    }
    
    public void ExecuteBadSolution()
    {
        ExecuteSolution(BadSolution);
    }
}