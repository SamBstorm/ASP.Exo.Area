using ASP.Model.Comon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Comon.Repositories
{
    public interface IGetRepository<TEntity,TId> where TEntity : IDataModel<TId> where TId : struct
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
    }
}
