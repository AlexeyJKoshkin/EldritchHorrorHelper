using EldritchHorror.Core;

namespace EldritchHorror
{
    public class PrepareGameStateMachine : AbstractStateMachine<IPrepareGameMachineState>, IPrepareGameStateMachine
    {
        public PrepareGameStateMachine(IPrepareGameMachineState[] states) : base(states)
        {
        }
    }
}