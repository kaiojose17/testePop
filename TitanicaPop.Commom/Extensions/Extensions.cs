using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TitanicaPop.Commom.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if(source != null)
            {
                foreach (var obj in source)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool FieldsIsNullOrEmpty<T>(this T obj)
        {
            return !typeof(T).GetProperties().Any(a => a.GetValue(obj) != null);
        }
    }
}
