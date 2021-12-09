
using Entitas;

namespace EldritchHorror.Core
{
    public interface IStateMachineState<T> where T:class, IEntity
    {
        void Exit();
        void Enter();
    }
}