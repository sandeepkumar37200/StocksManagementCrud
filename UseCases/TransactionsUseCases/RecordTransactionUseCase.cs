using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace UseCases.TransactionsUseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Execute(string cashierName,string productName,int productQuantity, double price, int productId, int qtyToSell)
        {
            _transactionRepository.RecordTransaction(cashierName, productName, productQuantity, price,productId, qtyToSell);
        }
    }
}
