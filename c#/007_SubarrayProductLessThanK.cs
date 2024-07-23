/**
 * Subarray Product Less Than K
 * Given an array of integers `nums` and an integer `k`, return the number of contiguous subarrays where the 
 * product of all the elements in the subarray is strictly less than `k`.
 * 
 * Link to Original Problem: https://leetcode.com/problems/subarray-product-less-than-k/
 */
[TestClass]
public class SubarrayProductLessThanKTests
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;

        int left = 0;
        int product = 1;
        int count = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            product *= nums[right];

            while (product >= k)
            {
                product /= nums[left];
                left++;
            }

            count += right - left + 1;
        }

        return count;
    }

    [TestMethod]
    public void NumSubarrayProductLessThanK_ShouldReturnCountForValidSubarrays()
    {
        var nums = new[] { 10, 5, 2, 6 };
        var k = 100;
        var expected = 8;
        var result = NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void NumSubarrayProductLessThanK_ShouldReturnZeroWhenKIsLessThanOrEqualToOne()
    {
        var nums = new[] { 1, 2, 3 };
        var k = 0;
        var expected = 0;
        var result = NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void NumSubarrayProductLessThanK_ShouldReturnCountWhenAllElementsLessThanK()
    {
        var nums = new[] { 1, 2, 3, 4 };
        var k = 10;
        var expected = 7;
        var result = NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void NumSubarrayProductLessThanK_ShouldReturnCountWhenAllElementsAreGreaterThanK()
    {
        var nums = new[] { 10, 20, 30 };
        var k = 5;
        var expected = 0;
        var result = NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void NumSubarrayProductLessThanK_ShouldReturnCountWhenKIsLarge()
    {
        var nums = new[] { 1, 1, 1, 1 };
        var k = 100;
        var expected = 10;
        var result = NumSubarrayProductLessThanK(nums, k);
        Assert.AreEqual(expected, result);
    }
}