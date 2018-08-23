using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.COMMON
{
    public static partial class Ext
    {
        public static string EnumToJson(this Type type)
        {
            if (!type.IsEnum)
                throw new InvalidOperationException("enum expected");

            var results =
                Enum.GetValues(type).Cast<object>()
                    .ToDictionary(enumValue => enumValue.ToString(), enumValue => (int)enumValue);
            //return string.Format("{{ \"{0}\" : {1} }}", type.Name, Newtonsoft.Json.JsonConvert.SerializeObject(results));
            return Newtonsoft.Json.JsonConvert.SerializeObject(results);
        }
    }
}
