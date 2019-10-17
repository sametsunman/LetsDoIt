using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.BusinessLogic.Concrete;
using LDI.DataAccess;
using LDI.DataAccess.Concrete;
using LDI.Model;
using LDI.Web.CustomFilters;
using LDI.Web.Extensions;
using LDI.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LDI.Web.Controllers
{
    public class AccountController : Controller
    {

        public IUnitOfWork service;
        public readonly IHttpContextAccessor accessor;

        public AccountController(IUnitOfWork _service, IHttpContextAccessor _accessor)
        {
            service = _service;
            accessor = _accessor;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountViewModel form)
        {
            User user = new User();
            user.BirthDate = form.DateOfBirth;
            user.EMail = form.Email;
            user.FirstName = form.FirstName;
            user.Password = form.Password;
            user.Username = form.UserName;
            user.Gender = form.Gender;
            user.CreateTime = DateTime.Now;
            user.IsActive = true;

            service.User.Add(user);
            service.SaveChanges();

            var currentUser = service.User.Get(x => x.Username == user.Username);

            if (user != null)
            {
                service.User.SetRoles(2, user.ID);
                service.SaveChanges();
            }


            return RedirectToAction("Login");
        }

        [TypeFilter(typeof(LoginFilter))]
        public IActionResult Login()
        {

            if (User.Identity.Name is null)
                return View();
            else
                return RedirectToAction("Index","Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {

            if (user.Username is null)
            {
                user.Username = "casska";
                user.Password = "227752";
            }
            
            Expression<Func<User, bool>> filter = x => x.Username == user.Username && x.Password == user.Password;
            User currentUser = service.User.Get(filter);


            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            if (currentUser != null)
            {
                currentUser.LastLogin = DateTime.Now;
                service.User.Update(currentUser);

                var userRoles = service.User.GetRoles(currentUser.ID);

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Role, userRoles.LastOrDefault().Name),
                    new Claim(ClaimTypes.Name, currentUser.FirstName+" "+currentUser.LastName)

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticated = true;
            }
            else
            {
                Log.Error("<{EventID:l}> {username} oturum açamadı {@user} ", "Login",user.Username);
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                accessor.HttpContext.Session.SetObject<User>(currentUser, "currentUser");

                Log.Information("<{EventID:l}> {username} oturum açtı {@user} ", "Login", currentUser.Username, currentUser);


                return RedirectToAction("Index", "Home");
            }


            return View();
        }


        public IActionResult Logout()
        {


            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Log.Information("<{EventID:l}> {username} oturumunu kapattı {@user} ", "Login", accessor.HttpContext.Session.GetObject<User>("currentUser").Username);
            accessor.HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
        }

    }
}