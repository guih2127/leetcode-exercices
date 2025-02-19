using BenchmarkDotNet.Attributes;
using Common;

namespace Problems;

public class ClosestSameCharacter
{
    // Given a string that might have multiple occurrences of the same character,
    // return the closest same character of any indicated character in the string.
    // You are given the string s and n number of queries. In each query, you are given an index a (where 0 <= a < |s|) of a character,
    // and you need to print the index of the closest same character.
    // If there are multiple answers, print the smallest one, or if there is no such index print -1 instead.

    // For example, for the string s = babab, with a given query 2, there are two matching characters at indices 0 and 4,
    // each 2 away, so we choose the lower of the two: 0

    private static List<int> GoodSolution(string s, List<int> queries)
    {
        var n = s.Length;
        var left = new int[n];
        var right = new int[n];
        
        var lastSeenLeft = new Dictionary<char, int>();
        for (var i = 0; i < n; i++)
        {
            left[i] = lastSeenLeft.GetValueOrDefault(s[i], -1);
            lastSeenLeft[s[i]] = i;
        }

        var lastSeenRight = new Dictionary<char, int>();
        for (var i = n - 1; i >= 0; i--)
        {
            right[i] = lastSeenRight.GetValueOrDefault(s[i], -1);
            lastSeenRight[s[i]] = i;
        }

        var results = new List<int>();
        foreach (var a in queries)
        {
            var nearestIndex = -1;
            if (left[a] != -1 && right[a] != -1)
                nearestIndex = Math.Abs(left[a] - a) <= Math.Abs(right[a] - a) ? left[a] : right[a];
            else if (left[a] != -1)
                nearestIndex = left[a];
            else if (right[a] != -1)
                nearestIndex = right[a];

            results.Add(nearestIndex);
        }

        return results;
    }

    private static List<int> BadSolution(string s, List<int> queries)
    {
        var results = new List<int>();

        foreach (var number in queries)
        {
            var nearestIndex = -1;
            var pointer1 = number - 1;
            var pointer2 = number + 1;

            while ((pointer1 >= 0 || pointer2 <= s.Length - 1) && nearestIndex == -1)
            {
                if (pointer1 >= 0 && s[number] == s[pointer1])
                {
                    nearestIndex = pointer1;
                }
                if (pointer2 <= s.Length - 1 && s[number] == s[pointer2])
                {
                    nearestIndex = nearestIndex is not -1 ? Math.Min(pointer1, pointer2) : pointer2;
                }
                
                if (pointer1 >= 0)
                    pointer1--;
                if (pointer2 <= s.Length - 1)
                    pointer2++;
            }
            
            results.Add(nearestIndex);
        }
        
        return results;
    }
    
    private void ExecuteSolution(Func<string, List<int>, List<int>> solution)
    {
        var s = "hackerrank";
        var queries = new List<int>()
        {
            4,1,6,8
        };
        
        var result = solution(s, queries);
        
        Console.WriteLine(String.Join(", ", result));
    }
    
    [Benchmark]
    public void ExecuteSolution()
    {
        ExecuteSolution(GoodSolution);
    }
}