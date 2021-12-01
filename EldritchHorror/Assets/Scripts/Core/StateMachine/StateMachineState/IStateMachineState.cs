using System;
using System.Collections;
using System.Collections.Generic;

namespace EldritchHorror.Core
{
    public interface IStateMachineState
    {
        int Order { get; }
        void Exit();
        void Enter();

        IEnumerable<IStateTransition> AllTransitions();
    }
}