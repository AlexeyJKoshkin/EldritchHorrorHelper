
namespace EldritchHorror.Core
{
    public interface IStateMachineState
    {
        int Order { get; }
        void Exit();
        void Enter();
    }
}