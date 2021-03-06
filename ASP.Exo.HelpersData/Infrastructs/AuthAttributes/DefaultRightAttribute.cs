using ASP.Exo.HelpersData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.Exo.HelpersData.Infrastructs.AuthAttributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class DefaultRightAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AspUserService _service = new AspUserService();
            if (Utils.SessionUser is null) return false;
            if (_service.HaveDefaultRight(Utils.SessionUser.Id)) return true;
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
                new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "action", "Register" },
                        { "controller", "AspUser"},
                        { "Area", string.Empty} });
        }
    }
}