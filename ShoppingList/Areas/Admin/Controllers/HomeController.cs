using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs.CategoryDTOs;

namespace ShoppingList.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
	public class HomeController : Controller
	{
        [HttpGet]
		public IActionResult Index()
		{

			return View();
		}

        public JsonResult CatList()
        
        {

            List<CategoryList> categoryList = new List<CategoryList>();
            categoryList.Add(new CategoryList
            {
                category = "ABC",
                product=10
              
            });
            categoryList.Add(new CategoryList
            {
                category = "DAD",
                product = 50
            });
            return Json(new { jsonlist = categoryList });
        }
    }
}
