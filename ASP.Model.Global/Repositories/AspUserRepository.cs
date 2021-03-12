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
        public AspUserRepository(string connectionStringName) : base(connectionStringName)
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

        public void DenyAdmin(int id)
        {
            Command command = new Command("SP_UserRight_DenyAdmin", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }

        public void DenyDefault(int id)
        {
            Command command = new Command("SP_UserRight_DenyDefault", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
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

        public void GrantAdmin(int id)
        {
            Command command = new Command("SP_UserRight_GrantAdmin", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }

        public void GrantDefault(int id)
        {
            Command command = new Command("SP_UserRight_GrantDefault", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }

        public bool HaveAdminRight(int id)
        {
            Command command = new Command("SP_AspUser_HaveAdminRight", true);
            command.AddParameter("userid", id);
            return ((int?)_connection.ExecuteScalar(command) is null) ? false : true;
        }

        public bool HaveDefaultRight(int id)
        {
            Command command = new Command("SP_AspUser_HaveDefaultRight", true);
            command.AddParameter("userid", id);
            return ((int?)_connection.ExecuteScalar(command) is null) ? false : true;
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
