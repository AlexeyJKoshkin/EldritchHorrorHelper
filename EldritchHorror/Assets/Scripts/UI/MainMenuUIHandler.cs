using EldritchHorror.UI;
using EldritchHorror.UserProfile;


namespace EldritchHorror.Core
{
    public class MainMenuUIHandler : StateUIHandler<MainLoopEntity, MainMenuState>
    {
        private readonly IUserSaveProfileStorage _userSaveProfileStorage;

        public MainMenuUIHandler(IEldritchWindowUIProvider windowUiProvider, IUserSaveProfileStorage userSaveProfileStorage) : base(windowUiProvider)
        {
            _userSaveProfileStorage = userSaveProfileStorage;
        }

        public override void HandleEnter(MainLoopEntity entity, MainMenuState mystate)
        {
            base.HandleEnter(entity, mystate);
            var window = Window<StartMenuUIWindow>();
            window.ShowSaves(_userSaveProfileStorage, entity);
            window.Show();
        }

        public override void HandleExit(MainLoopEntity entity, MainMenuState mystate)
        {
            base.HandleExit(entity, mystate);
            Window<StartMenuUIWindow>().Hide();
        }
    }
}