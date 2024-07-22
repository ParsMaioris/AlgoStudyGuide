/**
 * Is Subsequence
 * Given two strings `s` and `t`, return `true` if `s` is a subsequence of `t`, or `false` otherwise.
 * 
 * Link to Original Problem: https://leetcode.com/problems/is-subsequence/
 */
[TestClass]
public class IsSubsequenceTests
{
    public bool IsSubsequence(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        int sIndex = 0, tIndex = 0;

        while (tIndex < t.Length)
        {
            if (IsMatchingCharacter(s, t, sIndex, tIndex))
            {
                sIndex++;
                if (sIndex == s.Length)
                {
                    return true;
                }
            }
            tIndex++;
        }

        return false;
    }

    private bool IsMatchingCharacter(string s, string t, int sIndex, int tIndex)
    {
        return s[sIndex] == t[tIndex];
    }

    [TestMethod]
    public void IsSubsequence_ShouldReturnTrue_WhenSubsequenceExists()
    {
        var s = "abc";
        var t = "ahbgdc";
        var expected = true;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldReturnFalse_WhenSubsequenceDoesNotExist()
    {
        var s = "axc";
        var t = "ahbgdc";
        var expected = false;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldReturnTrue_WhenSubsequenceIsEmpty()
    {
        var s = "";
        var t = "ahbgdc";
        var expected = true;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldReturnTrue_WhenSubsequenceIsAtStartMiddleEnd()
    {
        var s = "ace";
        var t = "abcde";
        var expected = true;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldReturnFalse_WhenTargetStringIsEmpty()
    {
        var s = "a";
        var t = "";
        var expected = false;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldHandleIdenticalStrings()
    {
        var s = "abc";
        var t = "abc";
        var expected = true;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsSubsequence_ShouldHandleNonOverlappingCharacters()
    {
        var s = "abc";
        var t = "def";
        var expected = false;
        var result = IsSubsequence(s, t);
        Assert.AreEqual(expected, result);
    }
}