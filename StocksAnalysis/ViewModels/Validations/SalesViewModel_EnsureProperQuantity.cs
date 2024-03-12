using StocksAnalysis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UseCases.ProductsUseCase;

namespace StocksAnalysis.ViewModels.Validations
{
    // implementing custom validations on Quantity enterd not more than products quantity
    public class SalesViewModel_EnsureProperQuantity: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            if (salesViewModel != null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero");
                }
                else
                {
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;
                   
                    if (getProductByIdUseCase != null)
                    {
                        var product = getProductByIdUseCase.Execute(salesViewModel.SelectedProductId);
                        if (product!=null)
                        {
                            if (product.Quantity < salesViewModel.QuantityToSell)
                            {
                                return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough");
                            }
                        }
                        else
                        {
                            return new ValidationResult("The selected product doesn't exists.");
                        }
                    }
                    
                }
            }
            return ValidationResult.Success;
    
        }
    }
}
