using EldritchHorror.Core;
using EldritchHorror.UI;
using Entitas;
using System.Collections;
using System.Collections.Generic;

namespace EldritchHorror.Entitas.Components {
    public abstract class StateHolderComponent<T, TEntity> : IStateMachineState<TEntity> where T : IStateMachineState<TEntity> where TEntity : class, IEntity
    {
        public T Current;

        public void Exit(TEntity statentity)
        {
            Current?.Exit(statentity);
        }

        public void Enter(TEntity statentity)
        {
            Current?.Enter(statentity);
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