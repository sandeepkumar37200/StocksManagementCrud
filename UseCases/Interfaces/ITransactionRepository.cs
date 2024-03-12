using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Interfaces
{
    public interface ITransactionRepository
    {
        void RecordTransaction(string cashierName, string productName,int productQuantity,double price,int productId, int qtyToSell);
        IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date);
       
    }
}
