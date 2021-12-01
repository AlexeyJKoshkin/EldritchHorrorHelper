using EldritchHorror;
using System.Collections.Generic;

namespace EldritchHorror.Core
{
    public class AbstractStateMachineState : IStateMachineState
    {
        private readonly HashSet<IStateTransition> _transitions = new HashSet<IStateTransition>();


        public virtual void Exit()
        {
            HLogger.Log($"Exit => {GetType().Name}");
        }

        public virtual void Enter()
        {
            HLogger.Log($"Enter => {GetType().Name}");
        }

        public virtual int Order => 1;

        public virtual IEnumerable<IStateTransition> AllTransitions()
        {
            return _transitions;
        }

        public void AddTransaction(IStateTransition stateTransition)
        {
            _transitions.Add(stateTransition);
        }
    }
}