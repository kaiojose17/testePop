using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TitanicaPop.Commom;
using TitanicaPop.Commom.Extensions;
using TitanicPop.Domain.Contracts;
using TitanicPop.Domain.Entities;

namespace TitanicPop.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {        
        public static IEnumerable<TEntity> Data { get; private set; }

        public RepositoryBase()
        {
            Data = ReadFile<TEntity>.GetAll();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Data;
        }
    }
}
