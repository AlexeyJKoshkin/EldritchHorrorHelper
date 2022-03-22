#region

using Entitas;
using UnityEngine;

#endregion

namespace EldritchHorror.UI
{
    public interface IEntityMonoBehaviour<TEntity>
    {
        TEntity Current { get; }
        void Bind(TEntity entity);
    }

    public interface IUView
    {
        void Clear();
        void UpdateView();
        void UpdateView(IEntity e, int index, IComponent component);
    }


    public abstract class EntityMonoBehaviour<TEntity> : MonoBehaviour, IEntityMonoBehaviour<TEntity> where TEntity : class, IEntity
    {
        private EntityUIBinder<TEntity> _binder;

        protected EntityMonoBehaviour()
        {
            _binder = new EntityUIBinder<TEntity>(UpdateView, DoUpdateView, DoClear);
        }

        public TEntity Current => _binder.Current;

        public void Bind(TEntity entity)
        {
            if (_binder == null)
            {
                _binder = new EntityUIBinder<TEntity>(UpdateView, DoUpdateView, DoClear);
            }

            _binder.Bind(entity);
        }


        public abstract void UpdateView(IEntity e, int index, IComponent component);


        protected abstract void DoClear();

        protected abstract void DoUpdateView();
    }
}