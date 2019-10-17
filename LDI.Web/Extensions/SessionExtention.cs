using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDI.Web.Extensions
{
    public static class SessionExtention
    {

        public static void SetObject<T>(this ISession session, T data, string key)
        {
            string value = JsonConvert.SerializeObject(data);
            session.SetString(key,value);

        }

        public static T GetObject<T>(this ISession session, string key)
        {
           string value = session.GetString(key);

            return (String.IsNullOrEmpty(value)? default(T): JsonConvert.DeserializeObject<T>(value));
        }


    }
}
