/**
 * Squares of a Sorted Array
 * Given an integer array `nums` sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
 * 
 * Link to Original Problem: https://leetcode.com/problems/squares-of-a-sorted-array/
 * 
 * @param {number[]} nums - An array of integers sorted in non-decreasing order
 * @return {number[]} - An array of the squares of each number sorted in non-decreasing order
 */
function sortedSquares(nums)
{
    const result = new Array(nums.length)
    let left = 0
    let right = nums.length - 1
    let pos = nums.length - 1

    while (left <= right)
    {
        const leftSquare = nums[left] * nums[left]
        const rightSquare = nums[right] * nums[right]

        if (leftSquare > rightSquare)
        {
            result[pos] = leftSquare
            left++
        } else
        {
            result[pos] = rightSquare
            right--
        }
        pos--
    }

    return result
}

function runTests()
{
    let nums, expected, result

    nums = [-4, -1, 0, 3, 10]
    expected = [0, 1, 9, 16, 100]
    result = sortedSquares(nums)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [-7, -3, 2, 3, 11]
    expected = [4, 9, 9, 49, 121]
    result = sortedSquares(nums)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 2 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()