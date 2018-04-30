using System;

namespace TaskRunnerApp.Application.Serializers
{
    public interface ISerializer
    {
        string Serialize(object obj);
        object Deserialize(string value, Type type);
    }
}
