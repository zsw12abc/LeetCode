
public class reverse {
    /**
     * Reverse digits of an integer.
     * The input is assumed to be a 32-bit signed integer. Your function should return 0 when the reversed integer overflows.
     * https://leetcode.com/problems/reverse-integer/description/
     *
     * @param x
     * @return reversed integer
     */
    public int reverse(int x) {
        int result = 0;

        while (x != 0) {
            int tail = x % 10;
            int newResult = result * 10 + tail;
            if ((newResult - tail) / 10 != result) {//check overflows -2,147,483,647 <= int x <= 2,147,483,647 in Java
                return 0;
            }
            result = newResult;
            x = x / 10;
        }
        return result;
    }
}
