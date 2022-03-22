using System.Collections.Generic;
using System.Linq;
using GameKit;
using UnityEngine;


namespace EldritchHorror.UI
{
    public class EldritchWindowUIStorage : MonoBehaviour, IEldritchWindowUIStorage
    {
        [SerializeField, ReadOnly] private List<EldritchWindow> _windows = new List<EldritchWindow>();

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