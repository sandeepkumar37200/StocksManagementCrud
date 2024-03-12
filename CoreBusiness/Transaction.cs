using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Transaction
    {
        [Key]
        public int TransectionId { get; set; }

        public DateTime TimeStamp { get; set; }

        public int ProductId { get; set; } // we have product Id but we taking Product Name and Price 

        public string ProductName { get; set; } = ""; //in case product name change

        public double Price { get; set; }

        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }

        public string CashierName { get; set; } = "";
    }
}
