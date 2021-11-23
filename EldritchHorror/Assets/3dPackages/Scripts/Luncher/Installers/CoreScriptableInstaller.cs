using EldrtichHorror;
using EldrtichHorror.UserProfile;
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
            HLogger.Log("Core Binding");
            this.Container.BindInterfacesTo<EHJsonConverter>().AsSingle();
            this.Container.BindInterfacesTo<JsonFileOperation>().AsSingle();
        }
    }
}