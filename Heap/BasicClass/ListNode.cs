namespace Heap.BasicClass
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(List<int> lists)
        {
            var head = new ListNode(0);
            var tail = head;
            foreach (var node in lists)
            {
                tail.next = new ListNode(node);
                tail = tail.next;
            }

            this.val = head.next.val;
            this.next = head.next.next;
        }

        public void DisplayListNode()
        {
            var tail = this;
            var output = "";
            while (tail != null)
            {
                output += tail.val;
                if (tail.next != null)
                {
                    output += "->";
                }

                tail = tail.next;
            }

            Console.WriteLine(output);
        }
    }
}