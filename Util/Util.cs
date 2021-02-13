using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Util
{
    public static class Util
    {
        public static T DeserializarObjectParaJson<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static string SerializarObjectParaJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
