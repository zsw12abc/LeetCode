import java.util.Arrays;
import java.util.List;

public class Solution {
    /**
     * use for test the code in LeetCode Program
     *
     * @param args
     */
    public static void main(String[] args) {
        generateParenthesis g = new generateParenthesis();
        for (String s : g.generateParenthesis(3)) {
            System.out.println(s);
        }
    }
}
