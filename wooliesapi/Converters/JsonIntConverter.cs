using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WooliesX.Exercises
{
    // Some issue with json parsing making double of int quantity, hence using this converter. 
    // todo: investigate why
    public class ParseNumbersAsInt32Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(long?) || objectType == typeof(double);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null && (reader.Value is long || reader.Value is double || reader.Value is decimal))
            {
                return Convert.ToInt32(reader.Value.ToString());
            }
            return reader.Value;
        }
    }
}