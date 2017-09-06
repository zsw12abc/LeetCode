import java.util.ArrayList;
import java.util.List;

public class generateParenthesis {
    /**
     * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
     * https://leetcode.com/problems/generate-parentheses/description/
     *
     * @param n
     * @return all combinations in a list
     */
    public List<String> generateParenthesis(int n) {
        List<String> list = new ArrayList<>();
        backtrack(list, "", 0, 0, n);
        return list;
    }

    /**
     * The idea here is to only add '(' and ')' that we know will guarantee us a solution (instead of adding 1 too many close).
     * Once we add a '(' we will then discard it and try a ')' which can only close a valid '('. Each of these steps are recursively called.
     *
     * @param list
     * @param str
     * @param open
     * @param close
     * @param max
     */
    private void backtrack(List<String> list, String str, int open, int close, int max) {
        if (str.length() == max * 2) {
            list.add(str);
            return;
        }
        if (open < max) {
            backtrack(list, str + "(", open + 1, close, max);
        }
        if (close < open) {
            backtrack(list, str + ")", open, close + 1, max);
        }
    }
}
