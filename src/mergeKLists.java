public class mergeKLists {
    /**
     * Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
     * https://leetcode.com/problems/merge-k-sorted-lists/description/
     *
     * @param lists
     * @return
     */
    //Time Limit Exceeded
   /* public ListNode mergeKLists(ListNode[] lists) {
        int len = lists.length;
        if (len == 1) {
            return lists[0];
        }
        ListNode initial = null;
        for (int i = 0; i < len; i++){
            initial = mergeTwoLists(initial, lists[i]);
        }
        return initial;
    }*/


    /*private ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        if (l1.val < l2.val) {
            l1.next = mergeTwoLists(l1.next, l2);
            return l1;
        } else {
            l2.next = mergeTwoLists(l1, l2.next);
            return l2;
        }
    }*/

    public static ListNode mergeKLists(ListNode[] lists){
        return partion(lists,0,lists.length-1);
    }

    public static ListNode partion(ListNode[] lists,int s,int e){
        if(s==e)  return lists[s];
        if(s<e){
            int q=(s+e)/2;
            ListNode l1=partion(lists,s,q);
            ListNode l2=partion(lists,q+1,e);
            return merge(l1,l2);
        }else
            return null;
    }

    //This function is from Merge Two Sorted Lists.
    public static ListNode merge(ListNode l1,ListNode l2){
        if(l1==null) return l2;
        if(l2==null) return l1;
        if(l1.val<l2.val){
            l1.next=merge(l1.next,l2);
            return l1;
        }else{
            l2.next=merge(l1,l2.next);
            return l2;
        }
    }
}
