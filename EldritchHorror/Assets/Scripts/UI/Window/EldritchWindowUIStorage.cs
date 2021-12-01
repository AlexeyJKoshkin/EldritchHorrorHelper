using GameKit;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EldritchHorror.UI
{
    public class EldritchWindowUIStorage : MonoBehaviour, IEldritchWindowUIStorage
    {
        [SerializeField, ReadOnly] private List<EldritchWindow> _windows = new List<EldritchWindow>();
        public IReadOnlyList<IEldritchWindow> AllWindows => _windows;

        private void OnValidate()
        {
            _windows = GetComponentsInChildren<EldritchWindow>().ToList();
        }
    }
}