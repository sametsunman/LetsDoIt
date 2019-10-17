using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.BusinessLogic.Concrete;
using LDI.DataAccess;
using LDI.DataAccess.Concrete;
using LDI.Model;
using LDI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LDI.Web.Controllers
{
    public class VideoController : Controller
    {

        public IUnitOfWork service;

        public VideoController(IUnitOfWork _service)
        {
            service = _service;

        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(int id)
        {


            Category category = service.Category.GetCategory(x => x.ID == id);
            if(category != null)
            ViewBag.PageName = category.Name;

            return View(service.Content.GetByCategory(id));
        }

        public IActionResult Channel(int id)
        {

            Channel channel = service.Channel.Get(x => x.ID == id);

            if (channel != null)
                ViewBag.PageName = channel.Name;

            return View(service.Content.GetByChannel(id));
        }

        public IActionResult Watch(int id)
        {
            ContentViewModel content = new ContentViewModel();
            Content co = service.Content.GetContent(id);
            Media me = service.Media.GetMedia(co.ID);
            Channel ch = service.Channel.Get(x=> x.ID==co.ChannelID);
            Category ca = service.Category.GetCategory(x=>x.ID==co.CategoryID);


            content.Category = ca.Name;
            content.Channel = ch.Name;
            content.CreateTime = co.CreateTime;
            content.Description = co.Description;
            content.Path = me.Path;
            content.Rating = co.Rating;
            content.Title = co.Title;
            content.Type = me.Type;
            content.Views = co.Views;

            return View(content);
        }


    }
}