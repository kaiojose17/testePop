using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicPop.Domain.Services
{
    public interface IServiceBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
