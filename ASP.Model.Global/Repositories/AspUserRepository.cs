using ASP.Model.Comon.Repositories;
using ASP.Model.Global.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.ADO;

namespace ASP.Model.Global.Repositories
{
    public class AspUserRepository : BasicRepository, IAspUserRepository<AspUser, int>
    {
        public AspUserRepository(string connectionStringName):base(connectionStringName)
        {

        }

        public int? CheckPassword(string identifier, string password)
        {
            Command command = new Command("SP_AspUser_CheckPassword", true);
            command.AddParameter("identifier", identifier);
            command.AddParameter("password", password);
            return (int?)_connection.ExecuteScalar(command);
        }

        public bool Delete(int id)
        {
            Command command = new Command("SP_AspUser_Delete", true);
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<AspUser> Get()
        {
            Command command = new Command("SP_AspUser_GetAll", true);
            return _connection.ExecuteReader(command, Mapper.DbToModel);
        }

        public AspUser Get(int id)
        {
            Command command = new Command("SP_AspUser_GetById", true);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, Mapper.DbToModel).SingleOrDefault();
        }

        public int Insert(AspUser entity)
        {
            Command command = new Command("SP_AspUser_Insert", true);
            command.AddParameter("mail", entity.Mail);
            command.AddParameter("password", entity.Password);
            command.AddParameter("lastname", entity.LastName);
            command.AddParameter("firstname", entity.FirstName);
            command.AddParameter("birthdate", entity.BirthDate);
            command.AddParameter("regnational", entity.RegNational);
            command.AddParameter("bio", entity.Bio);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(int id, AspUser entity)
        {
            Command command = new Command("SP_AspUser_Update", true);
            command.AddParameter("id", id);
            command.AddParameter("password", entity.Password);
            command.AddParameter("lastname", entity.LastName);
            command.AddParameter("firstname", entity.FirstName);
            command.AddParameter("birthdate", entity.BirthDate);
            command.AddParameter("regnational", entity.RegNational);
            command.AddParameter("bio", entity.Bio);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
