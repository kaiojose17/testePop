using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TitanicaPop.Commom
{
    public static class ReadFile<TEntity>
    {
        private static readonly Stream _resource = GetFileResource();
        private static readonly CsvReader _csv = GetDataConfiguration();
        private static IEnumerable<TEntity> _data;


        public static IEnumerable<TEntity> GetAll()
        {
            if (Extensions.Extensions.IsNullOrEmpty<TEntity>(_data))
                _data = _csv.GetRecords<TEntity>().ToList();

            return _data;
        }

        private static CsvReader GetDataConfiguration()
        {
            var csv = new CsvReader(new StreamReader(_resource));
            csv.Configuration.Delimiter = ",";
            csv.Configuration.HasHeaderRecord = true;

            return csv;
        }

        private static Stream GetFileResource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceStream("TitanicaPop.Commom.Resources.titanic.csv");

            return resource;
        }
    }
}
