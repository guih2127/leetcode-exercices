using BenchmarkDotNet.Attributes;
using Common;

namespace Problems;

public class RemoveDuplicatesFromSortedArray 
{
    // Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once.
    // The relative order of the elements should be kept the same. Then return the number of unique elements in nums.
    // Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:
    // Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially.
    // The remaining elements of nums are not important as well as the size of nums.
    // Return k.

    private int GoodSolution(int[] nums)
    {
        var i = 0;

        for (var j = 1; j < nums.Length; j++)
        {
            if (nums[i] != nums[j])
            {
                i++;
                nums[i] = nums[j];
            }
        }
        
        return i + 1;
    }
    
    [Benchmark]
    private void ExecuteSolution(Func<int[], int> solution)
    {
        var nums = new[]
        {
            1,1,2
        };

        var k = solution(nums);
        
        Console.WriteLine(k);
    }
    
    [Benchmark]
    public void ExecuteGoodSolution()
    {
        ExecuteSolution(GoodSolution);
    }
}