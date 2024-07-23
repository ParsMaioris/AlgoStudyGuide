/**
 * Max Consecutive Ones III
 * Given a binary array `nums` and an integer `k`, return the maximum number of 
 * consecutive 1's in the array if you can flip at most `k` 0's.
 * 
 * Link to Original Problem: https://leetcode.com/problems/max-consecutive-ones-iii/
 */
[TestClass]
public class MaxConsecutiveOnesIIITests
{
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0, right = 0, zeroCount = 0, maxLength = 0;

        while (right < nums.Length)
        {
            if (IsZero(nums[right]))
            {
                zeroCount++;
            }

            while (zeroCount > k)
            {
                if (IsZero(nums[left]))
                {
                    zeroCount--;
                }
                left++;
            }

            maxLength = UpdateMaxLength(maxLength, right - left + 1);
            right++;
        }

        return maxLength;
    }

    private bool IsZero(int num)
    {
        return num == 0;
    }

    private int UpdateMaxLength(int currentMaxLength, int newLength)
    {
        return Math.Max(currentMaxLength, newLength);
    }

    [TestMethod]
    public void LongestOnes_ShouldReturnMaxConsecutiveOnes_WhenZerosCanBeFlipped()
    {
        var nums = new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
        var k = 2;
        var expected = 6;
        var result = LongestOnes(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LongestOnes_ShouldReturnMaxConsecutiveOnes_WhenNoZerosCanBeFlipped()
    {
        var nums = new[] { 0, 0, 1, 1, 1, 0, 0 };
        var k = 0;
        var expected = 3;
        var result = LongestOnes(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LongestOnes_ShouldReturnMaxConsecutiveOnes_WhenSomeZerosCanBeFlipped()
    {
        var nums = new[] { 0, 0, 1, 1, 1, 0, 0, 1, 1, 1 };
        var k = 2;
        var expected = 8;
        var result = LongestOnes(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LongestOnes_ShouldReturnArrayLength_WhenAllOnes()
    {
        var nums = new[] { 1, 1, 1, 1, 1 };
        var k = 0;
        var expected = 5;
        var result = LongestOnes(nums, k);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void LongestOnes_ShouldReturnArrayLength_WhenAllZerosAndKEqualsArrayLength()
    {
        var nums = new[] { 0, 0, 0, 0, 0 };
        var k = 5;
        var expected = 5;
        var result = LongestOnes(nums, k);
        Assert.AreEqual(expected, result);
    }
}