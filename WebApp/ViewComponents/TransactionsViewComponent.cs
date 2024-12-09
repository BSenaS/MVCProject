using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    [ViewComponent]  //-> Bu attr. ile bu classın bir ViewComponent oldugu belirtiriz.
    public class TransactionsViewComponent
    {
        public string Invoke()
        {
            return "List of Transactions";
        }
    }
}
