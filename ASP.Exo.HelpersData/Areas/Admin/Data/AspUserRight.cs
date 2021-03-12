using ASP.Exo.HelpersData.Models;
using ASP.Exo.HelpersData.Services;
using ASP.Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Exo.HelpersData.Areas.Admin.Data
{
    public class AspUserRight
    {
        private IAspUserRepository<AspUser, int> _service;
        public int Id { get; set; }
        [Display(Name="Adresse électronique")]
        public string Mail { get; set; }
        [Display(Name="Prénom")]
        public string FirstName { get; set; }
        [Display(Name="Nom")]
        public string LastName { get; set; }
        [Display(Name="A les droits Administrateur")]
        public bool IsAdmin { get => _service.HaveAdminRight(this.Id); }
        [Display(Name="A les droits par defaut")]
        public bool IsDefault { get => _service.HaveDefaultRight(this.Id); }

        public AspUserRight()
        {
            _service = new AspUserService();
        }

        public AspUserRight(AspUser entity): this()
        {
            Id = entity.Id;
            Mail = entity.Mail;
            LastName = entity.LastName;
            FirstName = entity.FirstName;
        }

        public void ToggleAdminRight()
        {
            if (this.IsAdmin) _service.DenyAdmin(this.Id);
            else _service.GrantAdmin(this.Id);
        }
        public void ToggleDefaultRight()
        {
            if (this.IsDefault) _service.DenyDefault(this.Id);
            else _service.GrantDefault(this.Id);
        }
    }
}