using System.Collections;

namespace Problems.HashMap;

public class MajorityElement
{
    // Given an array nums of size n, return the majority element.
    // The majority element is the element that appears more than ⌊n / 2⌋ times.
    // You may assume that the majority element always exists in the array.

    private int BadSolution(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var elementCount = 0;
            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    elementCount++;
                    if (elementCount > nums.Length / 2)
                    {
                        return nums[i];
                    }
                }
            }
        }

        return nums[0];
    }

    private int AverageSolution(int[] nums)
    {
        var hashTable = new Dictionary<int, int>();

        foreach (var t in nums)
        {
            if (!hashTable.TryAdd(t, 1))
            {
                hashTable[t]++;
                if (hashTable[t] > nums.Length / 2)
                {
                    return t;
                }
            }
        }

        return nums[0];
    }

    // BOYER-MOORE ALGORITHM
    // The majority element is an element that appears more than nums.length / 2 times on the array.
    // As that's the case, we can create two variables, a count and a candidate, and always increase
    // or decrease the count, depending on the numbers of the iteration
    // O(n) time and O(1) space complexity
    
    private int GoodSolution(int[] nums)
    {
        var candidate = 0;
        var count = 0;

        foreach (var num in nums)
        {
            if (count == 0)
                candidate = num;

            if (num == candidate)
                count++;
            else
                count--;
        }

        return candidate;
    }
    
    private void ExecuteSolution(Func<int[], int> solution)
    {
        var nums = new[]
        {
            2,2,1,1,1,2,2
        };
        
        Console.WriteLine(solution(nums));
    }
    
    public void ExecuteBadSolution()
    {
        ExecuteSolution(BadSolution);
    }
    
    public void ExecuteAverageSolution()
    {
        ExecuteSolution(AverageSolution);
    }
    
    public void ExecuteGoodSolution()
    {
        ExecuteSolution(GoodSolution);
    }
}