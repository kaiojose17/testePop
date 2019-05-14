using System;

namespace TitanicaPop.Commom
{
    public static class ApiConstants
    {
        public class Routes
        {
            public class WebApi
            {
                public const string BaseUri = "api/resumo";

                public class Resources
                {
                    public const string Sobreviventes = "sobreviventes";
                    public const string Morreram = "morreram";
                    public const string Classe = "classe";
                }                
            }
        }
    }
}
