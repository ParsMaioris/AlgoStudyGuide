/**
 * Minimum Value to Get Positive Step by Step Sum
 * Given an array of integers `nums`, find the minimum initial value `startValue` such that the running total 
 * (sum of `startValue` plus elements in `nums` from left to right) is always at least 1.
 * 
 * Link to Original Problem: https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
 */
[TestClass]
public class MinStartValueTests
{
    public int MinStartValue(int[] nums)
    {
        int minSum = 0;
        int currentSum = 0;

        foreach (int num in nums)
        {
            currentSum = UpdateCurrentSum(currentSum, num);
            minSum = UpdateMinSum(minSum, currentSum);
        }

        return CalculateMinStartValue(minSum);
    }

    private int UpdateCurrentSum(int currentSum, int num)
    {
        return currentSum + num;
    }

    private int UpdateMinSum(int minSum, int currentSum)
    {
        return Math.Min(minSum, currentSum);
    }

    private int CalculateMinStartValue(int minSum)
    {
        return 1 - minSum;
    }

    [TestMethod]
    public void MinStartValue_ShouldReturnMinStartValueForNegativeAndPositiveNumbers()
    {
        var nums = new[] { -3, 2, -3, 4, 2 };
        var expected = 5;
        var result = MinStartValue(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MinStartValue_ShouldReturnMinStartValueForAllPositiveNumbers()
    {
        var nums = new[] { 1, 2 };
        var expected = 1;
        var result = MinStartValue(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MinStartValue_ShouldReturnMinStartValueForMixedNumbers()
    {
        var nums = new[] { 1, -2, -3 };
        var expected = 5;
        var result = MinStartValue(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MinStartValue_ShouldReturnMinStartValueForSingleElementArray()
    {
        var nums = new[] { -1 };
        var expected = 2;
        var result = MinStartValue(nums);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void MinStartValue_ShouldReturnMinStartValueForEmptyArray()
    {
        var nums = new int[] { };
        var expected = 1;
        var result = MinStartValue(nums);
        Assert.AreEqual(expected, result);
    }
}