using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TitanicaPop.Commom.Commom;
using TitanicaPop.Commom.Extensions;
using TitanicPop.Domain.Contracts;
using TitanicPop.Domain.Entities;
using TitanicPop.Domain.Entities.DTO;

namespace TitanicPop.Domain.Services
{
    public class TitanicPopService : ServiceBase<Passenger>, ITitanicPopService
    {
        private ITitanicPopRepository _titanicPopRepository;

        public TitanicPopService(ITitanicPopRepository titanicPopRepository)
            : base(titanicPopRepository)
        {
            _titanicPopRepository = titanicPopRepository;
        }

        public PassengerDTO ObterPassageirosPorSituacao(bool sobreviveram)
        {
            var passengers = _titanicPopRepository.ObterPassageirosPorSituacao(sobreviveram);

            if (passengers.Count() < 1)
                return new PassengerDTO();

            return new PassengerDTO
            {
                Total = passengers.Count(),
                Homens = ObterQuantidadeSex(passengers, Enums.Sexo.Male),
                Mulheres = ObterQuantidadeSex(passengers, Enums.Sexo.Female),
                MediaIdade = ObterMediaIdade(passengers)
            };
        }

        public PassengerPorClasseDTO ObterPassageirosPorClasse()
        {
            var passengers = _titanicPopRepository.GetAll();

            return new PassengerPorClasseDTO()
            {
                Primeira = ObterPassageirosPorClasse(passengers, Enums.Classes.PrimeiraClasse),
                Segunda = ObterPassageirosPorClasse(passengers, Enums.Classes.SegundaClasse),
                Terceira = ObterPassageirosPorClasse(passengers, Enums.Classes.TerceiraClasse)
            };
        }

        public int NumeroPessoasEncontradas(FiltroDTO filtro)
        {
            var result = _titanicPopRepository.ObterPassageirosfiltros(filtro);

            if (!result.Any())
                return default(int);

            return result.Count();
        }

        public void ValidarJson(FiltroDTO filtro, out IList<string> erros)
        {
            erros = new List<string>();

            if (filtro.FieldsIsNullOrEmpty())
            {
                erros.Add("Nenhum campo foi preenchido");
            }
        }

        #region PrivateMethods
        private int ObterQuantidadeSex(IEnumerable<Passenger> passengers, Enums.Sexo sex)
        {
            return passengers
                .Where(w => w.Sex.ToLower() == sex.ToString().ToLower())
                .Count();
        }

        private decimal ObterMediaIdade(IEnumerable<Passenger> passengers)
        {
            return decimal.Round(decimal.Divide(passengers.Select(s => s.Age.To<decimal>()).Sum(), passengers.Count()), 2, MidpointRounding.AwayFromZero);
        } 

        private int ObterPassageirosPorClasse(IEnumerable<Passenger> passengers, Enums.Classes classePassageiros)
        {
            return passengers
                .Where(w => w.Pclass == (int)classePassageiros)
                .Count();
        }
        #endregion
    }
}
