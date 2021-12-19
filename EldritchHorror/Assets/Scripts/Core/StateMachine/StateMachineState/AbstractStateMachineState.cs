#region

using Entitas;

#endregion

namespace EldritchHorror.Core
{
   
    public class AbstractStateMachineState<T> : IStateMachineState<T> where T : class, IEntity
    {
        public T StateEntity { get; private set; }

        public virtual int Order => 1;

        protected virtual void OnExit(T entity)
        {
            HLogger.Log($"Exit => {GetType().Name}");
        }


        protected virtual void OnEnter(T entity)
        {
            StateEntity = entity;
            HLogger.Log($"Enter => {GetType().Name}");

        }

        public int CompareTo(object obj)
        {
            if (obj is AbstractStateMachineState<T> s)
            {
                return this.Order.CompareTo(s.Order);
            }
            return 0;
        }
        
        void IStateMachineState<T>.Exit(T stateEntity)
        {
            OnExit(stateEntity);
        }
        
        void IStateMachineState<T>.Enter(T stateEntity)
        {
            OnEnter(stateEntity);
        }
    }
}