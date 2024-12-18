using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    [ViewComponent]  //-> Bu attr. ile bu classın bir ViewComponent oldugu belirtiriz.
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
            return View(transactions);
        }
    }
}
