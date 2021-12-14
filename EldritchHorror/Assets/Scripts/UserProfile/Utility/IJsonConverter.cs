#region

using System;

#endregion

namespace EldritchHorror.UserProfile
{
    public interface IJsonConverter
    {
        object Deserialize(string json, Type type);
        string SerializeObject<T>(T obj);
        T Deserialize<T>(string containerJsonString);
    }
}