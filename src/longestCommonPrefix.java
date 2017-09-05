public class longestCommonPrefix {
    /**
     * Write a function to find the longest common prefix string amongst an array of strings.
     * https://leetcode.com/problems/longest-common-prefix/description/
     *
     * @param strs
     * @return longest Common Prefix
     */
    public String longestCommonPrefix(String[] strs) {
        if (strs.length == 0) {
            return "";
        }
        String prefix = strs[0];
        for (int i = 1; i < strs.length; i++) {
            while (strs[i].indexOf(prefix) != 0) {
                prefix = prefix.substring(0, prefix.length() - 1);
                if (prefix.isEmpty()) {
                    return "";
                }
            }
        }
        return prefix;
    }
}
