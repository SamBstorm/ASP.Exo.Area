using ASP.Model.Comon.Models;
using ASP.Model.Comon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Global.Repositories
{
    public interface IAspUserRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IDataModel<TId> where TId: struct
    {
        TId? CheckPassword(string identifier, string password);
    }
}
