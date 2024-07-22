/**
 * Two Sum
 * Given an array of integers `nums` and an integer `target`, find two numbers such that they add up to `target`.
 * Return the indices of the two numbers.
 * 
 * Link to Original Problem: https://leetcode.com/problems/two-sum/
 */
[TestClass]
public class TwoSumTests
{
    public int[] TwoSum(int[] nums, int target)
    {
        var numToIndex = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = CalculateComplement(target, nums[i]);

            if (numToIndex.ContainsKey(complement))
            {
                return new int[] { numToIndex[complement], i };
            }

            AddNumberToDictionary(numToIndex, nums[i], i);
        }

        throw new ArgumentException("No two sum solution");
    }

    private int CalculateComplement(int target, int num)
    {
        return target - num;
    }

    private void AddNumberToDictionary(Dictionary<int, int> dictionary, int num, int index)
    {
        dictionary[num] = index;
    }

    [TestMethod]
    public void TwoSum_ShouldReturnIndicesForTargetSum()
    {
        var nums = new[] { 2, 7, 11, 15 };
        var target = 9;
        var expected = new[] { 0, 1 };
        var result = TwoSum(nums, target);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TwoSum_ShouldReturnIndicesForAnotherTargetSum()
    {
        var nums = new[] { 3, 2, 4 };
        var target = 6;
        var expected = new[] { 1, 2 };
        var result = TwoSum(nums, target);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TwoSum_ShouldReturnIndicesForIdenticalElements()
    {
        var nums = new[] { 3, 3 };
        var target = 6;
        var expected = new[] { 0, 1 };
        var result = TwoSum(nums, target);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TwoSum_ShouldThrowExceptionWhenNoSolution()
    {
        var nums = new[] { 1, 2, 3 };
        var target = 7;
        TwoSum(nums, target);
    }

    [TestMethod]
    public void TwoSum_ShouldHandleNegativeNumbers()
    {
        var nums = new[] { -1, -2, -3, -4, -5 };
        var target = -8;
        var expected = new[] { 2, 4 };
        var result = TwoSum(nums, target);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TwoSum_ShouldHandleLargeNumbers()
    {
        var nums = new[] { int.MaxValue, int.MinValue, -1, 1 };
        var target = 0;
        var expected = new[] { 2, 3 };
        var result = TwoSum(nums, target);
        CollectionAssert.AreEqual(expected, result);
    }
}