#region

using Entitas;

#endregion

namespace EldritchHorror.Core
{
    public interface IStateMachineState<T> where T : class, IEntity
    {
        void Exit(T stateEntity);
        void Enter(T stateEntity);
    }
}