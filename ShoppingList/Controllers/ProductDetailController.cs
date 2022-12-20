using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.Validators;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ProductDetailController : Controller
    {
        public IActionResult ProductDetails(int id)
        {
            ProductDetailManager pdm = new ProductDetailManager(new EfProductDetailRepository());
            ProductDetail pd = pdm.GetAll().FirstOrDefault(a => a.ProductId == id);
            if(pd is null)
            {
                TempData["Error2"] = "Ürün detayı bulunamadı";
                return RedirectToAction("ListProducts", "List", new { id = (int)TempData["listId"] });
            } 
            return View(pd);
        }
        public IActionResult AddProductDetail(int id)
        {
            ProductDetailManager pdm = new ProductDetailManager(new EfProductDetailRepository());
            ProductDetail pd = pdm.GetAll().FirstOrDefault(a => a.ProductId == id);
            ProductManager pm = new ProductManager(new EfProductRepository());
            Product product = pm.GetAll().FirstOrDefault(a => a.ProductId == id);
            if (pd is null)
            {
                ProductDetail productDetail = new ProductDetail();
                productDetail.ProductName = product.ProductName;
                productDetail.ProductImage = product.ProductImage;
                return View(productDetail);
            }
            return View(pd);
        }
        [HttpPost]
        public IActionResult AddProductDetail(ProductDetail pd)
        {
            ProductDetailValidator validator=new ProductDetailValidator();
            ValidationResult result = validator.Validate(pd);
            if (result.IsValid)
            {
                ProductDetailManager pdm = new ProductDetailManager(new EfProductDetailRepository());
                pdm.Insert(pd);
            }
            else
            {
                return View();
            }
            return RedirectToAction("ListProducts", "List", new { id = (int)TempData["listId"] });
        }
    }
}
