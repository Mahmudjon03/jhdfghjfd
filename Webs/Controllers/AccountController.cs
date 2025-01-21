using Domain.Identity;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Webs.Controllers
{
    public class AccountController:Controller
    {
        readonly private JwtService _jwtService;

        public AccountController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверка логина и пароля
                if (model.Login == "user" && model.Password == "1111")
                {
                    // Создание объекта пользователя
                    var user = new User
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Login = model.Login,
                        Email = "johndoe@example.com",
                        RoleId = 1 // Например, 1 для Admin
                    };

               
                    var token = _jwtService.GenerateToken(user);

                   
                    HttpContext.Response.Cookies.Append("JwtToken", token.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = token.Expiration
                    });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login or password.");
            }

            return View(model);
        }
        
        public IActionResult Logout()
        {
           
            HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Login");
        }


        [Authorize]
        public IActionResult Admin()
        {
            var userName = User.Identity?.Name;
            return View("Admin",userName);
        }

        [HttpGet]
        public IActionResult Registration()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            var userName = User.Identity?.Name;
            return View("Admin", userName);
        }

    }
}
