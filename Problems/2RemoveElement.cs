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
    
    private int BadSolution(int[] nums, int val)
    {
        return 0;
    }
    
    public void ExecuteSolution()
    {
        var nums = new int[3]
        {
            7,9,12
        };
        
        const int val = 7;
        var expectedNums = new int[2];
        var k = BadSolution(nums, val);
        
        Console.WriteLine(k);
        ArrayUtils.PrintArray(expectedNums);
    }
}