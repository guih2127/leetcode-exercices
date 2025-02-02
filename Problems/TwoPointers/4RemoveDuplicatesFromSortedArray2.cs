using BenchmarkDotNet.Attributes;
using Common;

namespace Problems.TwoPointers;

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
        // If array has just two elements we dont need to change anything.
        if (nums.Length <= 2) return nums.Length;
        
        // We create two pointers, one named slow and other named fast.
        // We start from the 3 element, because there is no need to changed the first two elements, never.
        var slow = 2;
        for (var fast = 2; fast < nums.Length; fast++)
        {
            // Pointer fast will always be increased, so it will be 2, 3, 4, etc...
            // Second pointer only increases if nums[fast] is different than nums[slow -2]
            // As long as the values are different, we always compare the element on fast with the element of slow - 1.
            // As long as the values are different, the array doesnt change, because fast and slow are the same.
            // If an element[fast] is equal to elements[slow-2], it means we have 3 repeated elements on the array.
            // On this case, we dont increase the slow counter, to keep track of the number that needs to be changed.
            // When we find the first equality, we get the first difference between fast and slow, and with the below
            // attribution, we always move back the elements from the array.
            // Slow is always increased when the numbers are different, so it's safe to return it on the end of the function.
            if (nums[fast] != nums[slow - 2])
            {
                nums[slow] = nums[fast];
                slow++;
            }
        }

        return slow;
    }
    
    [Benchmark]
    private void ExecuteSolution(Func<int[], int> solution)
    {
        var nums = new[]
        {
            1,1,1,2,2,2,3,3
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