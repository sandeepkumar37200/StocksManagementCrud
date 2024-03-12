using Microsoft.AspNetCore.Mvc;
using StocksAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.TransactionsUseCases;

namespace StocksAnalysis.Controllers
{
    public class TransactionsController : Controller
    {
        
        private readonly ISearchTransactionsUseCase _searchTransactionsUseCase;


        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            _searchTransactionsUseCase = searchTransactionsUseCase;
        }
        public IActionResult Index()
        {
            //passing TransactionViewModel object so that we can use properties in HTML form
            TransactionViewModel transactionViewModel = new TransactionViewModel();
            return View(transactionViewModel);
        }

        [HttpPost]
        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            var transaction=_searchTransactionsUseCase.Execute(transactionViewModel.CashierName ?? string.Empty, transactionViewModel.StartDate, transactionViewModel.EndDate);
            
            transactionViewModel.Transections = transaction;

            return View("Index",transactionViewModel);
        }
    }
}
