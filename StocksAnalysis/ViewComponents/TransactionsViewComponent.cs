using Microsoft.AspNetCore.Mvc;
using System;
using UseCases.TransactionsUseCases;

namespace StocksAnalysis.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly IViewTransactionsByDateAndCashier _viewTransactionsByDateAndCashier;

        // this is very similar to action method:action method return IActionResult

        // here we are using view Components to display list of transection on sales console

        // requiremts: the list of transections should be for the current day and is for the login User (which is cashier)
        // View Components needs to know which user that it needs to display transections for.
        public TransactionsViewComponent(IViewTransactionsByDateAndCashier viewTransactionsByDateAndCashier)
        {
            _viewTransactionsByDateAndCashier = viewTransactionsByDateAndCashier;
        }
        public IViewComponentResult Invoke(string userName)
        {

            var transactions = _viewTransactionsByDateAndCashier.Execute(userName, DateTime.Now);
            //where we need to place this view
            //TransectionsViewComponent name take prefix Transections         
            ///Views/Sales/Components/Transections/Default.cshtml
            //Views/Shared/Components/Transections/Default.cshtml
            return View(transactions);
        }
    }
}
