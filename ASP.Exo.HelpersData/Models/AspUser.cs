using ASP.Model.Comon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Exo.HelpersData.Models
{
    public class AspUser : IDataModel<int>
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string RegNational { get; set; }
        public string Bio { get; set; }

        public AspUser(int id, string mail, string password, string lastname, string firstname, DateTime birthdate, string regnational, string bio)
        {
            Id = id;
            Mail = mail;
            Password = password;
            LastName = lastname;
            FirstName = firstname;
            BirthDate = birthdate;
            RegNational = regnational;
            Bio = bio;
        }
    }
}