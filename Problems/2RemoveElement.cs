using BenchmarkDotNet.Attributes;
using Common;

namespace Problems;

public class RemoveElement
{
    // Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed.
    // Then return the number of elements in nums which are not equal to val.
    // Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
    // Change the array nums such that the first k elements of nums contain the elements which are not equal to val.
    // The remaining elements of nums are not important as well as the size of nums.
    // Return k.

    private int GoodSolution(int[] nums, int val)
    {
        var notValOccurrences = 0;
        var firstPointer = 0;
        var secondPointer = nums.Length - 1;
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                notValOccurrences++;   
            }
        }
        
        while (secondPointer > firstPointer)
        {
            if (nums[firstPointer] == val)
            {
                if (nums[secondPointer] != val)
                {
                    nums[firstPointer] = nums[secondPointer];
                    nums[secondPointer] = val;
                
                    firstPointer++;
                    secondPointer--;
                }
                else
                {
                    secondPointer--;
                }
            }
            else
            {
                firstPointer++;
            }
        }

        return notValOccurrences;
    }
    
    private int BadSolution(int[] nums, int val)
    {
        var notValOccurrences = 0;
        var firstPointer = 0;
        var secondPointer = nums.Length - 1;
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                notValOccurrences++;   
            }
        }
        
        while (secondPointer > firstPointer)
        {
            if (nums[firstPointer] == val)
            {
                if (nums[secondPointer] != val)
                {
                    nums[firstPointer] = nums[secondPointer];
                    nums[secondPointer] = val;
                
                    firstPointer++;
                    secondPointer--;
                }
                else
                {
                    secondPointer--;
                }
            }
            else
            {
                firstPointer++;
            }
        }

        return notValOccurrences;
    }
    
    [Benchmark]
    private void ExecuteSolution(Func<int[], int, int> solution)
    {
        var nums = new[]
        {
            0,1,2,2,3,0,4,2
        };

        const int val = 2;
        var k = BadSolution(nums, val);
        
        Console.WriteLine(k);
        ArrayUtils.PrintArray(nums);
    }
    
    [Benchmark]
    public void ExecuteGoodSolution()
    {
        ExecuteSolution(GoodSolution);
    }
    
    [Benchmark]
    public void ExecuteBadSolution()
    {
        ExecuteSolution(BadSolution);
    }
}