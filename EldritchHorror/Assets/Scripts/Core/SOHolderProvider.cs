#region

using EldritchHorror.Data.Provider;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    public abstract class SOHolderProvider<T> : ScriptableObject, IDataBox<T> where T : ScriptableObject, IDataObject
    {
        [SerializeField] private List<T> _items = new List<T>();
        [SerializeField, FolderPath] private string _path = "";
        public string Path => _path;

        public T this[string key] => _items.FirstOrDefault(o => o.UniqueID == key);

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() { }

        public Type ObjectType => typeof(T);
        public int Count => _items.Count;

        [Button, HideIf("_path", "")]
        public void Reload()
        {
#if UNITY_EDITOR
            _items = new List<T>(GameKit.Editor.EditorUtils.LoadAllAssetsAtPath<T>(_path));
#endif
        }

        public IReadOnlyCollection<T> Collection => _items;
    }
}