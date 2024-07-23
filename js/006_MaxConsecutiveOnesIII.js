/**
 * Max Consecutive Ones III
 * Given a binary array `nums` and an integer `k`, return the maximum number of 
 * consecutive 1's in the array if you can flip at most `k` 0's.
 * 
 * Link to Original Problem: https://leetcode.com/problems/max-consecutive-ones-iii/
 * 
 * @param {number[]} nums - A binary array
 * @param {number} k - The maximum number of 0's that can be flipped
 * @return {number} - The maximum number of consecutive 1's after flipping at most `k` 0's
 */
function longestOnes(nums, k)
{
    let left = 0
    let right = 0
    let zeroCount = 0
    let maxLength = 0

    while (right < nums.length)
    {
        if (nums[right] === 0)
        {
            zeroCount++
        }

        while (zeroCount > k)
        {
            if (nums[left] === 0)
            {
                zeroCount--
            }
            left++
        }

        maxLength = Math.max(maxLength, right - left + 1)
        right++
    }

    return maxLength
}

function runTests()
{
    let nums, k, expected, result

    nums = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0]
    k = 2
    expected = 6
    result = longestOnes(nums, k)
    console.assert(result === expected, `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [0, 0, 1, 1, 1, 0, 0]
    k = 0
    expected = 3
    result = longestOnes(nums, k)
    console.assert(result === expected, `Test 2 Failed: Expected ${expected}, got ${result}`)

    nums = [0, 0, 1, 1, 1, 0, 0, 1, 1, 1]
    k = 2
    expected = 8
    result = longestOnes(nums, k)
    console.assert(result === expected, `Test 3 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()