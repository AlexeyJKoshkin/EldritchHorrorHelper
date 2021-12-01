using EldritchHorror;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.Core
{
    public abstract class AbstractStateMachine<TState> : List<TState>, IStateMachine where TState : class, IStateMachineState
    {
        private IStateMachineState _current;

        public AbstractStateMachine(TState[] states) : base(states.Length)
        {
            AddRange(states);
            Sort((o1, o2) => o2.Order.CompareTo(o1.Order));
        }

        public void Start()
        {
            CheckTransition();
        }

        public void Stop()
        {
            Clear();
            SetNewCurrent(null);
        }

        public bool IsWorking { get; private set; }

        public virtual void LogStateMachine()
        {
            HLogger.Log($"{GetType().Name} Current -> {_current?.GetType().Name}");

            foreach (var state in this) HLogger.Log(state.GetType().Name);
        }


        public event Action FinishWorkEvent;


        private void SetNewCurrent(IStateMachineState current)
        {
            if (_current == current)
            {
                return;
            }

            _current?.Exit();
            _current = current;
            _current?.Enter();
            IsWorking = _current != null;
        }

        private void CheckTransition()
        {
            IStateMachineState nextState = null;
            if (_current == null)
            {
                nextState = this[0];
            }
            else
            {
                foreach (var transition in _current.AllTransitions())
                {
                    if (!transition.Check())
                    {
                        continue;
                    }

                    nextState = transition.GetState(this);
                    break;
                }
            }

            SetNewCurrent(nextState);
            if (_current == null)
            {
                FinishWorkEvent?.Invoke();
            }
        }
    }
}