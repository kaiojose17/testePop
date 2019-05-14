using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TitanicaPop.Commom.Extensions;
using TitanicPop.Domain.Contracts;
using TitanicPop.Domain.Entities;
using TitanicPop.Domain.Entities.DTO;

namespace TitanicPop.Repositories.Repositories
{
    public class TitanicPopRepository : RepositoryBase<Passenger>, ITitanicPopRepository
    {
        public IEnumerable<Passenger> ObterPassageirosPorSituacao(bool sobreviveram)
        {
            var passengers = Data
                   .Where(w => w.Survived == sobreviveram)
                   .ToArray();

            return passengers;
        }

        public IEnumerable<Passenger> ObterPassageirosfiltros(FiltroDTO filtro)
        {
            IQueryable<Passenger> query = Data.AsQueryable();

            if (filtro.Survived.HasValue)
                query = query.Where(w => w.Survived == filtro.Survived);

            if (!filtro.PClass.IsNullOrEmpty() && filtro.PClass.Any())
                query = query.Where(w => filtro.PClass.Contains(w.Pclass));

            if (!filtro.Sex.IsNullOrEmpty() && filtro.Sex.Any())
                query = query.Where(w => filtro.Sex.Contains(w.Sex));

            if (filtro.Min_Age.HasValue)
                query = query.Where(w => w.Age.To<decimal>() >= filtro.Min_Age);

            if (filtro.Max_Age.HasValue)
                query = query.Where(w => w.Age.To<decimal>() <= filtro.Max_Age);

            return query.ToArray();

        }
    }
}
