namespace Cart.Infrastructure.Serializers
{
    using System;
    using Newtonsoft.Json;
    using Cart.Application.Serializers;

    public class Serializer : ISerializer
    {
        public string Serialize(object value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            return json;
        }

        public object Deserialize(string value, Type type)
        {
            object obj = JsonConvert.DeserializeObject(value, type);
            return obj;
        }
    }
}
