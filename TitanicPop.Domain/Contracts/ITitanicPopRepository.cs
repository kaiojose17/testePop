using System;
using System.Collections.Generic;
using System.Text;
using TitanicPop.Domain.Entities;
using TitanicPop.Domain.Entities.DTO;

namespace TitanicPop.Domain.Contracts
{
    public interface ITitanicPopRepository : IRepositoryBase<Passenger>
    {
        IEnumerable<Passenger> ObterPassageirosPorSituacao(bool sobreviveram);
        IEnumerable<Passenger> ObterPassageirosfiltros(FiltroDTO filtro);
    }
}
