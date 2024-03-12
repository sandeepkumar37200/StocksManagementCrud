using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using StocksAnalysis.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;

namespace StocksAnalysis.Controllers
{
    public class CategoriesController : Controller
    {
        
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        private readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;
        private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;
        private readonly IEditCategoryUseCase _editCategoryUseCase;

        public CategoriesController(
            IViewCategoriesUseCase viewCategoriesUseCase,
            IAddCategoryUseCase addCategoryUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase, 
            IDeleteCategoryUseCase deleteCategoryUseCase,
            IEditCategoryUseCase editCategoryUseCase
            )
        {
           
           _viewCategoriesUseCase = viewCategoriesUseCase;
            _addCategoryUseCase = addCategoryUseCase;
            _viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
            _editCategoryUseCase = editCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories = _viewCategoriesUseCase.Execute();
            return View(categories);
        }
       
        //If we have not defined what type of action method it is GET,POST,PUT By default this method is Get Method
        public IActionResult Edit(int? id)
        {
            // View bag is a way to pass data from controller to View only
            //using partial view we are giving indication to partial view which functionality i want to use
            ViewBag.Action = "edit";

            var category = _viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);


            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _editCategoryUseCase.Execute(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            return View(category);
           
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(category);

        }
       
        public IActionResult Delete(int categoryId)
        {
            _deleteCategoryUseCase.Execute(categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
