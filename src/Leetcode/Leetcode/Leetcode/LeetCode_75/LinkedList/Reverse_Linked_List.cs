namespace Leetcode.LeetCode_75.LinkedList;

public class Reverse_Linked_List
{
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null) {
            var tempNext = curr.next;
            
            curr.next = prev;
            prev = curr;
            curr = tempNext;
        }
    
        return prev;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}