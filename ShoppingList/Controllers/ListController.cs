using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        public IActionResult ListProducts(int id)
        {
          ProductManager pm=new ProductManager(new EfProductRepository());
          List<Product> products=pm.GetAll().Where(a=>a.ListId==id&&a.ProductStatus==true).ToList();
          return View(products);
        }
    }
}
