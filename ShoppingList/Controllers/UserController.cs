using BusinessLayer.Concrete;
using BusinessLayer.Validators;
using DataAccessLayer.Concrete.EntityFramework;
using DTOLayer.DTOs.LoginDTOs;
using Entities;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Models.Validators;


namespace ShoppingList.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login(LoginDTO login)
        {
            LoginValidator validations = new LoginValidator();
            ValidationResult result = validations.Validate(login);
            if (result.IsValid)
            {
                UserManager um = new UserManager(new EfUserRepository());
                User user = um.GetUser(login.UserEmail, login.UserPassword);
                if (user is not null)
                {
                    ClaimManager claim = new();
                    var principal = claim.BuildClaim(user.UserEmail, user.Role.RoleType);
                    await HttpContext.SignInAsync(principal);
                    HttpContext.Session.SetString("userEmail", user.UserEmail);
                    if (user.Role.RoleType == "Admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        
                        return RedirectToAction("Lists", "Home", new { Area = "" });
                    }
                }
            }
            return View();
            
          
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            UserValidator validations = new UserValidator();
            ValidationResult result = validations.Validate(u); 
            if (result.IsValid)
            {
                UserManager user = new UserManager(new EfUserRepository());
                u.RoleId = 1;
                user.Insert(u);
                return RedirectToAction("Login", "User");
            }
            return View();
        }
    }

}
    

