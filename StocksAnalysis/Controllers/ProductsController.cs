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

namespace StocksAnalysis.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IViewProductsUseCase _viewProductsUseCase;
        private readonly IAddProductUseCase _addProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;
        private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
        private readonly IEditProductUseCase _editProductUseCase;
        private readonly IViewProductsInCategoryUseCase _viewProductsInCategoryUseCase;
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        

        public ProductsController(
            IViewProductsUseCase viewProductsUseCase,
            IAddProductUseCase addProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IEditProductUseCase editProductUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase
            )
        {
            _viewProductsUseCase = viewProductsUseCase;
            _addProductUseCase = addProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _viewSelectedProductUseCase = viewSelectedProductUseCase;
            _editProductUseCase = editProductUseCase;
            _viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
            _viewCategoriesUseCase = viewCategoriesUseCase;
           
        }
        public IActionResult Index()
        {
            var products = _viewProductsUseCase.Execute();
            //passing product List to view.
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModel = new ProductViewModel
            {
                Categories = _viewCategoriesUseCase.Execute()
            };
            return View(productViewModel);
        }


        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _addProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            // re-populating the model
            ViewBag.Action = "add";
            productViewModel.Categories = _viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        // this edit method call from view (Edit View) and also restun view
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewMdel = new ProductViewModel
            {
                //?? handle nulable values
                Product = _viewSelectedProductUseCase.Execute(id) ?? new Product(),
                Categories = _viewCategoriesUseCase.Execute()
            };
            return View(productViewMdel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {    var product = productViewModel.Product;

                _editProductUseCase.Execute(product, product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productViewModel.Categories = _viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Delete(int productId) 
        {
            _deleteProductUseCase.Execute(productId);
            return RedirectToAction(nameof(Index));
        }

        // Loading List of products by category in Sales index View 
        // it will returns partial view result
        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = _viewProductsInCategoryUseCase.Execute(categoryId);
            
            // here we are not reloding the whole page we just loading partial view 
            return PartialView("_Products", products);
        }

       


    }
}
