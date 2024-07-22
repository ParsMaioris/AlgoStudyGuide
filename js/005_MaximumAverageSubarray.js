/**
 * Maximum Average Subarray I
 * Given an integer array `nums` consisting of `n` elements and an integer `k`, find a contiguous subarray whose length is equal to `k` that has the maximum average value and return this value.
 * 
 * Link to Original Problem: https://leetcode.com/problems/maximum-average-subarray-i/
 * 
 * @param {number[]} nums - An array of integers
 * @param {number} k - The length of the subarray
 * @return {number} - The maximum average value of any subarray of length `k`
 */
function findMaxAverage(nums, k)
{
    let maxSum = 0

    for (let i = 0; i < k; i++)
        maxSum += nums[i]

    let currentSum = maxSum

    for (let i = k; i < nums.length; i++)
    {
        currentSum += nums[i] - nums[i - k]
        maxSum = Math.max(maxSum, currentSum)
    }

    return maxSum / k
}

function runTests()
{
    let nums, k, expected, result

    nums = [1, 12, -5, -6, 50, 3]
    k = 4
    expected = 12.75
    result = findMaxAverage(nums, k)
    console.assert(Math.abs(result - expected) < 1e-5, `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [5]
    k = 1
    expected = 5.0
    result = findMaxAverage(nums, k)
    console.assert(Math.abs(result - expected) < 1e-5, `Test 2 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()