using Entitas;

namespace EldritchHorror.Core
{
    public class AbstractStateMachineState<T> : IStateMachineState<T> where T:class, IEntity
    {
        public virtual void Exit()
        {
            HLogger.Log($"Exit => {GetType().Name}");
        }

        public virtual void Enter()
        {
            HLogger.Log($"Enter => {GetType().Name}");
        }

        public virtual int Order => 1;
    }
}