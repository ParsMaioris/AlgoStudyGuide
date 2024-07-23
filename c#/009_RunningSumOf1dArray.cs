/**
 * Running Sum of 1d Array
 * Given an array `nums`, we define a running sum of an array as `runningSum[i] = sum(nums[0]…nums[i])`.
 * 
 * Return the running sum of `nums`.
 * 
 * Link to Original Problem: https://leetcode.com/problems/running-sum-of-1d-array/
 */
[TestClass]
public class RunningSumTests
{
    public int[] RunningSum(int[] nums)
    {
        if (nums == null || nums.Length == 0) return new int[] { };

        int[] runningSum = new int[nums.Length];
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum = CalculateRunningSum(sum, nums[i]);
            runningSum[i] = sum;
        }

        return runningSum;
    }

    private int CalculateRunningSum(int currentSum, int num)
    {
        return currentSum + num;
    }

    [TestMethod]
    public void RunningSum_ShouldReturnRunningSumOfArray()
    {
        var nums = new[] { 1, 2, 3, 4 };
        var expected = new[] { 1, 3, 6, 10 };
        var result = RunningSum(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void RunningSum_ShouldReturnRunningSumOfArrayWithAllOnes()
    {
        var nums = new[] { 1, 1, 1, 1, 1 };
        var expected = new[] { 1, 2, 3, 4, 5 };
        var result = RunningSum(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void RunningSum_ShouldReturnRunningSumOfArrayWithMixedNumbers()
    {
        var nums = new[] { 3, 1, 2, 10, 1 };
        var expected = new[] { 3, 4, 6, 16, 17 };
        var result = RunningSum(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void RunningSum_ShouldReturnEmptyArrayForEmptyInput()
    {
        var nums = new int[] { };
        var expected = new int[] { };
        var result = RunningSum(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void RunningSum_ShouldReturnRunningSumForSingleElementArray()
    {
        var nums = new[] { 5 };
        var expected = new[] { 5 };
        var result = RunningSum(nums);
        CollectionAssert.AreEqual(expected, result);
    }
}