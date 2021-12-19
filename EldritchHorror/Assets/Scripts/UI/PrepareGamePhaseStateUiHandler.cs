using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.Core {
    public class PrepareGamePhaseStateUiHandler : StateUIHandler<GameLoopEntity, PrepareGamePhase> {
        private readonly IEldritchOmen _omen;

        public PrepareGamePhaseStateUiHandler(IEldritchWindowUIProvider windowUiProvider, IEldritchOmen omen) : base(windowUiProvider)
        {
            _omen = omen;
        }

        public override void HandleEnter(GameLoopEntity entity, PrepareGamePhase mystate)
        {
            base.HandleEnter(entity, mystate);
            var window = Window<MainGameUIWindow>();
            InitMainWindow(window,mystate);
        }

        private void InitMainWindow(MainGameUIWindow window, PrepareGamePhase state)
        {
            window.Show();
            window.TurnCounter = state.Turn;
            window.OmenView.CurrentPlace = _omen.Position;
        }
    }

    public class GameLoopGameStateUIHandler : StateUIHandler<MainLoopEntity, GameLoopGameState> {
        private readonly GameLoopContext _gameLoopContext;
        private readonly EldritchCardContext _eldritchCardContext;

        private IGroup<EldritchCardEntity> _inprocessCardGroup;

        public GameLoopGameStateUIHandler(IEldritchWindowUIProvider windowUiProvider, GameLoopContext gameLoopContext, EldritchCardContext eldritchCardContext) : base(windowUiProvider)
        {
            _gameLoopContext = gameLoopContext;
            _eldritchCardContext = eldritchCardContext;
            _inprocessCardGroup = eldritchCardContext.GetGroup(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Mythos, EldritchCardMatcher.InProcessType));
        }

        public override void HandleEnter(MainLoopEntity entity, GameLoopGameState mystate)
        {
            base.HandleEnter(entity, mystate);
            var window = Window<MainGameUIWindow>();
            Preparewindow(window, mystate, entity);
            _inprocessCardGroup.OnEntityAdded  += InprocessCardGroupOnOnEntityAdded;
            _inprocessCardGroup.OnEntityRemoved += InprocessCardGroupOnOnEntityRemoved;
        }

      

        private void Preparewindow(MainGameUIWindow window, GameLoopGameState mystate, MainLoopEntity entity)
        {
            window.Show();
            window.SubScribeMasterEntityEvents(_gameLoopContext.masterEntityEntity);
        }

        public override void HandleExit(MainLoopEntity entity, GameLoopGameState mystate)
        {
            base.HandleExit(entity, mystate);
            _inprocessCardGroup.OnEntityAdded   -= InprocessCardGroupOnOnEntityAdded;
            _inprocessCardGroup.OnEntityRemoved -= InprocessCardGroupOnOnEntityRemoved;
        }
        
        private void InprocessCardGroupOnOnEntityRemoved(IGroup<EldritchCardEntity> @group, EldritchCardEntity entity, int index, IComponent component)
        {
            foreach (var view in Window<MainGameUIWindow>().RumorCardViews)
            {
                if (view.Current == entity)
                {
                    view.Bind(null);
                }
            }
         
        }

        private void InprocessCardGroupOnOnEntityAdded(IGroup<EldritchCardEntity> @group, EldritchCardEntity entity, int index, IComponent component)
        {
            foreach (var view in Window<MainGameUIWindow>().RumorCardViews)
            {
                if (view.Current != null)
                {
                    continue;
                }
                view.Bind(entity);
                return;
            }
        }

        
    }

}