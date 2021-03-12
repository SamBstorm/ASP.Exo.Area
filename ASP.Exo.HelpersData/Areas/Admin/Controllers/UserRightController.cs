using ASP.Exo.HelpersData.Areas.Admin.Data;
using ASP.Exo.HelpersData.Infrastructs.AuthAttributes;
using ASP.Exo.HelpersData.Models;
using ASP.Exo.HelpersData.Services;
using ASP.Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Exo.HelpersData.Areas.Admin.Controllers
{
    [AdminRight]
    public class UserRightController : Controller
    {
        private IAspUserRepository<AspUser, int> _service;

        public UserRightController()
        {
            _service = new AspUserService();
        }
        // GET: Admin/UserRight
        public ActionResult Index()
        {
            IEnumerable<AspUserRight> datas = _service.Get().Select(u=> new AspUserRight(u));
            return View(datas);
        }

        public ActionResult ToggleAdminRight(int id)
        {
            if (_service.HaveAdminRight(id)) _service.DenyAdmin(id);
            else _service.GrantAdmin(id);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleDefaultRight(int id)
        {
            if (_service.HaveDefaultRight(id)) _service.DenyDefault(id);
            else _service.GrantDefault(id);
            return RedirectToAction("Index");
        }
    }
}