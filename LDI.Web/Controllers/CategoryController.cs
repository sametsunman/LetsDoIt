using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LDI.Web.Controllers
{
    public class CategoryController : Controller
    {

        public IUnitOfWork service;


        public CategoryController(IUnitOfWork _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryAdd()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryAdd(Category category)
        {

            service.Category.Add(category);

            return View();
        }



    }
}