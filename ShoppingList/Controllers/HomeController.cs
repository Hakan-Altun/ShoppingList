using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs.ProductDTOs;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Models.Validators;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ListManager lm = new ListManager(new EfListRepository());
        
        public HomeController(ILogger<HomeController> logger)
        {
           
            _logger = logger;
        }
        public IActionResult Lists()
        {
           
            string value = HttpContext.Session.GetString("userEmail");
            UserManager um=new UserManager(new EfUserRepository());
            User user = um.GetAll().Where(a => a.UserEmail ==value ).FirstOrDefault();
            List<List> list = lm.GetAll().Where(a => a.UserId == user.UserId)
                .OrderBy(a=>a.ListId)
                .Where(a => a.IsDeleted == false).ToList();
            return View(list);
        }
 
        public IActionResult CreateList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateList(List l)
        {
            string value = HttpContext.Session.GetString("userEmail");
            ListValidator validator=new ListValidator();
            ValidationResult result=validator.Validate(l);
            if (result.IsValid)
            {
                UserManager um = new UserManager(new EfUserRepository());
                User user=um.GetAll().Where(a=>a.UserEmail==value).Single();
                if (user is not null)
                {
                    List list = new List();
                    list.UserId = user.UserId;
                    list.ListName = l.ListName;
                    lm.Insert(list);
                    return RedirectToAction("Lists");
                }
            }
            return View();
        }
 
        public IActionResult DeleteList(int id)
        {
            
            List list = lm.GetById(id);
            list.IsDeleted = true;
            lm.Edit(list);
            return RedirectToAction("Lists");
        }
        public IActionResult GetList(int id)
        {
            
            List list = lm.GetById(id);
            return View(list);

        }
        [HttpPost]
        public IActionResult UpdateList(List l)
        {
            ListValidator validator = new ListValidator();
            ValidationResult result = validator.Validate(l);

            if (result.IsValid)
            {
                string value = HttpContext.Session.GetString("userEmail");
                UserManager um = new UserManager(new EfUserRepository());
                User user=um.GetAll().Where(a=>a.UserEmail==value).FirstOrDefault();

                List list = lm.GetAll()
                    .Where(a => a.UserId == user.UserId)
                    .Where(a => a.ListId ==l.ListId)
                    .Single();
                   
                if (!(lm.GetAll().Where(a => a.ListName == l.ListName).SingleOrDefault()==default?false:true))
                {
                    list.ListName = l.ListName;
                    lm.Edit(list);
                    return RedirectToAction("Lists");
                }
                else
                {
                    TempData["Error"] = "Aynı isimde var olan yada daha önceden silinmiş bir liste ismi girilemez";
                }
            }
            return RedirectToAction("GetList", new { id = l.ListId });
        }
        public IActionResult Products(int id)
        {
            TempData["listId"] = id;
            ProductManager pm=new ProductManager(new EfProductRepository());
            List<Product> products = pm.GetAll().ToList();
            return View(products);
        }
      
        public IActionResult AddToList(int id)
        {
            ProductManager pm = new ProductManager(new EfProductRepository());
            Product product = pm.GetAll().Where(a => a.ProductId == id).SingleOrDefault();
            product.ListId = (int)TempData["listId"];
            product.ProductStatus = true;
            pm.Edit(product);
            return RedirectToAction("Lists","Home");
        }
        public IActionResult DeleteFromList(int id)
        {
            ProductManager pm = new ProductManager(new EfProductRepository());
            Product product = pm.GetAll().Where(a => a.ProductId == id).SingleOrDefault();
            product.ProductStatus=false;
            pm.Edit(product);

            return RedirectToAction("Lists","Home");
        }

    }
}