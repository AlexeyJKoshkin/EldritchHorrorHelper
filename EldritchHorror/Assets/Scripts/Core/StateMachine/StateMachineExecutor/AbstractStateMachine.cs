using System;
using System.Collections.Generic;

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
            SetNewCurrent(this[0]);
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
            IsWorking = true;
            TryFinishWork();
          
        }

        private void TryFinishWork()
        {
            if(_current!= null) return;
            IsWorking = false;
            FinishWorkEvent?.Invoke();
        }
    }
}