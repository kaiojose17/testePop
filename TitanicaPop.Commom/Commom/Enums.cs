using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TitanicaPop.Commom.Commom
{
    public class Enums
    {
        public enum Classes
        {
            [Display(Description = "Passageiros de primeira classe")]
            PrimeiraClasse = 1,
            [Display(Description = "Passageiros de segunda classe")]
            SegundaClasse = 2,
            [Display(Description = "Passageiros de terceira classe")]
            TerceiraClasse = 3
        }

        public enum Sexo
        {
            [Display(Description = "Sexo Masculino")]
            Male,
            [Display(Description = "Sexo Feminino")]
            Female,
        }
    }
}
