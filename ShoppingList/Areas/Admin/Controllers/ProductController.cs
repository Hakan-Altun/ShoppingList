using BusinessLayer.Concrete;
using BusinessLayer.Validators;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs.CategoryDTOs;
using DTOLayer.DTOs.ProductDTOs;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Shop.Models.Validators;


namespace ShoppingList.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Products()
        {
            ProductManager pm = new ProductManager(new EfProductRepository());
            ICollection<ProductRequestDTO> list = pm.GetAll().Where(a => a.IsDeleted == false)
                .Select(a => new ProductRequestDTO
                {
                    ProductId = a.ProductId,
                    CategoryName = a.CategoryName,
                    ProductName = a.ProductName,
                    ProductImage = a.ProductImage,
                    ProductDetailId = a.ProductDetailId,

                }).ToList();
            return View(list);
        }
        public IActionResult GetProduct(int id)
        {
            ProductManager pm = new ProductManager(new EfProductRepository());
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<Category> list = cm.GetAll().Where(a => a.IsDeleted == false).ToList();
            ProductRequestDTO product = new ProductRequestDTO()
            {

                ProductId = pm.GetById(id).ProductId,
                ProductDetailId = pm.GetById(id).ProductDetailId,
                CategoryName = pm.GetById(id).CategoryName,
                ProductImage=pm.GetById(id).ProductImage,
                ProductName = pm.GetById(id).ProductName,
                CategoryNames = list
            };
            return View(product);
        }
        public IActionResult UpdateProduct(Product p)
        {
            ProductValidator validator = new ProductValidator();
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                ProductManager pm = new ProductManager(new EfProductRepository());
                Product product = pm.GetByName(p.ProductName);
                if (product is not null && p.CategoryName != product.CategoryName)
                {

                    pm.Edit(p);
                    return RedirectToAction("Products");
                }
                else if (product is null)
                {
                   
                    pm.Edit(p);
                    return RedirectToAction("Products");

                }
                else
                {
                    TempData["Error"] = "Aynı isimde var olan yada daha önceden silinmiş bir ürün ismi girilemez";
                }
            }
            return RedirectToAction("GetProduct", new { id = p.ProductId });
        }
        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validator = new ProductValidator();
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                ProductManager pm = new ProductManager(new EfProductRepository());
                Product prod = pm.GetByName(p.ProductName);
                if (prod is null)
                {
                       
                    pm.Insert(p);
                    
                    return RedirectToAction("Products");
                }
                else
                {
                    ViewBag.Error = "Silinmiş bir ürün yeniden eklenemez";
                }
            }
            return View();

        }
        public IActionResult DeleteProduct(int id)
        {
            ProductManager pm = new ProductManager(new EfProductRepository());
            Product product = pm.GetById(id);
            product.IsDeleted = true;
            pm.Edit(product);
            return RedirectToAction("Products");

        }
       
    }
}
