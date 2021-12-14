#region

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EldritchHorror.Data.Provider
{
    [Serializable]
    public abstract class DataBox<T> : DataBox, IDataBox<T> where T : class, IDataObject
    {
        [SerializeField, HideInInspector] protected List<T> _collection = new List<T>();

        public override string CollectionName => string.Format("{0}_Data", ObjectType.Name);

        public override void OnBeforeSerialize()
        {
            _collection.RemoveAll(o => ReferenceEquals(o, null));
        }

        public sealed override void Reload() { }

        public override void OnAfterDeserialize() { }

        public override Type ObjectType => typeof(T);
        public override int Count => _collection.Count;


        public IReadOnlyCollection<T> Collection => _collection;

        public void Clear()
        {
            _collection.Clear();
        }
    }


    [Serializable]
    public abstract class DataBox : ScriptableObject, IDataBox, IDataObject
    {
        public virtual string CollectionName => "Empty";

        public virtual Type ObjectType => null;

        public virtual int Count => 0;

        public abstract void Reload();


        public abstract void OnBeforeSerialize();

        public abstract void OnAfterDeserialize();
        public string UniqueID => name;

        public static int DataobjComparer(IDataObject o1, IDataObject o2)
        {
            return string.Compare(o1.UniqueID, o2.UniqueID);
        }
    }
}