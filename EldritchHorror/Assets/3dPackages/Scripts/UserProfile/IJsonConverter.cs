using System;

namespace EldrtichHorror.UserProfile
{
    public interface IJsonConverter
    {
        object Deserialize(string json, Type type);
        string SerializeObject<T>(T obj);
        T Deserialize<T>(string containerJsonString);
    }
}