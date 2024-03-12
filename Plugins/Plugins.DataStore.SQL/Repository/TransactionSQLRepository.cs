using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;

namespace Plugins.DataStore.SQL.Repository
{
    public class TransactionSQLRepository : ITransactionRepository
    {
        private readonly MarketDbContext db;

        public TransactionSQLRepository(MarketDbContext marketDbContext)
        {
            this.db = marketDbContext;
        }
        // this mehod will give us List of transection of See list(make transaction entry) Quantity on Sell Page (used to show sell transections on Sell page)
        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date).ToList();
            }
            else
            {
                
                //var transaction = db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") && x.TimeStamp==date.Date).ToList();(This is not filtering any result)
                var transaction = db.Transactions.Where(x =>x.CashierName==cashierName || x.TimeStamp==date.Date).ToList();// this is working fine
                
                return transaction;
            }
        }

        public void RecordTransaction(string cashierName, string productName, int productQuantity, double price, int productId, int qtyToSell)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                CashierName = cashierName,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = productQuantity,
                SoldQty = qtyToSell
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate && x.TimeStamp.Date <= endDate).ToList();
            }
            else
            {
                return db.Transactions.Where(x =>
                EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                x.TimeStamp.Date >= startDate && x.TimeStamp.Date <= endDate).ToList();
            }
        }
    }
}
