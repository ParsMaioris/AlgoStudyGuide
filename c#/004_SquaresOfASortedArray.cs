/**
 * Squares of a Sorted Array
 * Given an integer array `nums` sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
 * 
 * Link to Original Problem: https://leetcode.com/problems/squares-of-a-sorted-array/
 */
[TestClass]
public class SortedSquaresTests
{
    public int[] SortedSquares(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return new int[] { };
        }

        int[] result = new int[nums.Length];
        int left = 0;
        int right = nums.Length - 1;
        int pos = nums.Length - 1;

        while (left <= right)
        {
            int leftSquare = CalculateSquare(nums[left]);
            int rightSquare = CalculateSquare(nums[right]);

            if (leftSquare > rightSquare)
            {
                result[pos] = leftSquare;
                left++;
            }
            else
            {
                result[pos] = rightSquare;
                right--;
            }
            pos--;
        }

        return result;
    }

    private int CalculateSquare(int num)
    {
        return num * num;
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayContainsNegativeAndPositiveNumbers()
    {
        var nums = new int[] { -4, -1, 0, 3, 10 };
        var expected = new int[] { 0, 1, 9, 16, 100 };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayContainsNegativeAndPositiveNumbersWithDuplicates()
    {
        var nums = new int[] { -7, -3, 2, 3, 11 };
        var expected = new int[] { 4, 9, 9, 49, 121 };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayContainsOnlyPositiveNumbers()
    {
        var nums = new int[] { 1, 2, 3, 4, 5 };
        var expected = new int[] { 1, 4, 9, 16, 25 };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayContainsOnlyNegativeNumbers()
    {
        var nums = new int[] { -5, -4, -3, -2, -1 };
        var expected = new int[] { 1, 4, 9, 16, 25 };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayContainsSingleElement()
    {
        var nums = new int[] { -2 };
        var expected = new int[] { 4 };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SortedSquares_ShouldReturnSquaresOfSortedArray_WhenArrayIsEmpty()
    {
        var nums = new int[] { };
        var expected = new int[] { };
        var result = SortedSquares(nums);
        CollectionAssert.AreEqual(expected, result);
    }
}