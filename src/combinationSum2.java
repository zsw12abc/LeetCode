import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class combinationSum2 {
    /**
     * Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.
     * Each number in C may only be used once in the combination.
     * Note:
     * All numbers (including target) will be positive integers.
     * The solution set must not contain duplicate combinations.
     *
     * @param candidates
     * @param target
     * @return
     */
    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        Arrays.sort(candidates);
        List<List<Integer>> res = new ArrayList<List<Integer>>();
        List<Integer> path = new ArrayList<Integer>();
        dfs_com(candidates, 0, target, path, res);
        return res;
    }

    /**
     *
     * @param candidates
     * @param cur
     * @param target
     * @param path
     * @param res
     */
    private void dfs_com(int[] candidates, int cur, int target, List<Integer> path, List<List<Integer>> res) {
        if (target == 0) {
            res.add(new ArrayList<>(path));
            return;
        }
        if (target < 0) return;
        for (int i = cur; i < candidates.length; i++) {
            if (i > cur && candidates[i] == candidates[i - 1]) continue;
            path.add(path.size(), candidates[i]);
            dfs_com(candidates, i + 1, target - candidates[i], path, res);
            path.remove(path.size() - 1);
        }
    }
}
