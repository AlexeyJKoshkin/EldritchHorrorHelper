#region

using Entitas;

#endregion

namespace EldritchHorror.Core
{
    public class AbstractStateMachineState<T> : IStateMachineState<T> where T : class, IEntity
    {
        protected T StateEntity { get; private set; }

        public virtual int Order => 1;

        public virtual void Exit(T entity)
        {
            HLogger.Log($"Exit => {GetType().Name}");
        }

        public virtual void Enter(T entity)
        {
            StateEntity = entity;
            HLogger.Log($"Enter => {GetType().Name}");
        }
    }
}