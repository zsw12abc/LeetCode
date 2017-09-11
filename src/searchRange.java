import java.util.ArrayList;
import java.util.List;

public class searchRange {
    /**
     * Given an array of integers sorted in ascending order, find the starting and ending position of a given target value.
     * Your algorithm's runtime complexity must be in the order of O(log n).
     * If the target is not found in the array, return [-1, -1].
     * For example,
     * Given [5, 7, 7, 8, 8, 10] and target value 8,
     * return [3, 4].
     * https://leetcode.com/problems/search-for-a-range/description/
     *
     * @param nums
     * @param target
     * @return index in array
     */
    public int[] searchRange(int[] nums, int target) {
        int[] range = {nums.length, -1};
        searchRange(nums, target, 0, nums.length - 1, range);
        if (range[0] > range[1]) range[0] = -1;
        return range;
    }

    public void searchRange(int[] nums, int target, int left, int right, int[] range) {
        if (left > right) return;
        int mid = left + (right - left) / 2;
        if (nums[mid] == target) {
            if (mid < range[0]) {
                range[0] = mid;
                searchRange(nums, target, left, mid - 1, range);
            }
            if (mid > range[1]) {
                range[1] = mid;
                searchRange(nums, target, mid + 1, right, range);
            }
        } else if (nums[mid] < target) {
            searchRange(nums, target, mid + 1, right, range);
        } else {
            searchRange(nums, target, left, mid - 1, range);
        }
    }
}
