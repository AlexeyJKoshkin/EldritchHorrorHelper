#region

using EldritchHorror.UserProfile;

#endregion

namespace EldritchHorror
{
    public class InitialEldritchMainState : MainLoopState
    {
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;

        public InitialEldritchMainState(IUserSaveProfileStorage userSaveProfileStorage)
        {
            _userSaveProfileStorage = userSaveProfileStorage;
        }

        public override void Enter(MainLoopEntity stateEntity)
        {
            base.Enter(stateEntity);
            var lastGame = _userSaveProfileStorage.Current;
            HLogger.LogInfo($"Last Game Name {lastGame.Name}\n{lastGame.UserProfileData}");
        }
    }
}