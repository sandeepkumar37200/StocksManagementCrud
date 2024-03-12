using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Category")]

        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Price { get; set; }

        //? specifies that sometimes Category can be null
        public Category? Category { get; set; }
    }
}
