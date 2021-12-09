using EldritchHorror.GameplayStateMachine;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    /// Переключаем фазы во время хода
    /// </summary>
    public class TurnPhaseStateSystem : BaseStateEnterExitSystem<GameLoopEntity, IGameRoundPhase>
    {
        public TurnPhaseStateSystem(IContext<GameLoopEntity> context) : base(context)
        {
        }

        protected override int StateComponentIndex => GameLoopComponentsLookup.CurrentGamePhase;
    }
}