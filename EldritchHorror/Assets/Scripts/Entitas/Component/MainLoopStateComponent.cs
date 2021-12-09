using EldritchHorror.Core;
using EldritchHorror.UI;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace EldritchHorror.Entitas.Components
{
    public abstract class StateHolderComponent<T,TEntity> : IStateMachineState<TEntity> where T : IStateMachineState<TEntity> where TEntity:class, IEntity
    {
        public T Current;
        public void Exit()
        {
            Current?.Exit();
        }

        public void Enter()
        {
            Current?.Enter();
        }
    }
    
    public abstract class WindowBindingComponent<T> : IComponent where T : class, IEldritchWindow
    {
        public T Window;
    }

    [MainLoop, Unique]
    public class MainLoopStateComponent :StateHolderComponent<IGameLoopState, MainLoopEntity>, IComponent
    {
    }


    [MainLoop, MythosCard, GameLoop]
    public class IsReady : IComponent
    {
    }
}