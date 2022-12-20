using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.Validators;

namespace ShoppingList.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        public IActionResult Categories()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            ICollection<Category> category = cm.GetAll().OrderBy(a=>a.CategoryId).Where(a=>a.IsDeleted==false).ToList();

            return View(category);
        }
        
        public IActionResult AddCategory()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            CategoryValidator validator= new CategoryValidator();
            ValidationResult result = validator.Validate(c);
            if (result.IsValid)
            {
                CategoryManager cm = new CategoryManager(new EfCategoryRepository());
                Category category = cm.GetByName(c.CategoryName);
               
                if(category is null)
                {
                    cm.Insert(c);
                    return RedirectToAction("Categories");
                }
                else
                {
                    ViewBag.Error = "Silinmiş bir kategori yeniden eklenemez";
                }
            }
            return View();
        }
        
        public IActionResult GetCategory(int id)
        {
            CategoryManager cm=new CategoryManager(new EfCategoryRepository());
            Category category=cm.GetById(id);
            return View(category);
            
        }
       
        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(c);

            if (result.IsValid)
            {
                CategoryManager cm = new CategoryManager(new EfCategoryRepository());
                Category category = cm.GetByName(c.CategoryName);
                if (category is null)
                {
                    cm.Edit(c);
                    return RedirectToAction("Categories");
                }
                else
                {
                    TempData["Error"] = "Aynı isimde var olan yada daha önceden silinmiş bir kategori ismi girilemez";
                }
            }
            return RedirectToAction("GetCategory", new {id=c.CategoryId});
        }
        
        public IActionResult DeleteCategory(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            Category category = cm.GetById(id);
            category.IsDeleted = true;
            cm.Edit(category);
            return RedirectToAction("Categories");
        }

    }
}
