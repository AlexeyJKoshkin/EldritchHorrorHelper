using Entitas;
using System.Collections.Generic;

namespace EldritchHorror.EntitasSystems
{
    public class MainLoopSwitcherSystem : ReactiveSystem<MainLoopEntity>
    {
        private IGameLoopState[] _allMainStates;

        public MainLoopSwitcherSystem(IContext<MainLoopEntity> context, IGameLoopState[] allMainStates) : base(context)
        {
            _allMainStates = allMainStates;
        }

        protected override ICollector<MainLoopEntity> GetTrigger(IContext<MainLoopEntity> context)
        {
            return context.CreateCollector(Matcher<MainLoopEntity>.AllOf(MainLoopMatcher.MainLoopState));
        }

        protected override bool Filter(MainLoopEntity entity)
        {
            return true;
        }

        protected override void Execute(List<MainLoopEntity> entities)
        {
            var current = entities.SingleEntity();
            HLogger.Log(current.mainLoopState?.CurrentState?.GetType().ToString());
        }
    }
}