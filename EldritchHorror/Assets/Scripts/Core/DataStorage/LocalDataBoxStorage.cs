#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace EldritchHorror.Data.Provider
{
    public class LocalDataBoxStorage : IDataStorage
    {
        protected readonly Dictionary<Type, IDataBox> _Members;

        public LocalDataBoxStorage(IDataBox[] alDataBoxes)
        {
            _Members = new Dictionary<Type, IDataBox>();
            foreach (var box in alDataBoxes)
            {
                _Members.Add(box.ObjectType, box);
                box.Reload();
            }
        }

        public int CountProviders => _Members.Count;

        public void RegisterProvider(IDataBox provider)
        {
            if (_Members.ContainsKey(provider.ObjectType))
            {
                return;
            }

            _Members.Add(provider.ObjectType, provider);
            provider.Reload();
        }


        protected IDataBox<T> GetMember<T>() where T : class, IDataObject
        {
            IDataBox result = null;
            if (_Members.TryGetValue(typeof(T), out result))
            {
                return result as IDataBox<T>;
            }

            throw new ArgumentException(string.Format("Provider for {0} not registered", typeof(T)));
        }

        #region DataProvider

        public T First<T>() where T : class, IDataObject
        {
            return GetMember<T>()?.Collection.FirstOrDefault();
        }

        public T First<T>(Predicate<T> predicate) where T : class, IDataObject
        {
            return GetMember<T>()?.Collection.FirstOrDefault(predicate.Invoke);
        }

        public IReadOnlyCollection<T> All<T>() where T : class, IDataObject
        {
            return GetMember<T>().Collection;
        }

        public T[] PackById<T>(params string[] ids) where T : class, IDataObject
        {
            return GetMember<T>()?.Collection.Where(o => ids.Contains(o.UniqueID)).ToArray();
        }

        public int Count<T>() where T : class, IDataObject
        {
            return GetMember<T>().Collection.Count;
        }

        public T ById<T>(string id) where T : class, IDataObject
        {
            return All<T>().FirstOrDefault(o => o.UniqueID == id);
        }

        #endregion DataProvider
    }
}