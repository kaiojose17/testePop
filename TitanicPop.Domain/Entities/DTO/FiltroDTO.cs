using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicPop.Domain.Entities.DTO
{
    public class FiltroDTO
    {
        public bool? Survived { get; set; }
        public int[] PClass { get; set; }
        public string[] Sex { get; set; }
        public int? Min_Age { get; set; }
        public int? Max_Age { get; set; }
    }
}
