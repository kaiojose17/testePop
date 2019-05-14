using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TitanicPop.Domain.Entities;
using TitanicPop.Domain.Entities.DTO;

namespace TitanicPop.Domain.Services
{
    public interface ITitanicPopService : IServiceBase<Passenger>
    {
        PassengerDTO ObterPassageirosPorSituacao(bool sobreviveram);
        PassengerPorClasseDTO ObterPassageirosPorClasse();
        int NumeroPessoasEncontradas(FiltroDTO filtro);
        void ValidarJson(FiltroDTO filtro, out IList<string> erros);
    }
}
