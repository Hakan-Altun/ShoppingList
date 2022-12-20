using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.ViewComponents
{
    public class MyList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string value=HttpContext.Session.GetString("userEmail");
            UserManager um = new UserManager(new EfUserRepository());
            User user = um.GetAll().FirstOrDefault(a => a.UserEmail == value);
            ListManager lm = new ListManager(new EfListRepository());
            List<List> lists = lm.GetAll().Where(a => a.UserId == user.UserId).ToList();
           
            return View(lists); 
        }
    }
}
