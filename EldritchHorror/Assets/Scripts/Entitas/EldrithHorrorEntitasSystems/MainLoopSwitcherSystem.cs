#region

using EldritchHorror.Core;
using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public class MainLoopSwitcherSystem : BaseStateEnterExitSystem<MainLoopEntity, IStateMachineState<MainLoopEntity>>
    {
        protected override IMatcher<MainLoopEntity> StateComponentIndex => MainLoopMatcher.MainLoopState;
        public MainLoopSwitcherSystem(IContext<MainLoopEntity> context, IUiHandleDispatcher uiHandleDispatcher) : base(context, uiHandleDispatcher) { }
    }
}