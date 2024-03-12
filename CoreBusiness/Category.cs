using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness
{// Core business Means Entities(and entities are not Db these are not dependent on another layer)
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation propertie to associated table
        public List<Product>? Products { get; set; }
    }
}
