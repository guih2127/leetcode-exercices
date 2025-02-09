namespace Problems.HashMap;

// Given two strings ransomNote and magazine,
// return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
// Each letter in magazine can only be used once in ransomNote.
public class RansomNote
{
    private bool Solution(string ransomNote, string magazine)
    {
        
    }
    
    private void ExecuteSolution(Func<string, string, bool> solution)
    {
        var ransomNote = "a";
        var magazine = "b";
        
        Console.WriteLine(solution(ransomNote, magazine));
    }
    
    private
    
    public void ExecuteBadSolution()
    {
        ExecuteSolution(BadSolution);
    }
}