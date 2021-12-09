using EldritchHorror.Core;
using EldritchHorror.UserProfile;

namespace EldritchHorror
{
    public class InitialEldritchMainState : MainLoopState
    {
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;

        public InitialEldritchMainState(IUserSaveProfileStorage userSaveProfileStorage)
        {
            _userSaveProfileStorage = userSaveProfileStorage;

            
        }

        public override void Enter()
        {
            base.Enter();
            var lastGame = _userSaveProfileStorage.Current;
            HLogger.LogInfo($"Last Game Name {lastGame.Name}\n{lastGame.UserProfileData}");
        }
    }
}