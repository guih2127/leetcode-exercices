using Common;

namespace Problems;

public class RotateArray
{
    private void Solution(int[] nums, int k)
    {
        // To solve this problem, we can think like that:
        // We need to have the last k % n elements on the beginning on the array
        // So, for that, we can revert the whole array one time. This way, the last elements (5,6,7)
        // will be the first ones (7,6,5), but in the wrong order.
        // Lastly, we can make two reverses to fix the ordering. First, for the first k % n elements, and second
        // for the remaining elements.
        var n = nums.Length;
        k %= n; // this avoid unnecessary rotations

        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }

    // The reverse function works with two pointers to reverse the array
    private static void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);
            start++;
            end--;
        }
    }

    public void ExecuteSolution()
    {
        var nums = new[]
        {
            1,2,3,4,5,6,7
        };
        var k = 3;
        Solution(nums, k);
        
        ArrayUtils.PrintArray(nums);
    }
}