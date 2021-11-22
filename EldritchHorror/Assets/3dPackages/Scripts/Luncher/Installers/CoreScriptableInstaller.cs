using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    /// <summary>
    /// Install core depends (core scripts, settings)
    /// </summary>
    [CreateAssetMenu(menuName = "Installers/Core", fileName = "CoreInstaller")]
    public class CoreScriptableInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Debug.LogError("Bind Core");
        }
    }
}