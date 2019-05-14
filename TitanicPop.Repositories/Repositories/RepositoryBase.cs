using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TitanicPop.Domain.Contracts;
using TitanicPop.Domain.Entities;

namespace TitanicPop.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly string _path;

        public RepositoryBase()
        {
            _path = @"C:\Users\kaio_\Downloads\teste_dev_pl\teste_dev_pl\titanic.csv";
        }

        public IEnumerable<TEntity> GetAll()
        {
            var csv = new CsvReader(File.OpenText(_path));
            csv.Configuration.Delimiter = ",";
            csv.Configuration.HasHeaderRecord = true;

            return csv.GetRecords<TEntity>();
        }
    }
}
