using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicPop.Domain.Entities.DTO
{
    public class PassengerDTO
    {
        public int Total { get; set; }
        public int Homens { get; set; }
        public int Mulheres { get; set; }
        public decimal MediaIdade { get; set; }
    }

    public class PassengerPorClasseDTO
    {
        public int Primeira { get; set; }
        public int Segunda { get; set; }
        public int Terceira { get; set; }
    }
}
