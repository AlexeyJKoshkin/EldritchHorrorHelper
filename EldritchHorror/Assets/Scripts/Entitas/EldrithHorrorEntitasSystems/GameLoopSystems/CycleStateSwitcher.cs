using System.Collections.Generic;
using System.Linq;
using EldritchHorror.Core;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    public abstract class CycleStateSwitcher<T, TPhase> : ReactiveSystem<T> where T : class, IEntity where TPhase : IStateMachineState<T>
    {
        protected readonly CycleStateBox StateBox;

        protected CycleStateSwitcher(IContext<T> context, TPhase[] phases) : base(context)
        {
            StateBox = new CycleStateBox(phases);
        }

        protected sealed override ICollector<T> GetTrigger(IContext<T> context)
        {
            return context.CreateCollector(ReadyStateMatcher);
        }

        protected abstract IMatcher<T> ReadyStateMatcher { get; }

        protected override void Execute(List<T> entities)
        {
            var e = entities.SingleEntity();
            HandleNextPhase(StateBox.GetNext(), e);
        }

        protected abstract void HandleNextPhase(TPhase nextState, T entity);

        protected class CycleStateBox
        {
            private int _currentIndexPhase;
            private readonly List<TPhase> _phases;

            public CycleStateBox(TPhase[] phases)
            {
                _phases = phases.ToList();
                _phases.Sort();
            }

            public TPhase GetNext()
            {
                _currentIndexPhase++;
                if (_currentIndexPhase >= _phases.Count)
                {
                    return default;
                }

                return _phases[_currentIndexPhase];
            }

            public void Reset()
            {
                _currentIndexPhase = -1;
            }
        }
    }
}