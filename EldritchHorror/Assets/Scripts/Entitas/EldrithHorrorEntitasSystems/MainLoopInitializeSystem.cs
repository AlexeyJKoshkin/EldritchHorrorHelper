using EldritchHorror.UserProfile;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    ///     Инициализация главного игрового цикла
    /// </summary>
    public class MainLoopInitializeSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;

        public MainLoopInitializeSystem(IUserSaveProfileStorage userSaveProfileStorage, Contexts contexts)
        {
            _userSaveProfileStorage = userSaveProfileStorage;
            _contexts = contexts;
        }

        public void Initialize()
        {
            var entity = _contexts.mainLoop.CreateEntity();
            entity.AddUserProfile(_userSaveProfileStorage.Current.UserProfileData);
            entity.isIsReady = true;
        }
    }
}