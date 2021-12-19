using EldritchHorror.Core;
using EldritchHorror.Entitas.Components;
using Entitas;

namespace EldritchHorror.EntitasSystems {
    public abstract class BaseStateEnterExitSystem<TEntity, TState> : ITearDownSystem where TEntity : class, IEntity where TState : IStateMachineState<TEntity>
    {
        private readonly IUiHandleDispatcher _uiHandleDispatcher;
        private readonly IGroup<TEntity> _group;

        public BaseStateEnterExitSystem(IContext<TEntity> context, IUiHandleDispatcher uiHandleDispatcher)
        {
            _uiHandleDispatcher = uiHandleDispatcher;
            _group              = context.GetGroup(Matcher<TEntity>.AllOf(StateComponentIndex));
            Initialize();
        }

        protected abstract IMatcher<TEntity> StateComponentIndex { get; }


        void Initialize()
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
            _uiHandleDispatcher.HandleEnter(entity, state);
        }

        protected virtual void OnEnd(TEntity entity, TState state)
        {
            _uiHandleDispatcher.HandleExit(entity, state);
            state.Exit(entity);
        }

        private void GroupOnOnEntityAdded(IGroup<TEntity> group, TEntity entity, int index, IComponent component)
        {
            if (component is IStatHolderComponent<TState, TEntity> holder)
            {
                OnStart(entity, holder.Current);
            }
        }

        private void GroupOnEntityRemoved(IGroup<TEntity> group, TEntity entity, int index, IComponent component)
        {
            if (component is IStatHolderComponent<TState, TEntity> holder)
            {
                OnEnd(entity, holder.Current);
            }
        }
    }
}