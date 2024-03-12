using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.TransactionsUseCases
{
    public interface IViewTransactionsByDateAndCashier
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime date);
    }
}