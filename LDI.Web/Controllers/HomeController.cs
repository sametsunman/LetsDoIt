using System.Diagnostics;
using LDI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using LDI.DataAccess.Concrete;
using LDI.Model;
using LDI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using LDI.BusinessLogic.Abstract;
using LDI.Web.CustomFilters;

namespace LDI.Web.Controllers
{
    //[Authorize]

    public class HomeController : Controller
    {
        IUnitOfWork service;
        IHttpContextAccessor accessor;
        public HomeController(IUnitOfWork _service, IHttpContextAccessor _accessor)
        {
            service = _service;
            accessor = _accessor;
        }


        [TypeFilter(typeof(CustomExceptionFilterAttribute))]
        public IActionResult Index()
        {

            //throw new Exception("vcbcvb");

            return View();
        }

 
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
