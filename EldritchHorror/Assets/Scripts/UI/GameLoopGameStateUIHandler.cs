using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.Core
{
    public class GameLoopGameStateUIHandler : StateUIHandler<MainLoopEntity, GameLoopGameState>
    {
        private readonly EldritchCardContext _eldritchCardContext;
        private readonly GameLoopContext _gameLoopContext;

        private IGroup<EldritchCardEntity> _inprocessCardGroup;

        public GameLoopGameStateUIHandler(IEldritchWindowUIProvider windowUiProvider, GameLoopContext gameLoopContext, EldritchCardContext eldritchCardContext) : base(windowUiProvider)
        {
            _gameLoopContext     = gameLoopContext;
            _eldritchCardContext = eldritchCardContext;
            _inprocessCardGroup  = eldritchCardContext.GetGroup(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Mythos, EldritchCardMatcher.InProcessType));
        }

        public override void HandleEnter(MainLoopEntity entity, GameLoopGameState mystate)
        {
            base.HandleEnter(entity, mystate);
            var window = Window<MainGameUIWindow>();
            Preparewindow(window, mystate, entity);
            _inprocessCardGroup.OnEntityAdded   += InprocessCardGroupOnOnEntityAdded;
            _inprocessCardGroup.OnEntityRemoved += InprocessCardGroupOnOnEntityRemoved;
        }

        private void Preparewindow(MainGameUIWindow window, GameLoopGameState mystate, MainLoopEntity mainLoopEntity)
        {
            HLogger.LogError($"Тут надо включать/выключать UI в зависимости от тип игрока {mainLoopEntity.playerRole}");
            window.Show();
            window.SubScribeMasterEntityEvents(_gameLoopContext.masterEntityEntity);
        }

        public override void HandleExit(MainLoopEntity entity, GameLoopGameState mystate)
        {
            base.HandleExit(entity, mystate);
            _inprocessCardGroup.OnEntityAdded   -= InprocessCardGroupOnOnEntityAdded;
            _inprocessCardGroup.OnEntityRemoved -= InprocessCardGroupOnOnEntityRemoved;
        }

        private void InprocessCardGroupOnOnEntityRemoved(IGroup<EldritchCardEntity> group, EldritchCardEntity entity, int index, IComponent component)
        {
            foreach (var view in Window<MainGameUIWindow>().RumorCardViews)
                if (view.Current == entity)
                {
                    view.Bind(null);
                }
        }

        private void InprocessCardGroupOnOnEntityAdded(IGroup<EldritchCardEntity> group, EldritchCardEntity entity, int index, IComponent component)
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