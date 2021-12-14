#region

using Entitas;
using GameKit.Editor;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public interface IUpdateUiReactionAdapter
    {
        void StartListening();
        void StopListening();
        void Execute();
    }

    public delegate void OnRemoveEntityUIHandler<in T>(T entity, int index);

    public delegate void OnUpdateEntityUIHandler<in T>(T entity, int index, IComponent component);


    public class UpdateUIReactionAdapter<T> : IUpdateUiReactionAdapter where T : class, IEntity
    {
        private readonly IGroup<T> _getGroup;
        private readonly IEntityUpdateHandlerUI<T> _handlerUi;
        Bucket _bucket = new Bucket();

        public UpdateUIReactionAdapter([NotNull] IGroup<T> group, [NotNull] IEntityUpdateHandlerUI<T> handlerUi)
        {
            _getGroup  = group;
            _handlerUi = handlerUi;
            foreach (var index in group.matcher.indices)
            {
                _bucket.GetRemovedBucket(index);
                _bucket.GetUpdateBucket(index);
            }
        }

        public UpdateUIReactionAdapter(IGroup<T> group, OnUpdateEntityUIHandler<T> updateCurrentMythosView, OnRemoveEntityUIHandler<T> clearMythosView)
        {
            _getGroup  = group;
            _handlerUi = new Mock(clearMythosView, updateCurrentMythosView);
        }

        public void StartListening()
        {
            if (_getGroup == null)
            {
                return;
            }

            _getGroup.OnEntityUpdated += OnEntityUpdated;
            _getGroup.OnEntityAdded   += OnEntityAdded;
            _getGroup.OnEntityRemoved += OnEntityRemoved;
        }

        public void StopListening()
        {
            if (_getGroup == null)
            {
                return;
            }

            _getGroup.OnEntityUpdated -= OnEntityUpdated;
            _getGroup.OnEntityAdded   -= OnEntityAdded;
            _getGroup.OnEntityRemoved -= OnEntityRemoved;
        }

        public void Execute()
        {
            foreach ((int  index, T e) item in _bucket.AllUpdate())
            {
                _handlerUi.UpdateEntityUI(item.e, item.index, item.e.GetComponent(item.index));
            }
            
            foreach ((int  index, T e) item in _bucket.AllRemoved())
            {
                _handlerUi.ClearFromEntity(item.e, item.index);
            }
        }


        private void OnEntityRemoved(IGroup<T> group, T entity, int index, IComponent component)
        {
            _bucket.GetRemovedBucket(index).Add(entity);
        }


        private void OnEntityAdded(IGroup<T> group, T entity, int index, IComponent component)
        {
            _bucket.GetUpdateBucket(index).Add(entity);
        }

        private void OnEntityUpdated(IGroup<T> group, T entity, int index, IComponent previouscomponent, IComponent newcomponent)
        {
            _bucket.GetUpdateBucket(index).Add(entity);
        }
        
        private class Bucket
        {
            readonly Dictionary<int, HashSet<T>> _removeBucket = new Dictionary<int, HashSet<T>>();
            readonly Dictionary<int, HashSet<T>> _updateBucket = new Dictionary<int, HashSet<T>>();
            
            public HashSet<T> GetRemovedBucket(int index)
            {
                return GetBucket(_removeBucket, index);
            }
            public HashSet<T> GetUpdateBucket(int index)
            {
                return GetBucket(_updateBucket, index);
            }
        
            private HashSet<T> GetBucket(Dictionary<int, HashSet<T>> d,int index)
            {
                if (!d.ContainsKey(index))
                {
                    d.Add(index, new HashSet<T>());
                }
                return d[index];
            }

            public IEnumerable<(int index, T e)> AllUpdate()
            {
                return GetAll(_updateBucket);
            }
            
            public IEnumerable<(int index, T e)> AllRemoved()
            {
                return GetAll(_removeBucket);
            }
            
            Queue<T> _queue = new Queue<T>();

            private IEnumerable<(int index, T e)> GetAll(Dictionary<int, HashSet<T>> updateBucket)
            {
                foreach (var pair in updateBucket)
                {
                    _queue = new Queue<T>(pair.Value);
                    pair.Value.Clear();
                    while (_queue.Count > 0)
                    {
                        yield return (pair.Key, _queue.Dequeue());
                    }
                }
            }

         
        }
        
      

        private class Mock : IEntityUpdateHandlerUI<T>
        {
            private readonly OnRemoveEntityUIHandler<T> _clear;
            private readonly OnUpdateEntityUIHandler<T> _update;
            

            public Mock(OnRemoveEntityUIHandler<T> clear, OnUpdateEntityUIHandler<T> update)
            {
                _clear  = clear;
                _update = update;
            }

            public void ClearFromEntity(T entity, int index)
            {
                _clear?.Invoke(entity, index);
            }

            public void UpdateEntityUI(T entity, int index, IComponent component)
            {
                _update?.Invoke(entity, index, component);
            }
        }
    }
}