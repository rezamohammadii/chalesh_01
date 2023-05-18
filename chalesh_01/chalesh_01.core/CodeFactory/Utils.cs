using chalesh_01.core.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.CodeFactory
{
    public class Utils
    {
        public static List<UserModelOut> UserList = new List<UserModelOut>();
        public static List<Note> Notes = new List<Note>();
        public static bool HasProperty(JObject obj, string propertyName)
        {
            var checkKey = obj.ContainsKey(propertyName);
            if (!checkKey) return false;
            return true;
        }

        public static string? GetPropertyValue(JObject obj, string propertyName)
        {
            if(string.IsNullOrEmpty(propertyName)) return null;
            obj.TryGetValue(propertyName, out var value);   
            if (value == null) return null;
            return value.ToString();
        }
        public static int RandomId()
        {
            Random random = new Random();
            return random.Next(10, 100);
        }       
    }
}
