using BenchmarkDotNet.Attributes;
using Common;

namespace Problems;

public class RemoveDuplicatesFromSortedArray2
{
    // Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice.
    // The relative order of the elements should be kept the same.
    // Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.
    // More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.
    // It does not matter what you leave beyond the first k elements.
    // Return k after placing the final result in the first k slots of nums.
    // Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    
    private int Solution(int[] nums)
    {
        if (nums.Length <= 2) return nums.Length;
        
        var firstPointer = 2;

        for (var secondPointer = 2; secondPointer < nums.Length; secondPointer++)
        {
            if (nums[secondPointer] != nums[firstPointer - 2])
            {
                nums[firstPointer] = nums[secondPointer];
                firstPointer++;
            }
        }

        return firstPointer;
    }
    
    [Benchmark]
    private void ExecuteSolution(Func<int[], int> solution)
    {
        var nums = new[]
        {
            1,1,1,2,2,3
        };

        var k = solution(nums);
        Console.WriteLine(k);
        ArrayUtils.PrintArray(nums);
    }
    
    [Benchmark]
    public void ExecuteSolution()
    {
        ExecuteSolution(Solution);
    }
}