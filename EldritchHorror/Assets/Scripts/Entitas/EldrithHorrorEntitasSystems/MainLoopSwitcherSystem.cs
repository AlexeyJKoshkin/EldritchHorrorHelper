#region

using EldritchHorror.Core;
using EldritchHorror.EntitasSystems;
using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public interface IUiHandleDispatcher
    {
        void HandleExit<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>;
        void HandleEnter<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>;
    }


    public class MainLoopSwitcherSystem : BaseStateEnterExitSystem<MainLoopEntity, IStateMachineState<MainLoopEntity>>
    {
        protected override IMatcher<MainLoopEntity> StateComponentIndex => MainLoopMatcher.MainLoopState;
        public MainLoopSwitcherSystem(IContext<MainLoopEntity> context, IUiHandleDispatcher uiHandleDispatcher) : base(context, uiHandleDispatcher) { }
    }
}