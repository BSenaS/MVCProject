using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            //1.Initialize the ViewModel first.
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            //1-)Filter sonucuna göre, Repositoryden ilgili verileri çekme
            var transactions = TransactionsRepository.Search(transactionsViewModel.CashierName??string.Empty, transactionsViewModel.StartDate, transactionsViewModel.EndDate);

            //2-)Gelen veriyi TransactionViewModele atama.
            transactionsViewModel.Transactions = transactions;


            return View("Index",transactionsViewModel);
        }
    }
}
