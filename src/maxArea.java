/*Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

        Note: You may not slant the container and n is at least 2.*/
public class maxArea {
    public int maxArea(int[] height) {
        int area = 0;//max area
        int l = 0;//length of the container
        int w = height.length - 1;//weight of the container
        while (l < w) {
            area = Math.max(Math.min(height[l], height[w]) * (w - l), area);
            if (height[l] < height[w]) {
                l++;
            } else {
                w--;
            }
        }
        return area;
    }
}
