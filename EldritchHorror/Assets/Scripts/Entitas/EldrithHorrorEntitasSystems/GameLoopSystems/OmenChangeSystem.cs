using Entitas;
using System.Collections.Generic;

namespace EldritchHorror.EntitasSystems
{
    public class OmenChangeSystem : ReactiveSystem<GameLoopEntity>
    {
        public OmenChangeSystem(IContext<GameLoopEntity> context) : base(context)
        {
        }

        protected override ICollector<GameLoopEntity> GetTrigger(IContext<GameLoopEntity> context)
        {
            return context.CreateCollector(GameLoopMatcher.AllOf(GameLoopMatcher.OmenState, GameLoopMatcher.OmenUI));
        }

        protected override bool Filter(GameLoopEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameLoopEntity> entities)
        {
            entities.ForEach(e=> e.omenUI.SetPlace(e.omenState.CurrentState));
        }
    }
}