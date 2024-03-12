using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases.TransactionsUseCases
{
    public class SearchTransactionsUseCase : ISearchTransactionsUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public SearchTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            return _transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
