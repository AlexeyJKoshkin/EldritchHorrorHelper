using System;
using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.Core
{

    public interface IStateUIHandler
    {
        void HandleExit(IEntity entity, IStateInfoProvider provider);
        void HandleEnter(IEntity entity, IStateInfoProvider provider);
        Type StateType { get; }
    }

    public class StateUIHandlerComposite
    {
        
    }

    public class StateUIHandler<TEntity, TState> : IStateUIHandler where TEntity : class where TState : class
    {
        private readonly IEldritchWindowUIProvider _windowUiProvider;

        protected TWindow Window<TWindow>() where TWindow : IEldritchWindow => _windowUiProvider.GetWindow<TWindow>();

        public StateUIHandler(IEldritchWindowUIProvider windowUiProvider)
        {
            _windowUiProvider = windowUiProvider;
        }

        public virtual void HandleExit(TEntity entity, TState mystate)
        {
            HLogger.LogError($"Ui Handl Exit {mystate?.GetType().Name}");
        }

        public virtual void HandleEnter(TEntity entity, TState mystate)
        {
            HLogger.LogError($"Ui Handle Enter {mystate?.GetType().Name}");
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
    }
}