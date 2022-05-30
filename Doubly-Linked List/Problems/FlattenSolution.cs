using Doubly_Linked_List.BasicClass;

namespace Doubly_Linked_List.Problems;

/// <summary>
/// 430. 扁平化多级双向链表
/// 你会得到一个双链表，其中包含的节点有一个下一个指针、一个前一个指针和一个额外的 子指针 。这个子指针可能指向一个单独的双向链表，也包含这些特殊的节点。
/// 这些子列表可以有一个或多个自己的子列表，以此类推，以生成如下面的示例所示的 多层数据结构 。
/// 给定链表的头节点head，将链表 扁平化 ，以便所有节点都出现在单层双链表中。让 curr 是一个带有子列表的节点。子列表中的节点应该出现在扁平化列表中的curr 之后 和curr.next之前 。
/// 返回 扁平列表的 head。列表中的节点必须将其 所有 子指针设置为null。
/// </summary>
public class FlattenSolution
{
    public static Node Flatten(Node head)
    {
        Dfs(head);
        return head;
    }

    private static Node Dfs(Node node)
    {
        var cur = node;
        Node last = null;
        while (cur != null)
        {
            var next = cur.next;
            if (cur.child != null)
            {
                var childLast = Dfs(cur.child);
                next = cur.next;
                cur.next = cur.child;
                cur.child.prev = cur;
                if (next != null)
                {
                    childLast.next = next;
                    next.prev = childLast;
                }

                cur.child = null;
                last = childLast;
            }
            else
            {
                last = cur;
            }

            cur = next;
        }

        return last;
    }
}