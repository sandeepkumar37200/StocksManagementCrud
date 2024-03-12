using CoreBusiness;
using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    //ViewModels Like DTOs the data we receving from user in froms 
    public class TransactionViewModel
    {
        [Display(Name ="Cashier Name")]
        public string? CashierName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public IEnumerable<Transaction> Transections { get; set; } = new List<Transaction>();
    }
}
