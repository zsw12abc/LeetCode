/**
 * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
 * You may assume that each input would have exactly one solution, and you may not use the same element twice.
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function (nums, target) {
    var dict = {};
    for (var i = 0; i < nums.length; i++) {
        var inp = nums[i];
        var diff = target - inp;
        if (diff in dict) {
            return [dict[diff], i];
        }
        dict[inp] = i;
    }
    return null;
};

//testing
console.log(twoSum([2, 7, 11, 15], 9));
