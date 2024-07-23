/**
 * Number of Valid Splits
 * Given a 0-indexed integer array `nums` of length `n`, return the number of valid splits in `nums`.
 * 
 * nums contains a valid split at index i if the following are true:
 * 1. The sum of the first i + 1 elements is greater than or equal to the sum of the last n - i - 1 elements.
 * 2. There is at least one element to the right of i. That is, 0 <= i < n - 1.
 * 
 * Link to Original Problem: https://leetcode.com/problems/number-of-ways-to-split-array
 * 
 * @param {number[]} nums - An array of integers
 * @return {number} - The number of valid splits in the array
 */
function countValidSplits(nums)
{
    const totalSum = nums.reduce((acc, num) => acc + num, 0)
    let leftSum = 0
    let validSplits = 0

    for (let i = 0; i < nums.length - 1; i++)
    {
        leftSum += nums[i]
        const rightSum = totalSum - leftSum

        if (leftSum >= rightSum)
        {
            validSplits++
        }
    }

    return validSplits
}

function runTests()
{
    let nums, expected, result

    nums = [10, 4, -8, 7]
    expected = 2
    result = countValidSplits(nums)
    console.assert(result === expected, `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [2, 3, 1, 0]
    expected = 2
    result = countValidSplits(nums)
    console.assert(result === expected, `Test 2 Failed: Expected ${expected}, got ${result}`)

    nums = [1, 2, 3, 4, 5]
    expected = 1
    result = countValidSplits(nums)
    console.assert(result === expected, `Test 3 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()