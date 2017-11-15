/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function (s) {
    var len = s.length;
    if (len <= 1) {
        return len;
    }
    var max = 0;
    var i = 0;
    var tempStr = '';
    while (i < len) {
        var curChar = s.charAt(i);
        var index = tempStr.indexOf(curChar);

        if (index === -1) {
            i++;
            tempStr += curChar;
            max = Math.max(max, tempStr.length);
        } else {
            tempStr = tempStr.slice(index + 1);
        }
    }
    return max;
};

//testing
console.log(lengthOfLongestSubstring("abcabcbb"));