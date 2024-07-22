/**
 * Two Sum
 * Given an array of integers `nums` and an integer `target`, find two numbers such that they add up to `target`.
 * Return the indices of the two numbers.
 * 
 * Link to Original Problem: https://leetcode.com/problems/two-sum/
 * 
 * @param {number[]} nums - An array of integers
 * @param {number} target - The target sum
 * @return {number[]} - Indices of the two numbers that add up to target
 */
function twoSum(nums, target)
{
    const numToIndex = new Map()

    for (let i = 0; i < nums.length; i++)
    {
        const complement = target - nums[i]

        if (numToIndex.has(complement))
        {
            return [numToIndex.get(complement), i]
        }

        numToIndex.set(nums[i], i)
    }

    throw new Error("No two sum solution")
}

function runTests()
{
    let nums, target, expected, result

    nums = [2, 7, 11, 15]
    target = 9
    expected = [0, 1]
    result = twoSum(nums, target)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [3, 2, 4]
    target = 6
    expected = [1, 2]
    result = twoSum(nums, target)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 2 Failed: Expected ${expected}, got ${result}`)

    nums = [3, 3]
    target = 6
    expected = [0, 1]
    result = twoSum(nums, target)
    console.assert(JSON.stringify(result) === JSON.stringify(expected), `Test 3 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()