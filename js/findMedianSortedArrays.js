/**
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function (nums1, nums2) {
    if (!(Array.isArray(nums1) && Array.isArray(nums2)) || (nums1.length === 0 && nums2.length === 0)) return;

    var arr = [],
        mlen = nums1.length,
        nlen = nums2.length,
        isOdd = ( nums1.length + nums2.length ) % 2;

    // nums1 和 nums2 中有一个是空数组，就计算并返回另一个数组的中间值
    if (mlen === 0) return nlen % 2 ? nums2[Math.floor(nlen / 2)] : ( nums2[nlen / 2 - 1] + nums2[nlen / 2] ) / 2;
    if (nlen === 0) return mlen % 2 ? nums1[Math.floor(mlen / 2)] : ( nums1[mlen / 2 - 1] + nums1[mlen / 2] ) / 2;

    // 遍历的次数为两个数组长度的均值
    while (arr.length !== Math.floor((mlen + nlen) / 2)) {
        // 1. 若遍历的过程中两个数组中有一个空了，则弹出另一个的首值并压入 arr 中
        // 2. 两个数组都没有空的话，比较他们首值的大小，将较小的弹出并压入 arr 中
        if (nums2[0] === undefined || nums1[0] <= nums2[0]) {
            arr.push(nums1.shift());
        } else {
            arr.push(nums2.shift());
        }
    }

    // 遍历结束后两个数组中有一方变成空数组的情况
    // 奇数，那么剩下的非空数组的首值就是最后的结果
    // 偶数，那么剩下的非空数组额首值与 arr 的末值的均值就是最后的结果
    if (nums1[0] === undefined) return isOdd ? nums2[0] : (nums2[0] + arr[arr.length - 1]) / 2;
    if (nums2[0] === undefined) return isOdd ? nums1[0] : (nums1[0] + arr[arr.length - 1]) / 2;

    // 遍历结束后两个数组均非空的情况
    // 奇数，两个数组首值的较小值就是最后的结果
    // 偶数，两个数组首值的较小值与 arr 末值的均值就是最后的结果
    if (isOdd) {
        return nums1[0] < nums2[0] ? nums1[0] : nums2[0];
    } else {
        return nums1[0] < nums2[0] ? (nums1[0] + arr[arr.length - 1]) / 2 : (nums2[0] + arr[arr.length - 1]) / 2;
    }
};
