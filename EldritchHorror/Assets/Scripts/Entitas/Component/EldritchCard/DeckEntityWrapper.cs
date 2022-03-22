using System;
using System.Collections.Generic;
using Entitas;

namespace EldritchHorror.Entitas.Components
{
    public class DeckEntityWrapper<T> where T : class, IEntity
    {
        private readonly Func<EncounterDeckComponent> _componentGetter;
        private readonly Action<Queue<EldritchCardEntity>> _componentReplacer;
        public readonly T Entity;

        public Stack<EldritchCardEntity> Draft = new Stack<EldritchCardEntity>();


        private DeckEntityWrapper(Func<EncounterDeckComponent> componentGetter, Action<Queue<EldritchCardEntity>> componentReplacer)
        {
            _componentGetter   = componentGetter;
            _componentReplacer = componentReplacer;
        }


        public DeckEntityWrapper(T entity)
        {
            Entity = entity;
        }

        public void Next()
        {
            var queue = _componentGetter?.Invoke()?.CardOrder;
            if (queue == null)
            {
                return;
            }

            Draft.Push(queue.Dequeue());
            if (queue.Count == 0)
            {
                List<EldritchCardEntity> list = new List<EldritchCardEntity>(Draft);
                while (list.Count > 0) queue.Enqueue(list.GetRandom(true));

                Draft.Clear();
            }

            _componentReplacer?.Invoke(queue);
        }

        public void Back()
        {
            var queue = _componentGetter?.Invoke()?.CardOrder;
            if (queue == null)
            {
                return;
            }

            if (Draft.Count > 0)
            {
                queue.Enqueue(Draft.Pop());
            }

            _componentReplacer?.Invoke(queue);
        }
    }
}