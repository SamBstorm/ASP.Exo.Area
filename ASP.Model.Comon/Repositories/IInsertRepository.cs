using ASP.Model.Comon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Comon.Repositories
{
    public interface IInsertRepository<TEntity, TId> where TEntity : IDataModel<TId> where TId : struct
    {
        TId Insert(TEntity entity);
    }
}
