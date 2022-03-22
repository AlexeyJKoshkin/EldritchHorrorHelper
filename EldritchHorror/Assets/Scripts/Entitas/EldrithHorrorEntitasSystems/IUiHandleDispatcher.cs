using EldritchHorror.Core;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    public interface IUiHandleDispatcher
    {
        void HandleExit<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>;
        void HandleEnter<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>;
    }
}