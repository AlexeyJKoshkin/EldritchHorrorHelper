using System.Collections.Generic;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class CustomEditorInstallersProvider : ScriptableObject
    {
        public IReadOnlyList<BaseCustomEditorInstaller> AvailableInstallers => _allAvailableInstallers;
        [HideInInspector]
        [SerializeField] private List<BaseCustomEditorInstaller> _allAvailableInstallers;
    }
}