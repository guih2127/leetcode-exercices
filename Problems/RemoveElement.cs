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
        // FIRST STEP -> Create the first pointer
        var firstPointer = 0;

        // SECOND STEP -> Create a loop to iterate the array, creating the second pointer
        // As the first pointer increases ONLY if the element is different than val, the second pointer will NEVER be besides
        // the first pointer. The two pointers will be positioned on the same place until an element of the array is equal to val.
        // When this happens, the second pointer gets ahead of the first one. We can say that the second pointer is 1 place ahead the first one
        // for each occurence of val.
        // For the last, if the element is different than val, we change the value of the element on the first pointer to the element
        // on the second pointer. With that, we put the numbers different than val at the beginning of the array. We don't care about the 
        // last values. We just want the elements different than val to be at the beginning.
        for (var secondPointer = 0; secondPointer < nums.Length; secondPointer++)
        {
            if (nums[secondPointer] != val)
            {
                nums[firstPointer] = nums[secondPointer];
                firstPointer++;
            }
        }

        // THIRD STEP -> Return the first pointer
        return firstPointer;
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
            3,2,2,3
        };

        const int val = 2;
        var k = solution(nums, val);
        
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