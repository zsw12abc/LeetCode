import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class threeSum {
    /**
     * Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0?
     * Find all unique triplets in the array which gives the sum of zero.
     * https://leetcode.com/problems/3sum/description/
     *
     * @param nums
     * @return
     */
    public List<List<Integer>> threeSum(int[] nums) {
        List<List<Integer>> result = new ArrayList<>();
        Arrays.sort(nums);
        for (int i = 0; i < nums.length; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }
            int j = i + 1;
            int k = nums.length - 1;
            int target = nums[i] * -1;
            while (j < k) {
                if (nums[j] + nums[k] == target) {
                    result.add(Arrays.asList(nums[i], nums[j], nums[k]));
                    j++;
                    k--;
                    while (j < k && nums[j] == nums[j - 1]) {
                        j++;
                    }
                    while (j < k && nums[k] == nums[k + 1]) {
                        k--;
                    }
                } else if (nums[j] + nums[k] > target) {
                    k--;
                } else {
                    j++;
                }
            }
        }
        return result;
    }
}
