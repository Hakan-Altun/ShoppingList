using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Areas.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<Category> categories = cm.GetAll().Where(a=>a.IsDeleted==false).ToList();
            return View(categories);
        }
    }
}
