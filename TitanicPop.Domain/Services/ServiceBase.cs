using System;
using System.Collections.Generic;
using System.Text;
using TitanicPop.Domain.Contracts;

namespace TitanicPop.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
