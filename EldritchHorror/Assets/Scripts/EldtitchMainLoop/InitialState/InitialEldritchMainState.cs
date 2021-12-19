#region

using EldritchHorror.Core;
using EldritchHorror.UI;
using EldritchHorror.UserProfile;

#endregion

namespace EldritchHorror
{
    /// <summary>
    /// Инициализация игры
    /// </summary>
    public class InitialEldritchMainState : MainLoopState
    {
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;

        protected override void OnEnter(MainLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
            var lastGame = _userSaveProfileStorage.Current;
            HLogger.LogInfo($"Last Game Name {lastGame.Name}\n{lastGame.UserProfileData}");
            stateEntity.isIsReady = true;
        }

        public InitialEldritchMainState(IUserSaveProfileStorage userSaveProfileStorage)
        {
            _userSaveProfileStorage = userSaveProfileStorage;
        }
    }

    //показ главного меню
}

