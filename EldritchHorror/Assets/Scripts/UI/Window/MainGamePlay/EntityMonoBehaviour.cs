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

    public abstract class EntityMonoBehaviour<TEntity> : MonoBehaviour, IEntityMonoBehaviour<TEntity> where TEntity : class, IEntity
    {
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
                UpdateView();
            }
        }

        protected virtual void UpdateView() { }

        protected virtual void Clear() { }
    }
}