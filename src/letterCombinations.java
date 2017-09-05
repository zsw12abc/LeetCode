import java.util.ArrayList;
import java.util.List;

//Given a digit string, return all possible letter combinations that the number could represent.

public class letterCombinations {
    String[][] refer = {{}, {}, {"a", "c", "b"}, {"d", "e", "f"}, {"g", "h", "i"}, {"j", "k", "l"}, {"m", "n", "o"}, {"p", "q", "r", "s"}, {"t", "u", "v"}, {"w", "x", "y", "z"}};

    public List<String> letterCombinations(String digits) {
        List<String> list = new ArrayList<String>();
        if (!digits.equals("")) {
            helper(list, digits, "");
            return list;
        }
        return list;
    }

    private void helper(List<String> list, String digits, String s) {
        if (digits.length() == 0) {
            list.add(s);
            return;
        }
        int idx = Integer.parseInt(digits.substring(0, 1));
        for (String k : refer[idx]) {
            helper(list, digits.substring(1, digits.length()), s + k);
        }
        return;
    }
}
