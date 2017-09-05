import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;


public class fourSum {
    /**
     * Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target?
     * Find all unique quadruplets in the array which gives the sum of target.
     * https://leetcode.com/problems/4sum/description/
     *
     * @param nums
     * @param target
     * @return all unique quadruplets in the array which gives the sum of target.
     */
    public List<List<Integer>> fourSum(int[] nums, int target) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(nums);
        for (int i = 0; i < nums.length; i++) {
            for (int j = i + 1; j < nums.length; j++) {
                int k = j + 1;
                int end = nums.length - 1;
                while (k < end) {
                    if (nums[i] + nums[j] + nums[k] + nums[end] == target) {
                        List<Integer> goChat = Arrays.asList(nums[i], nums[j], nums[k], nums[end]);
                        if (!result.contains(goChat)) {// delete the duplicates: nums[j++] == nums[j]
                            result.add(goChat);
                        }
                        k++;
                        end--;
                        while (k < end && nums[k] == nums[k - 1]) {
                            k++;
                        }
                        while (k < end && nums[end] == nums[end + 1]) {
                            end--;
                        }
                    } else if (nums[i] + nums[j] + nums[k] + nums[end] > target) {
                        end--;
                    } else {
                        k++;
                    }
                }
            }
        }
        return result;
    }
}
