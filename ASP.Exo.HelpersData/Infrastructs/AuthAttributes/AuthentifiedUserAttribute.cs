﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.Exo.HelpersData.Infrastructs.AuthAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthentifiedUserAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Utils.SessionUser != null) return true;
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = 
                new RedirectToRouteResult(
                    new RouteValueDictionary { 
                        { "action", "Login" }, 
                        { "controller", "AspUser"}, 
                        { "Area", string.Empty} });
        }
    }
}