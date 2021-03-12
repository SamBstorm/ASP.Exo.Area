using G = ASP.Model.Global.Models;
using ASP.Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.Exo.HelpersData.Models;

namespace ASP.Exo.HelpersData.Services
{
    public class AspUserService : IAspUserRepository<AspUser, int>
    {
        private IAspUserRepository<G.AspUser, int> _repo;

        public AspUserService()
        {
            _repo = new AspUserRepository("Asp.Exo.DB");
        }

        public int? CheckPassword(string identifier, string password)
        {
            return _repo.CheckPassword(identifier, password);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<AspUser> Get()
        {
            return _repo.Get().Select(userGlobal => userGlobal.ToClient());
        }

        public AspUser Get(int id)
        {
            return _repo.Get(id).ToClient();
        }

        public int Insert(AspUser entity)
        {
            return _repo.Insert(entity.ToGlobal());
        }

        public bool Update(int id, AspUser entity)
        {
            return _repo.Update(id, entity.ToGlobal());
        }
    }
}