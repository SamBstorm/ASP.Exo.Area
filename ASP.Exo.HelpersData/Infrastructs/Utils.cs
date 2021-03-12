using ASP.Exo.HelpersData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Exo.HelpersData.Infrastructs
{
    public class Utils
    {
        public static AspUser SessionUser { get {
                return (AspUser)HttpContext.Current.Session["user"];
            }
            set{
                HttpContext.Current.Session["user"] = value;
            } }
    }
}