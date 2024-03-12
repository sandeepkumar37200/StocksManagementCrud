using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.TransactionsUseCases
{
    public interface ISearchTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}