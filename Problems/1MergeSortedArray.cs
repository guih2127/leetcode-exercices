using BenchmarkDotNet.Attributes;
using Common;

namespace Problems;

public class MergeSortedArray
{
    // You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
    // Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    // The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
    // To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored.
    // nums2 has a length of n.
    
    // This algorithm is O(m+n), because now we don't have aligned loops. The number of operations will increase directly with the increase of the number of entries.
    private static void GoodSolution(int[] nums1, int m, int[] nums2, int n)
    {
        // FIRST STEP -> Create 3 pointers, 1 on the end of the first array (but before the number zeros), one on the end of the second array, and one and the
        // end of the first array, but including the number zeros.
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;

        // SECOND STEP -> Loop until one of the pointers gets to 0. We compare the last numbers of each array and put the higher one on the nums1 array.
        // We also decrease the pointer for the array that has the higher number, because this number is element is already on the end of the nums1 array.
        // On each iteration we compare the last elements of the two arrays, that were not inserted yet, making it possible to insert the higher elements
        // on the end of the array.
        // It's necessary to decrease the last pointer at the end of the loop. This is because we need to tell that the last element of the array
        // was filled with the highest number.
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }
        
        // THIRD STEP -> If there are still elements on the number 2 array, we need to put them on the on the nums1 array as well.
        // This loop can or not be entered.
        // If the code enter this loop, it means that all the nums1 items are already positioned correctly on the array, so we just
        // need to position the num2 arrays now. As they are already ordered, it's just a matter of putting them on the array.
        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }
    
    private static void BadSolution(int[] nums1, int m, int[] nums2, int n)
    {
        if (nums2.Length == 0)
        {
            return;
        };
        
        for (var i = 0; i < n; i++)
        {
            nums1[i + m] = nums2[i];
        }
        
        for (var i = 0; i < m + n; i++)
        {
            for (var j = i + 1; j < m + n; j++)
            {
                var firstElement = nums1[i];
                var secondElement = nums1[j];
                if (nums1[i] > nums1[j])
                { 
                    nums1[i] = secondElement;
                    nums1[j] = firstElement;
                }
            }
        }
    }
    
    private void ExecuteSolution(Action<int[], int, int[], int> solution)
    {
        const int m = 3;
        const int n = 3;
        var nums1 = new int[m + n]
        {
            7,9,12,0,0,0
        };
        var nums2 = new int[n]
        {
            11,15,20
        };
        
        solution(nums1, m, nums2, n);
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