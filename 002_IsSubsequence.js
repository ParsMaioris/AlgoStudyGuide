/**
 * Is Subsequence
 * Given two strings `s` and `t`, return `true` if `s` is a subsequence of `t`, or `false` otherwise.
 * 
 * Link to Original Problem: https://leetcode.com/problems/is-subsequence/
 * 
 * @param {string} s - The subsequence string
 * @param {string} t - The target string
 * @return {boolean} - True if `s` is a subsequence of `t`, otherwise false
 */
function isSubsequence(s, t)
{
    let sIndex = 0
    let tIndex = 0

    while (sIndex < s.length && tIndex < t.length)
    {
        if (s[sIndex] === t[tIndex])
        {
            sIndex++
        }
        tIndex++
    }

    return sIndex === s.length
}

function runTests()
{
    let s, t, expected, result

    s = "abc"
    t = "ahbgdc"
    expected = true
    result = isSubsequence(s, t)
    console.assert(result === expected, `Test 1 Failed: Expected ${expected}, got ${result}`)

    s = "axc"
    t = "ahbgdc"
    expected = false
    result = isSubsequence(s, t)
    console.assert(result === expected, `Test 2 Failed: Expected ${expected}, got ${result}`)

    s = ""
    t = "ahbgdc"
    expected = true
    result = isSubsequence(s, t)
    console.assert(result === expected, `Test 3 Failed: Expected ${expected}, got ${result}`)

    s = "ace"
    t = "abcde"
    expected = true
    result = isSubsequence(s, t)
    console.assert(result === expected, `Test 4 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()