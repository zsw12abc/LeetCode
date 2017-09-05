import java.util.Arrays;

//Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target.
// Return the sum of the three integers. You may assume that each input would have exactly one solution.
public class threeSumClosest {
    public class Solution {
        public int threeSumClosest(int[] num, int target) {
            int result = num[0] + num[1] + num[num.length - 1];
            Arrays.sort(num);
            for (int i = 0; i < num.length - 2; i++) {
                int start = i + 1, end = num.length - 1;
                while (start < end) {
                    int sum = num[i] + num[start] + num[end];
                    if (sum > target) {
                        end--;
                    } else {
                        start++;
                    }
                    if (Math.abs(sum - target) < Math.abs(result - target)) {
                        result = sum;
                    }
                }
            }
            return result;
        }
    }
}
