using Entitas;
using JetBrains.Annotations;
using System;

namespace EldritchHorror.EntitasSystems
{
    public interface IUpdateUiReactionAdapter
    {
        void StartListening();
        void StopListening();
    }




    public class UpdateUIReactionAdapter<T> : IUpdateUiReactionAdapter where T : class, IEntity
    {
        private readonly IGroup<T> _getGroup;
        private readonly IEntityUpdateHandlerUI<T> _handlerUi;

        public UpdateUIReactionAdapter([NotNull]IGroup<T> group, [NotNull]IEntityUpdateHandlerUI<T> handlerUi)
        {
            _getGroup = group;
            _handlerUi = handlerUi;
        }

        public UpdateUIReactionAdapter(IGroup<T> @group, Action<T, int, IComponent> updateCurrentMythosView, Action<T> clearMythosView)
        {
            _getGroup = group;
            _handlerUi = new Mock(clearMythosView, updateCurrentMythosView);
        }


        private void OnEntityRemoved(IGroup<T> @group, T entity, int index, IComponent component)
        {
            _handlerUi.ClearFromEntity(entity);
        }

        private void OnEntityAdded(IGroup<T> @group, T entity, int index, IComponent component)
        {
            _handlerUi.UpdateEntityUI(entity, index, component);
        }

        private void OnEntityUpdated(IGroup<T> @group, T entity, int index, IComponent previouscomponent, IComponent newcomponent)
        {
            OnEntityAdded(group, entity, index, newcomponent);
        }

        public void StartListening()
        {
            if(_getGroup == null) return;
            _getGroup.OnEntityUpdated += OnEntityUpdated;
            _getGroup.OnEntityAdded   += OnEntityAdded;
            _getGroup.OnEntityRemoved += OnEntityRemoved;
        }

        public void StopListening()
        {
            if(_getGroup == null) return;
            _getGroup.OnEntityUpdated -= OnEntityUpdated;
            _getGroup.OnEntityAdded   -= OnEntityAdded;
            _getGroup.OnEntityRemoved -= OnEntityRemoved;
        }

        class Mock : IEntityUpdateHandlerUI<T>
        {
            private readonly Action<T> _clear;
            private readonly Action<T, int, IComponent> _update;

            public Mock(Action<T> clear, Action<T, int, IComponent> update)
            {
                _clear = clear;
                _update = update;
            }

            public void ClearFromEntity(T entity)
            {
                _clear?.Invoke(entity);
            }

            public void UpdateEntityUI(T entity, int index, IComponent component)
            {
                _update?.Invoke(entity, index, component);
            }
        }
    }
}