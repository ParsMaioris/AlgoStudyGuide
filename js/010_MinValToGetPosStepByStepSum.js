/**
 * Minimum Value to Get Positive Step by Step Sum
 * Given an array of integers `nums`, find the minimum initial value `startValue` such that the running total 
 * (sum of `startValue` plus elements in `nums` from left to right) is always at least 1.
 * 
 * Link to Original Problem: https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
 * 
 * @param {number[]} nums - An array of integers
 * @return {number} - The minimum positive value of `startValue`
 */
function minStartValue(nums)
{
    let minSum = 0
    let currentSum = 0

    for (let num of nums)
    {
        currentSum += num
        minSum = Math.min(minSum, currentSum)
    }

    return 1 - minSum
}

function runTests()
{
    let nums, expected, result

    nums = [-3, 2, -3, 4, 2]
    expected = 5
    result = minStartValue(nums)
    console.assert(result === expected, `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [1, 2]
    expected = 1
    result = minStartValue(nums)
    console.assert(result === expected, `Test 2 Failed: Expected ${expected}, got ${result}`)

    nums = [1, -2, -3]
    expected = 5
    result = minStartValue(nums)
    console.assert(result === expected, `Test 3 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()