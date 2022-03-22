#region

using EldritchHorror.GameplayStateMachine;
using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public interface ITurnPhaseSwitcherSystem
    {
        void NewTurn();
    }

    public class TurnPhaseSwitcherSystem : CycleStateSwitcher<GameLoopEntity, IGameRoundPhase>, ITurnPhaseSwitcherSystem
    {
        private readonly GameLoopContext _context;

        public TurnPhaseSwitcherSystem(GameLoopContext context, IGameRoundPhase[] phases) : base(context, phases)
        {
            _context = context;
        }

        public void NewTurn()
        {
            StateBox.Reset();
            var entity = _context.CreateEntity();
            HandleNextPhase(StateBox.GetNext(), entity);
        }

        protected override IMatcher<GameLoopEntity> ReadyStateMatcher => Matcher<GameLoopEntity>.AllOf(GameLoopMatcher.PhaseReady, GameLoopMatcher.CurrentGamePhase);

        protected override bool Filter(GameLoopEntity entity)
        {
            return entity.isPhaseReady;
        }


        protected override void HandleNextPhase(IGameRoundPhase nextState, GameLoopEntity gameLoopEntity)
        {
            if (nextState == null)
            {
                gameLoopEntity.RemoveCurrentGamePhase();
                gameLoopEntity.Destroy();
                NewTurn();
            }
            else
            {
                gameLoopEntity.isPhaseReady = false;
                gameLoopEntity.ReplaceCurrentGamePhase(nextState);
            }
        }
    }
}