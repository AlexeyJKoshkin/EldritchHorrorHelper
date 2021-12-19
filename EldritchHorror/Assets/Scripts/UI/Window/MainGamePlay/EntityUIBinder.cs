using System;
using Entitas;

namespace EldritchHorror.UI {
    class EntityUIBinder<TEntity> where TEntity : class, IEntity
    {
        struct HandlerBox
        {
            public Action<IEntity, int, IComponent> UpdateReplcedHandler;
            public Action UpdateHandler;
            public Action UpdateClear;
        }

        private HandlerBox _handlerBox;
        

        public EntityUIBinder(IUView container)
        {
            _handlerBox = new HandlerBox {UpdateClear = container.Clear, UpdateHandler = container.UpdateView, UpdateReplcedHandler = container.UpdateView};
        }

        public EntityUIBinder(Action<IEntity, int, IComponent> onUpdateMainEntity, Action onSetEntity, Action clearHandler)
        {
            _handlerBox = new HandlerBox {UpdateClear = clearHandler, UpdateHandler = onSetEntity, UpdateReplcedHandler = onUpdateMainEntity};
        }

        public TEntity Current { get; private set; }

        public void Bind(TEntity entity)
        {
            if (entity == null)
            {
                if (Current == null)
                {
                    return;
                }

                Clear();
                Current = null;
            }
            else
            {
                Current = entity;
                Subscribe();
            }
        }

        private void Subscribe()
        {
            Current.OnComponentReplaced += OnComponentReplaced;
            Current.OnDestroyEntity     += OnDestroyHandler;
            _handlerBox.UpdateHandler?.Invoke();
        }

        private void Clear()
        {
            Current.OnComponentReplaced -= OnComponentReplaced;
            Current.OnDestroyEntity     -= OnDestroyHandler;
            _handlerBox.UpdateClear?.Invoke();
        }

        private void OnDestroyHandler(IEntity entity)
        {
            Clear();
            Bind(null);
        }

        private void OnComponentReplaced(IEntity entity, int index, IComponent previouscomponent, IComponent newcomponent)
        {
            _handlerBox.UpdateReplcedHandler(entity, index, newcomponent);
        }
    }
}