/**
 * Subarray Product Less Than K
 * Given an array of integers `nums` and an integer `k`, return the number of contiguous subarrays where the 
 * product of all the elements in the subarray is strictly less than `k`.
 * 
 * Link to Original Problem: https://leetcode.com/problems/subarray-product-less-than-k/
 * 
 * @param {number[]} nums - An array of integers
 * @param {number} k - The target product threshold
 * @return {number} - The number of contiguous subarrays with product less than `k`
 */
function numSubarrayProductLessThanK(nums, k)
{
    if (k <= 1) return 0

    let left = 0
    let product = 1
    let count = 0

    for (let right = 0; right < nums.length; right++)
    {
        product *= nums[right]

        while (product >= k)
        {
            product /= nums[left]
            left++
        }

        count += right - left + 1
    }

    return count
}

function runTests()
{
    let nums, k, expected, result

    nums = [10, 5, 2, 6]
    k = 100
    expected = 8
    result = numSubarrayProductLessThanK(nums, k)
    console.assert(result === expected, `Test 1 Failed: Expected ${expected}, got ${result}`)

    nums = [1, 2, 3]
    k = 0
    expected = 0
    result = numSubarrayProductLessThanK(nums, k)
    console.assert(result === expected, `Test 2 Failed: Expected ${expected}, got ${result}`)

    console.log("All tests passed!")
}

runTests()