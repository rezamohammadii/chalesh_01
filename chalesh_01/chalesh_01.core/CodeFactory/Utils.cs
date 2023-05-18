using chalesh_01.core.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chalesh_01.core.CodeFactory
{
    public class Utils
    {
        public static ConcurrentQueue<UserModelOut> UserList = new ConcurrentQueue<UserModelOut>();
        public static ConcurrentQueue<Note> Notes = new ConcurrentQueue<Note>();
        public static ConcurrentQueue<JObject> ObjList = new ConcurrentQueue<JObject>();

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
