using System.Collections;
using System.Collections.Generic;
using EldritchHorror.Core;
using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.Entitas.Components
{
    public interface IStatHolderComponent<out T, TEntity> where T : IStateMachineState<TEntity> where TEntity : class, IEntity
    {
        T Current { get; }
    }

    public abstract class StateHolderComponent<T, TEntity> : IStatHolderComponent<T, TEntity> where T : IStateMachineState<TEntity> where TEntity : class, IEntity
    {
        public T Current { get; set; }


        public int CompareTo(object obj)
        {
            return Current == null ? 0 : Current.CompareTo(obj);
        }
    }

    public class BaseCollectionComponent<T> : IEnumerable<T>
    {
        public List<T> List;

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public abstract class WindowBindingComponent<T> : IComponent where T : class, IEldritchWindow
    {
        public T Window;
    }

    public abstract class CardDeckComponent<T> : IComponent where T : class, IEntity
    {
        public T CurrentCard => CardOrder.Peek();
        public int Count => CardOrder.Count;
        public Queue<T> CardOrder;
    }
}