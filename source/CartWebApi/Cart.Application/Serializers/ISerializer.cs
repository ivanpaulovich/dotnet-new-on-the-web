using System;

namespace Cart.Application.Serializers
{
    public interface ISerializer
    {
        string Serialize(object obj);
        object Deserialize(string value, Type type);
    }
}
