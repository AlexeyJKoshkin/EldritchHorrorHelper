#region

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EldritchHorror.Data.Provider
{
    public interface IDataBox<T> : IDataBox where T : class, IDataObject
    {
        IReadOnlyCollection<T> Collection { get; }
    }

    public interface IDataBox : ISerializationCallbackReceiver
    {
        Type ObjectType { get; }

        int Count { get; }

        //у юнити колбэки ISerializationCallbackReceiver приходят ассинхронно и чтобы создать словарь данных приходится вызывать метод при регистрации в хранилищ
        void Reload();
    }
}