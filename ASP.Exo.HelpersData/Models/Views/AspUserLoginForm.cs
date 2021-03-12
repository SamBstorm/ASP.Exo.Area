using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Exo.HelpersData.Models.Views
{
    public class AspUserLoginForm
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Identifiant", Prompt ="Adresse e-mail")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}