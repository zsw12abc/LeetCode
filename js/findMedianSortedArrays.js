/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function (nums1, nums2) {
    if (!(Array.isArray(nums1) && Array.isArray(nums2)) || (nums1.length === 0 && nums2.length === 0)) return;

    var arr = [];
    var len1 = nums1.length;
    var len2 = nums2.length;
    var isOdd = (nums1.length + nums2.length) % 2;

    if (len1 === 0) {
        return len2 % 2 ? nums2[Math.floor(len2 / 2)] : ( nums2[len2 / 2 - 1] + nums2[len2 / 2] ) / 2;
    }
    if (len2 === 0) {
        return len1 % 2 ? nums1[Math.floor(len1 / 2)] : ( nums1[len1 / 2 - 1] + nums1[len1 / 2] ) / 2;
    }

    while (arr.length !== Math.floor(len1 + len2) / 2) {
        if (nums2[0] === undefined || nums1[0] <= nums2[0]) {
            arr.push(nums1.shift());
        } else {
            arr.push(nums2.shift());
        }
    }

    if (nums1[0] === undefined) {
        return isOdd ? nums2[0] : (nums2[0] + arr[arr.length - 1]) / 2;
    }
    if (nums2[0] === undefined) {
        return isOdd ? nums1[0] : (nums1[0] + arr[arr.length - 1]) / 2;
    }


    if (isOdd) {
        return nums1[0] < nums2[0] ? nums1[0] : nums2[0];
    } else {
        return nums1[0] < nums2[0] ? (nums1[0] + arr[arr.length - 1]) / 2 : (nums2[0] + arr[arr.length - 1]) / 2;
    }
};