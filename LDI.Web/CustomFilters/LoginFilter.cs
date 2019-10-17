using LDI.Model;
using LDI.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDI.Web.CustomFilters
{
    public class LoginFilter : IActionFilter
    {

        IHttpContextAccessor accessor;

        public LoginFilter(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            User user = accessor.HttpContext.Session.GetObject<User>("currentUser");
            if(context.HttpContext.Request.Path != "/Account/Login")
            context.Result = user != null ? new RedirectResult("/Home/Index") : new RedirectResult("/User/Register");
        }
    }
}
