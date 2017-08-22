class Solution {
    public static int lengthOfLongestSubstring(String s) {
        String[] sArray = s.split("");
        String compareString = "";
        int len = 0;
        int compLen = 0;
        for(int i = 0 ; i < sArray.length; i++) {
            if (!compareString.contains(sArray[i])) {
                compareString += sArray[i];
                len++;
            } else {
                if (compLen < compareString.length()) {
                    compLen = compareString.length();
                }
                compareString = sArray[i];
                len = compareString.length();
            }
            System.out.println("Len:" + len);
            System.out.println("SubString" + " " + compareString);
        }
        if(compLen < len){
            return len;
        }else {
            return compLen;
        }
    }
}

