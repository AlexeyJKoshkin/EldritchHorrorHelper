using System;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.Core
{
    public class StateTransaction : IStateTransition
    {
        private Func<bool> _func = AlwaysTrue;
        private Type _type;

        public StateTransaction()
        {
        }

        public StateTransaction(Func<bool> func)
        {
            _func = func;
        }

        public Type Type
        {
            set => _type = value;
        }
        public Func<bool> Checker
        {
            set => _func = value;
        }
        public static IStateTransition Default { get; } = new DefaultStateCondition();

        public bool Check()
        {
            return _func.Invoke();
        }


        public IStateMachineState GetState<TState>(IReadOnlyCollection<TState> abstractStateMachine) where TState : class, IStateMachineState
        {
            if (_type == null)
            {
                return null;
            }

            return abstractStateMachine.FirstOrDefault(o => o.GetType() == _type);
        }

        public static bool AlwaysTrue()
        {
            return true;
        }

        private class DefaultStateCondition : IStateTransition
        {
            public bool Check()
            {
                return true;
            }

            public IStateMachineState GetState<TState>(IReadOnlyCollection<TState> abstractStateMachine) where TState : class, IStateMachineState
            {
                return null;
            }
        }
    }
}