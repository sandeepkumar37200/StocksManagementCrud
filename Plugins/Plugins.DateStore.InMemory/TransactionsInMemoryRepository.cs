using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace Plugins.DateStore.InMemory
{
    public class TransactionsInMemoryRepository: ITransactionRepository
    {
        private static List<Transaction> _transections = new List<Transaction>();

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return _transections.Where(x => x.TimeStamp.Date == date.Date);
            else
                return _transections.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                x.TimeStamp.Date == date.Date);
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                var result = _transections.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date).ToList();
                return result;
            }
            else
                return _transections.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }

        //Adding Transaction RecordTransaction(cashierName, productId, qtyToSell);
        public void RecordTransaction(string cashierName, string productName, int productQuantity,double price, int productId,int qtyToSell)
        {
            var trans = new Transaction
            {
                CashierName = cashierName,
                ProductName =productName,
                BeforeQty=productQuantity,
                ProductId = productId,
                SoldQty=qtyToSell,
                TimeStamp = DateTime.Now,
                Price=price,
                
            };

            if (_transections != null && _transections.Count > 0)
            {
                //it means we aasining the TransectionId, checking prevoius max TransectionId
                var maxId = _transections.Max(x => x.TransectionId);
                trans.TransectionId = maxId + 1;
            }
            else
            {
                // if List is empty we are assigning TransectionId as 1
                trans.TransectionId = 1;
            }

            _transections?.Add(trans);
        }
    }
}
