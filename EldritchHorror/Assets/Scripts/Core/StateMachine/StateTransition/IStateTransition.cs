using System.Collections.Generic;

namespace EldritchHorror.Core
{
    public interface IStateTransition
    {
        bool Check();
        IStateMachineState GetState<TState>(IReadOnlyCollection<TState> abstractStateMachine) where TState : class, IStateMachineState;
    }
}