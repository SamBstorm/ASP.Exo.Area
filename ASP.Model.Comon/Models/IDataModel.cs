using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Model.Comon.Models
{
    public interface IDataModel<TId> where TId: struct
    {
        TId Id { get; }
    }
}
