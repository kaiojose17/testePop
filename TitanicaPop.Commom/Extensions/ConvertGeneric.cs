using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicaPop.Commom.Extensions
{
    public static class ConvertGeneric
    {
        public static T To<T>(this object obj)
        {
            if (!string.IsNullOrEmpty(obj?.ToString()))
                return (T)Convert.ChangeType(obj, typeof(T));
            else return default(T);
        }
    }
}
