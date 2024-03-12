using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using StocksAnalysis.Models;

using StocksAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCase;
using UseCases.TransactionsUseCases;

namespace StocksAnalysis.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
        private readonly ISellProductUseCase _sellProductUseCase;


        //private readonly ICategoriesRepository _categoriesRepository;
        //private readonly IProductsRepository _productsRepository;
        //private readonly ITransactionsRepository _transectionsRepository;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
          
            ISellProductUseCase sellProductUseCase
            )
        {
            _viewCategoriesUseCase = viewCategoriesUseCase;
            _viewSelectedProductUseCase = viewSelectedProductUseCase;
            _sellProductUseCase = sellProductUseCase;
        }
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = _viewCategoriesUseCase.Execute()

            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = _viewSelectedProductUseCase.Execute(productId) ?? new Product();

            return PartialView("_SellProduct", product);
        }
        [HttpPost]
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product


                // saving transections in transectionsRepository  which is generate by flling Sell Quantity Form

                
                _sellProductUseCase.Execute("Cashier1", salesViewModel.SelectedProductId, salesViewModel.QuantityToSell);
                
            }

            //we positing back, if form was submitted with incorrect validation the post method post the data from HTML from
            //it will show validation message, although with after this we would had lost the current selectedProducId

            var product = _viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);

            salesViewModel.SelectedCategoryId = (product?.CategoryId==null)?0:product.CategoryId.Value;  //Selected Category ID not ProductID

            salesViewModel.Categories = _viewCategoriesUseCase.Execute();

            return View("Index", salesViewModel);
        }
    }
}
