#region

using GameKit;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace EldritchHorror.UI
{
    public class EldritchWindowUIStorage : MonoBehaviour, IEldritchWindowUIStorage, IEldritchWindowUIProvider
    {
        [SerializeField, ReadOnly] private List<EldritchWindow> _windows = new List<EldritchWindow>();

        public T GetWindow<T>() where T : IEldritchWindow
        {
            return (T) AllWindows.FirstOrDefault(o => o is T);
        }

        public IReadOnlyList<IEldritchWindow> AllWindows => _windows;

        private void Awake()
        {
            _windows.ForEach(e => e.Hide());
            _windows[0].Show();
        }

        private void OnValidate()
        {
            _windows = GetComponentsInChildren<EldritchWindow>(true).ToList();
        }
    }
}