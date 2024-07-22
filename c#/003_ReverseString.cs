/**
 * Reverse String
 * Write a function that reverses a string. The input string is given as an array of characters `s`.
 * You must do this by modifying the input array in-place with O(1) extra memory.
 * 
 * Link to Original Problem: https://leetcode.com/problems/reverse-string/
 */
[TestClass]
public class ReverseStringTests
{
    public void ReverseString(char[] s)
    {
        if (s == null || s.Length == 0)
        {
            return;
        }

        ReverseArrayInPlace(s);
    }

    private void ReverseArrayInPlace(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            Swap(s, left, right);
            left++;
            right--;
        }
    }

    private void Swap(char[] s, int left, int right)
    {
        char temp = s[left];
        s[left] = s[right];
        s[right] = temp;
    }

    [TestMethod]
    public void ReverseString_ShouldReverseOddLengthString()
    {
        var s = new char[] { 'h', 'e', 'l', 'l', 'o' };
        var expected = new char[] { 'o', 'l', 'l', 'e', 'h' };
        ReverseString(s);
        CollectionAssert.AreEqual(expected, s);
    }

    [TestMethod]
    public void ReverseString_ShouldReverseEvenLengthString()
    {
        var s = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };
        var expected = new char[] { 'h', 'a', 'n', 'n', 'a', 'H' };
        ReverseString(s);
        CollectionAssert.AreEqual(expected, s);
    }

    [TestMethod]
    public void ReverseString_ShouldHandleSingleCharacter()
    {
        var s = new char[] { 'a' };
        var expected = new char[] { 'a' };
        ReverseString(s);
        CollectionAssert.AreEqual(expected, s);
    }

    [TestMethod]
    public void ReverseString_ShouldHandleEmptyArray()
    {
        var s = new char[] { };
        var expected = new char[] { };
        ReverseString(s);
        CollectionAssert.AreEqual(expected, s);
    }

    [TestMethod]
    public void ReverseString_ShouldHandleArrayWithSameCharacters()
    {
        var s = new char[] { 'a', 'a', 'a', 'a' };
        var expected = new char[] { 'a', 'a', 'a', 'a' };
        ReverseString(s);
        CollectionAssert.AreEqual(expected, s);
    }
}