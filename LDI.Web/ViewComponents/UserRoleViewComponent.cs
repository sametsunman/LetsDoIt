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
    public class UserRoleViewComponent : ViewComponent
    {
        IUnitOfWork service;

        public UserRoleViewComponent(IUnitOfWork _service)
        {
            service = _service;
        }

        public ViewViewComponentResult Invoke(int IDx)
        {
            IList<Role> roles;

            roles = service.User.GetRoles(IDx);

            return View(roles);

        }

    }
}
