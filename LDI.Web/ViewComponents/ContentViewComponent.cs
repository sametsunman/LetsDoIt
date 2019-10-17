using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDI.Web.ViewComponents
{
    [ViewComponent]
    public class ContentViewComponent : ViewComponent
    {
        IUnitOfWork service;

        public ContentViewComponent(IUnitOfWork _service)
        {
            service = _service;
        }

        public ViewViewComponentResult Invoke(int IDx, string type)
        {
            IList<Content> contents;

            if(type=="channel")
            contents = service.Content.GetByChannel(IDx);
            else
            contents = service.Content.GetByCategory(IDx);


            return View(contents);

        }

    }
}
