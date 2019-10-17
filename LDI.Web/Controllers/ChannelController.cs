using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LDI.DataAccess;
using LDI.DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using LDI.Model;
using LDI.BusinessLogic.Concrete;
using LDI.BusinessLogic.Abstract;

namespace LDI.Web.Controllers
{
    public class ChannelController : Controller
    {

        public IUnitOfWork service;

        public ChannelController(IUnitOfWork _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {

            ICollection<Channel> channels = service.Channel.GetList();

            return View(channels);
        }

        public IActionResult Panel()
        {


            return View();
        }
    }
}