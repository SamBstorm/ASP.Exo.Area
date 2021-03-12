using ASP.Exo.HelpersData.Infrastructs;
using ASP.Exo.HelpersData.Infrastructs.AuthAttributes;
using ASP.Exo.HelpersData.Models;
using ASP.Exo.HelpersData.Models.Views;
using ASP.Exo.HelpersData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Exo.HelpersData.Controllers
{
    public class AspUserController : Controller
    {

        [AnonymousUser]
        public ActionResult Register()
        {
            AspUserRegisterForm data = new AspUserRegisterForm();
            return View(data);
        }

        [AnonymousUser]
        [HttpPost]
        public ActionResult Register(AspUserRegisterForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                AspUserService _service = new AspUserService();
                AspUser data = form.ToClient();
                int id = _service.Insert(data);
                ViewBag.id = id;
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return View(form);
            }
        }

        [AnonymousUser]
        public ActionResult Login()
        {
            AspUserLoginForm form = new AspUserLoginForm();
            return View(form);
        }
        [AnonymousUser]
        [HttpPost]
        public ActionResult Login(AspUserLoginForm form)
        {
            try
            {
                ViewBag.Success = true;
                ViewBag.Message = "Success";
                if (!ModelState.IsValid) throw new Exception();
                AspUserService service = new AspUserService();
                int? id = service.CheckPassword(form.Mail, form.Password);
                if(id is null) throw new Exception();
                AspUser user = service.Get((int)id);
                Utils.SessionUser = user;
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Success = false;
                ViewBag.Message = "Failed"; 
                return View(form);
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        [AuthentifiedUser]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}