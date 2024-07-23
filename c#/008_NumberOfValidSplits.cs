/**
 * Number of Valid Splits
 * Given a 0-indexed integer array `nums` of length `n`, return the number of valid splits in `nums`.
 * 
 * nums contains a valid split at index i if the following are true:
 * 1. The sum of the first i + 1 elements is greater than or equal to the sum of the last n - i - 1 elements.
 * 2. There is at least one element to the right of i. That is, 0 <= i < n - 1.
 * 
 * Link to Original Problem: https://leetcode.com/problems/number-of-ways-to-split-array
 */
[TestClass]
public class ValidSplitsTests
{
    public int CountValidSplits(int[] nums)
    {
        if (nums == null || nums.Length < 2) return 0;

        int totalSum = CalculateTotalSum(nums);
        int leftSum = 0;
        int validSplits = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            leftSum += nums[i];
            int rightSum = totalSum - leftSum;

            if (IsValidSplit(leftSum, rightSum))
            {
                validSplits++;
            }
        }

        return validSplits;
    }

    private int CalculateTotalSum(int[] nums)
    {
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        return sum;
    }

    private bool IsValidSplit(int leftSum, int rightSum)
    {
        return leftSum >= rightSum;
    }

    [TestMethod]
    public void CountValidSplits_ShouldReturnNumberOfValidSplits()
    {
        var nums = new[] { 10, 4, -8, 7 };
        var expected = 2;
        var result = CountValidSplits(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CountValidSplits_ShouldReturnNumberOfValidSplitsForAnotherArray()
    {
        var nums = new[] { 2, 3, 1, 0 };
        var expected = 2;
        var result = CountValidSplits(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CountValidSplits_ShouldReturnOneValidSplitForIncreasingArray()
    {
        var nums = new[] { 1, 2, 3, 4, 5 };
        var expected = 1;
        var result = CountValidSplits(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CountValidSplits_ShouldReturnZeroForArrayWithLessThanTwoElements()
    {
        var nums = new[] { 1 };
        var expected = 0;
        var result = CountValidSplits(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CountValidSplits_ShouldReturnZeroForEmptyArray()
    {
        var nums = new int[] { };
        var expected = 0;
        var result = CountValidSplits(nums);
        Assert.AreEqual(expected, result);
    }
}