using EldritchHorror.UserProfile;

namespace EldritchHorror {
    public class MainMenuState : MainLoopState
    {
        public override int Order => 10;
        public MainMenuState(IUserSaveProfileStorage userSaveProfileStorage) { }
    }
}