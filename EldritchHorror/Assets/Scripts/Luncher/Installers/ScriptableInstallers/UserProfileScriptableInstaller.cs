#region

using EldritchHorror.UserProfile;
using UnityEngine;
using Zenject;

#endregion

namespace EldritchHorror
{
    [CreateAssetMenu(menuName = "Installers/UserProfileScriptable", fileName = "UserProfileScriptableInstaller")]
    public class UserProfileScriptableInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private UserSavePathSettings _settings;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings).AsSingle();
            Container.BindInterfacesTo<UserSaveProfileStorage>().AsSingle();
            Container.BindInterfacesTo<UserProfileSaveFactory>().AsSingle();

            Container.BindInterfacesTo<UserProfileDataCompositeBuilder>().AsSingle();
            Container.BindInterfacesTo<MythosCardSaveSettingsBuilder>().AsSingle();
        }
    }
}