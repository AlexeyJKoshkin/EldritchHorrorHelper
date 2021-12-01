using System;
using System.Collections.Generic;
using Zenject.ReflectionBaking.Mono.Collections.Generic;

namespace EldritchHorror.Data.Provider
{
    public interface IDataStorage
    {
        T First<T>() where T : class, IDataObject;

        T ById<T>(string id) where T : class, IDataObject;

        T[] PackById<T>(params string[] ids) where T : class, IDataObject;

        int Count<T>() where T : class, IDataObject;

        T First<T>(Predicate<T> predicate) where T : class, IDataObject;

        IReadOnlyCollection<T> All<T>() where T : class, IDataObject;
    }

    public interface IDataObject
    {
        string UniqueID { get; }
    }
}