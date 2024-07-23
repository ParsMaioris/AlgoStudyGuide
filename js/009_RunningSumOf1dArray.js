/**
 * Running Sum of 1d Array
 * Given an array `nums`, we define a running sum of an array as `runningSum[i] = sum(nums[0]…nums[i])`.
 * 
 * Return the running sum of `nums`.
 * 
 * Link to Original Problem: https://leetcode.com/problems/running-sum-of-1d-array/
 * 
 * @param {number[]} nums - An array of integers
 * @return {number[]} - The running sum of the array
 */
function runningSum(nums)
{
    let sum = 0
    return nums.map(num => sum += num)
}

function runTests()
{
    let nums, expected, result

    nums = [1, 2, 3, 4]
    expected = [1, 3, 6, 10]
    result = runningSum(nums)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [1, 1, 1, 1, 1]
    expected = [1, 2, 3, 4, 5]
    result = runningSum(nums)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 2 Failed: Expected ${expected}, got ${result}`)

    nums = [3, 1, 2, 10, 1]
    expected = [3, 4, 6, 16, 17]
    result = runningSum(nums)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 3 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()