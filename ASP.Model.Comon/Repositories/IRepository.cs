using ASP.Model.Comon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Comon.Repositories
{
    public interface IRepository<TEntity, TId> : 
        IGetRepository<TEntity,TId>,
        IInsertRepository<TEntity,TId>,
        IUpdateRepository<TEntity,TId>,
        IDeleteRepository<TId>
        where TEntity : IDataModel<TId> where TId : struct
    {
    }
}
