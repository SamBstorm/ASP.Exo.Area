using ASP.Model.Global.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Global
{
    public static class Mapper
    {
        public static AspUser DbToModel(IDataRecord reader)
        {
            return new AspUser()
            {
                Id = (int)reader[nameof(AspUser.Id)],
                Mail = (string)reader[nameof(AspUser.Mail)],
                Password = (string)reader[nameof(AspUser.Password)],
                LastName = (string)reader[nameof(AspUser.LastName)],
                FirstName = (string)reader[nameof(AspUser.FirstName)],
                BirthDate = (DateTime)reader[nameof(AspUser.BirthDate)],
                RegNational = (string)reader[nameof(AspUser.RegNational)],
                Bio = (reader[nameof(AspUser.Bio)]==DBNull.Value)?null:(string)reader[nameof(AspUser.Bio)]
            };
        }
    }
}
