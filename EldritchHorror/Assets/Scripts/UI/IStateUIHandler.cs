using System;
using EldritchHorror.UI;
using Entitas;



namespace EldritchHorror.Core
{
    public interface IStateUIHandler
    {
        Type StateType { get; }
        void HandleExit(IEntity entity, IStateInfoProvider provider);
        void HandleEnter(IEntity entity, IStateInfoProvider provider);
    }

    public class StateUIHandler<TEntity, TState> : IStateUIHandler where TEntity : class where TState : class
    {
        private readonly IEldritchWindowUIProvider _windowUiProvider;

        public StateUIHandler(IEldritchWindowUIProvider windowUiProvider)
        {
            _windowUiProvider = windowUiProvider;
        }

        void IStateUIHandler.HandleExit(IEntity entity, IStateInfoProvider state)
        {
            HandleExit(entity as TEntity, state as TState);
        }

        void IStateUIHandler.HandleEnter(IEntity entity, IStateInfoProvider state)
        {
            HandleEnter(entity as TEntity, state as TState);
        }

        public Type StateType => typeof(TState);

        protected TWindow Window<TWindow>() where TWindow : IEldritchWindow
        {
            return _windowUiProvider.GetWindow<TWindow>();
        }

        public virtual void HandleExit(TEntity entity, TState mystate)
        {
            HLogger.LogInfo($"Ui Handle Exit {mystate?.GetType().Name}");
        }

        public virtual void HandleEnter(TEntity entity, TState mystate)
        {
            HLogger.LogInfo($"Ui Handle Enter {mystate?.GetType().Name}");
        }
    }
}