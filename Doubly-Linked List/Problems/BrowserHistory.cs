namespace Doubly_Linked_List.Problems;

/// <summary>
/// 1472. 设计浏览器历史记录
/// 你有一个只支持单个标签页的 浏览器，最开始你浏览的网页是homepage，你可以访问其他的网站url，也可以在浏览历史中后退steps步或前进steps步。
/// 请你实现BrowserHistory 类：
///     BrowserHistory(string homepage)，用homepage初始化浏览器类。
///     void visit(string url)从当前页跳转访问 url 对应的页面。执行此操作会把浏览历史前进的记录全部删除。
///     string back(int steps)在浏览历史中后退steps步。如果你只能在浏览历史中后退至多x 步且steps > x，那么你只后退x步。请返回后退 至多 steps步以后的url。
///     string forward(int steps)在浏览历史中前进steps步。如果你只能在浏览历史中前进至多x步且steps > x，那么你只前进 x步。请返回前进至多steps步以后的 url。
/// </summary>
public class BrowserHistory
{
    private Page homePage;

    public BrowserHistory(string homepage)
    {
        this.homePage = new Page(homepage);
    }

    public void Visit(string url)
    {
        var nextPage = new Page(url);
        var tempPage = homePage;
        nextPage.prev = tempPage;
        tempPage.next = nextPage;
        homePage = nextPage;
    }

    public string Back(int steps)
    {
        while (steps > 0)
        {
            if (homePage.prev != null)
            {
                homePage = homePage.prev;
            }
            else
            {
                break;
            }

            steps--;
        }

        return homePage.url;
    }

    public string Forward(int steps)
    {
        while (steps > 0)
        {
            if (homePage.next != null)
            {
                homePage = homePage.next;
            }
            else
            {
                break;
            }

            steps--;
        }

        return homePage.url;
    }
}

public class Page
{
    public string url;
    public Page prev;
    public Page next;

    public Page(string url)
    {
        this.url = url;
    }
}