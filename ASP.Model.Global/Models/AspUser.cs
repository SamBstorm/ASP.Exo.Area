using ASP.Model.Comon.Models;
using System;


namespace ASP.Model.Global.Models
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
    }
}
