using System;
using System.Collections.Generic;
using EldritchHorror.Core;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    public class UiHandleDispatcher : Dictionary<Type, IStateUIHandler>, IUiHandleDispatcher
    {
        public UiHandleDispatcher(IStateUIHandler[] gameloopHandlers)
        {
            gameloopHandlers.ForEach(h => this[h.StateType] = h);
        }

        public void HandleExit<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>
        {
            if (State == null)
            {
                return;
            }

            if (TryGetValue(State.GetType(), out var handler))
            {
                handler.HandleExit(e, State);
            }
        }

        public void HandleEnter<T, TState>(T e, TState State) where T : class, IEntity where TState : IStateMachineState<T>
        {
            if (State == null)
            {
                return;
            }

            if (TryGetValue(State.GetType(), out var handler))
            {
                handler.HandleEnter(e, State);
            }
        }
    }
}