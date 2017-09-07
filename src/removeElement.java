public class removeElement {
    /**
     * Given an array and a value, remove all instances of that value in place and return the new length.
     * Do not allocate extra space for another array, you must do this in place with constant memory.
     * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
     * https://leetcode.com/problems/remove-element/description/
     *
     * @param nums
     * @param val
     * @return the length of the new array
     */
    public int removeElement(int[] nums, int val) {
        int result = 0;
        for (int i = 0; i < nums.length; i++){
            if (nums[i] != val){
                nums[result] = nums[i];
                result++;
            }
        }
        return result;
    }
}
