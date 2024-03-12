using CoreBusiness;
using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksAnalysis.ViewModels
{
    //ViewModels Like DTOs the data we receving from user in froms 
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Product Product { get; set; } = new Product();
    }
}
