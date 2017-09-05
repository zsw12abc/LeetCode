import java.util.Arrays;
import java.util.List;

public class Solution {
    /**
     * use for test the code in LeetCode Program
     *
     * @param args
     */
    public static void main(String[] args) {
        fourSum f = new fourSum();
        int[] nums = {-1, 0, 1, 2, -1, -4};
        for (List<Integer> integers : f.fourSum(nums, -1)) {
            System.out.println(integers);
        }
    }
}
