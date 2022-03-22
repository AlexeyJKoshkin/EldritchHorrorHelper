
using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;



namespace EldritchHorror.Core
{
    public class PrepareGamePhaseStateUiHandler : StateUIHandler<GameLoopEntity, PrepareGamePhase>
    {
        private readonly IEldritchOmen _omen;

        public PrepareGamePhaseStateUiHandler(IEldritchWindowUIProvider windowUiProvider, IEldritchOmen omen) : base(windowUiProvider)
        {
            _omen = omen;
        }

        public override void HandleEnter(GameLoopEntity entity, PrepareGamePhase mystate)
        {
            base.HandleEnter(entity, mystate);
            var window = Window<MainGameUIWindow>();
            InitMainWindow(window, mystate);
        }

        private void InitMainWindow(MainGameUIWindow window, PrepareGamePhase state)
        {
            window.Show();
            window.TurnCounter           = state.Turn;
            window.OmenView.CurrentPlace = _omen.Position;
        }
    }
}