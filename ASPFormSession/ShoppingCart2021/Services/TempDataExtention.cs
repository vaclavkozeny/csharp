using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utf8Json;
using Utf8Json.Resolvers;

namespace ShoppingCart2021.Services
{
    public static class TempDataExtention
    {
        //JsonSerializer.Set
        public static void Set<T>(this ITempDataDictionary tempdata, string key, T value)
        {
            JsonSerializer.SetDefaultResolver(StandardResolver.AllowPrivateCamelCase);
            tempdata[key] = JsonSerializer.ToJsonString(value);
              
        }
        public static T Get<T>(this ITempDataDictionary tempdata, string key)
        {
            tempdata.TryGetValue(key, out object value);
            return value == null ? default : JsonSerializer.Deserialize<T>((string)value);
        }
        public static void Add(this ITempDataDictionary tempdata, string key, MessageType type, string text)
        {
            var current = tempdata.Get<List<MessageData>>(key);
            if (current == default) current = new List<MessageData>();
            current.Add(new MessageData(type, text));
            tempdata.Set(key, current);

        }
        public static List<MessageData> GetAllMessages(this ITempDataDictionary tempdata, string key)
        {
            return tempdata.Get<List<MessageData>>(key);
        }
    }
    public enum MessageType
    {
        NoType = 0,
        Danger = 1,
        Success,
        Info,
        Warning
    }
    public struct MessageData
    {
        public MessageType Type;
        public string Data;

        public MessageData(MessageType type, string data)
        {
            Type = type;
            Data = data;
        }
    }
}
