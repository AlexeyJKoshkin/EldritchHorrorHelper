using EldritchHorror.Core;

namespace EldritchHorror
{
    public class GameLoopStateMachine : AbstractStateMachine<IGameLoopState>, IGameLoopStateMachine
    {
        public GameLoopStateMachine(IGameLoopState[] states) : base(states)
        {
        }
    }
}