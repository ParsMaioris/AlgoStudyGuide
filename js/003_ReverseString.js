/**
 * Reverse String
 * Write a function that reverses a string. The input string is given as an array of characters `s`.
 * You must do this by modifying the input array in-place with O(1) extra memory.
 * 
 * Link to Original Problem: https://leetcode.com/problems/reverse-string/
 * 
 * @param {character[]} s - An array of characters
 * @return {void} - Do not return anything, modify `s` in-place instead.
 */
function reverseString(s)
{
    let left = 0
    let right = s.length - 1

    while (left < right)
    {
        let temp = s[left]
        s[left] = s[right]
        s[right] = temp
        left++
        right--
    }
}

function runTests()
{
    let s, expected

    s = ['h', 'e', 'l', 'l', 'o']
    expected = ['o', 'l', 'l', 'e', 'h']
    reverseString(s)
    console.assert(JSON.stringify(s) === JSON.stringify(expected), `Test 1 Failed: Expected ${expected}, got ${s}`)

    s = ['H', 'a', 'n', 'n', 'a', 'h']
    expected = ['h', 'a', 'n', 'n', 'a', 'H']
    reverseString(s)
    console.assert(JSON.stringify(s) === JSON.stringify(expected), `Test 2 Failed: Expected ${expected}, got ${s}`)

    console.log("All tests passed!")
}

runTests()