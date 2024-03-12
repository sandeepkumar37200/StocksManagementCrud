using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases.TransactionsUseCases
{
    public class ViewTransactionsByDateAndCashier : IViewTransactionsByDateAndCashier
    {
        private readonly ITransactionRepository _transactionRepository;

        public ViewTransactionsByDateAndCashier(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime date)
        {
            return _transactionRepository.GetByDayAndCashier(cashierName, date);
        }
    }
}
