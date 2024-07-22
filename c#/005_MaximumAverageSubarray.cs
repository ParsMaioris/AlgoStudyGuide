/**
 * Maximum Average Subarray I
 * Given an integer array `nums` consisting of `n` elements and an integer `k`, find a contiguous subarray whose length is equal to `k` that has the maximum average value and return this value.
 * 
 * Link to Original Problem: https://leetcode.com/problems/maximum-average-subarray-i/
 */
[TestClass]
public class FindMaxAverageTests
{
    public double FindMaxAverage(int[] nums, int k, int significantFigures = 2)
    {
        ValidateInput(nums, k);

        int maxSum = CalculateInitialSum(nums, k);
        int currentSum = maxSum;

        maxSum = CalculateMaxSum(nums, k, maxSum, currentSum);

        double average = (double)maxSum / k;
        return TruncateToSignificantFigures(average, significantFigures);
    }

    private static void ValidateInput(int[] nums, int k)
    {
        if (nums == null || nums.Length < k)
        {
            throw new ArgumentException("Array must not be null and must have at least k elements.");
        }
    }

    private static int CalculateInitialSum(int[] nums, int k)
    {
        int sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }
        return sum;
    }

    private static int CalculateMaxSum(int[] nums, int k, int maxSum, int currentSum)
    {
        for (int i = k; i < nums.Length; i++)
        {
            currentSum += nums[i] - nums[i - k];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
        return maxSum;
    }

    private static double TruncateToSignificantFigures(double value, int significantFigures)
    {
        int multiplier = (int)Math.Pow(10, significantFigures);
        return Math.Truncate(value * multiplier) / multiplier;
    }

    [TestMethod]
    public void FindMaxAverage_ShouldReturnCorrectAverage_ForPositiveAndNegativeNumbers()
    {
        var nums = new int[] { 1, 12, -5, -6, 50, 3 };
        var k = 4;
        var expected = 12.75;
        var result = FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void FindMaxAverage_ShouldReturnCorrectAverage_ForSingleElementArray()
    {
        var nums = new int[] { 5 };
        var k = 1;
        var expected = 5.0;
        var result = FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void FindMaxAverage_ShouldReturnCorrectAverage_ForAllPositiveNumbers()
    {
        var nums = new int[] { 4, 2, 1, 3, 3 };
        var k = 2;
        var expected = 3.0;
        var result = FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void FindMaxAverage_ShouldReturnCorrectAverage_ForAllNegativeNumbers()
    {
        var nums = new int[] { -3, -2, -1, -5, -6 };
        var k = 3;
        var expected = -2.0;
        var result = FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void FindMaxAverage_ShouldReturnCorrectAverage_ForMixedNumbers()
    {
        var nums = new int[] { 7, 5, 8, 9, -3, 6 };
        var k = 3;
        var expected = 7.33;
        var result = FindMaxAverage(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FindMaxAverage_ShouldThrowException_WhenArrayIsNull()
    {
        int[] nums = null;
        var k = 3;
        FindMaxAverage(nums, k);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FindMaxAverage_ShouldThrowException_WhenArrayLengthIsLessThanK()
    {
        var nums = new int[] { 1, 2 };
        var k = 3;
        FindMaxAverage(nums, k);
    }
}