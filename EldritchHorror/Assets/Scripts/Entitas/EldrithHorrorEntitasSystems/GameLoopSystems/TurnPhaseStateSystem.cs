#region

using EldritchHorror.GameplayStateMachine;
using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    ///     Переключаем фазы во время хода
    /// </summary>
    public class TurnPhaseStateSystem : BaseStateEnterExitSystem<GameLoopEntity, IGameRoundPhase>
    {
        protected override IMatcher<GameLoopEntity> StateComponentIndex => GameLoopMatcher.CurrentGamePhase;
        public TurnPhaseStateSystem(IContext<GameLoopEntity> context, IUiHandleDispatcher uiHandleDispatcher) : base(context, uiHandleDispatcher) { }
    }
}