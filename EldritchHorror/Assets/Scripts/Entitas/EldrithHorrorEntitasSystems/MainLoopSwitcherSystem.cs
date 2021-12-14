#region

using EldritchHorror.Core;
using Entitas;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public abstract class BaseStateEnterExitSystem<TEntity, TState> : IInitializeSystem, ITearDownSystem where TEntity : class, IEntity where TState : IStateMachineState<TEntity>
    {
        private IGroup<TEntity> _group;

        public BaseStateEnterExitSystem(IContext<TEntity> context)
        {
            _group = context.GetGroup(Matcher<TEntity>.AllOf(StateComponentIndex));
        }

        protected abstract int StateComponentIndex { get; }


        public void Initialize()
        {
            _group.OnEntityAdded   += GroupOnOnEntityAdded;
            _group.OnEntityRemoved += GroupOnEntityRemoved;
        }

        public void TearDown()
        {
            _group.OnEntityAdded   -= GroupOnOnEntityAdded;
            _group.OnEntityRemoved -= GroupOnEntityRemoved;
        }

        protected virtual void OnStart(TEntity entity, TState state)
        {
            state.Enter(entity);
        }

        protected virtual void OnEnd(TEntity entity, TState state)
        {
            state.Exit(entity);
        }

        private void GroupOnOnEntityAdded(IGroup<TEntity> group, TEntity entity, int index, IComponent component)
        {
            if (component is TState state)
            {
                OnStart(entity, state);
            }
        }

        private void GroupOnEntityRemoved(IGroup<TEntity> group, TEntity entity, int index, IComponent component)
        {
            if (component is TState state)
            {
                OnEnd(entity, state);
            }
        }
    }

    public class MainLoopSwitcherSystem : BaseStateEnterExitSystem<MainLoopEntity, IStateMachineState<MainLoopEntity>>
    {
        public MainLoopSwitcherSystem(IContext<MainLoopEntity> context) : base(context) { }


        protected override int StateComponentIndex => MainLoopComponentsLookup.MainLoopState;
    }
}