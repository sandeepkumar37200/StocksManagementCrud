using CoreBusiness;
using StocksAnalysis.Models;
using StocksAnalysis.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    //ViewModels Like DTOs the data we receving from user in froms 
    public class SalesViewModel
    {
        public int SelectedCategoryId  { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedProductId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1,int.MaxValue)]
        [SalesViewModel_EnsureProperQuantity] // Custom validation Attributes
        public int QuantityToSell { get; set; }
    }
}
