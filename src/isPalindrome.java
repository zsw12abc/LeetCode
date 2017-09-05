
public class isPalindrome {
    /**
     * Determine whether an integer is a palindrome. Do this without extra space.
     * https://leetcode.com/problems/palindrome-number/description/
     *
     * @param x
     * @return is palindrome or not
     */
    public boolean isPalindrome(int x) {
        if (x < 0 || (x != 0 && x % 10 == 0)) return false;
        int rev = 0;
        while (x > rev) {
            rev = rev * 10 + x % 10;
            x = x / 10;
        }
        return (x == rev || x == rev / 10);
    }
}
