using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LDI.Web.Controllers
{
    [EnableCors("AllowAllHeaders")]
    public class AdminController : Controller
    {
        public IUnitOfWork service;

        public AdminController(IUnitOfWork _service)
        {
            service = _service;

        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Categories()
        {

            return PartialView("_Categories");
        }

        public PartialViewResult Users()
        {
            ICollection<User> users = service.User.GetList();
            return PartialView("_Users",users);
        }

        public PartialViewResult DeleteUser(int UserId)
        {
            service.User.Delete(UserId);
            ICollection<User> users = service.User.GetList();
            return PartialView("_Users",users);
        }

        public PartialViewResult Channels()
        {

            return PartialView("_Channels");
        }

        public PartialViewResult Roles()
        {

            return PartialView("_Roles");
        }

        public PartialViewResult Contents()
        {

            return PartialView("_Contents");
        }

    }
}