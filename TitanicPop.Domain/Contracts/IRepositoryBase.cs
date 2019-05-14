using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicPop.Domain.Contracts
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
