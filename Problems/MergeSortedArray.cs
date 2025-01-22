using BenchmarkDotNet.Attributes;

namespace Problems;

public class MergeSortedArray
{
    // You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
    // Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    // The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
    // To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored.
    // nums2 has a length of n.

    private static void GoodSolution(int[] nums1, int m, int[] nums2, int n)
    {
        
    }

    [Benchmark]
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
        
        PrintArray(nums1);
    }

    private static void PrintArray(int[] array)
    {
        foreach (var t in array)
        {
            Console.WriteLine(t);
        }
    }

    public void ExecuteSolution()
    {
        const int m = 3;
        const int n = 3;
        var nums1 = new int[m + n]
        {
            4,5,6,0,0,0
        };
        var nums2 = new int[n]
        {
            1,2,3
        };
        
        BadSolution(nums1, m, nums2, n);
    }
}