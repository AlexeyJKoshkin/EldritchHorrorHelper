using EldritchHorror.Core;
using EldritchHorror.UI;
using System;

namespace EldritchHorror.GameplayStateMachine
{
    public interface IGameRoundPhase : IStateMachineState<GameLoopEntity>, IComparable
    {
    }

    public abstract class MainGamePlayState : AbstractStateMachineState<GameLoopEntity>,IGameRoundPhase
    {
        public GameLoopContext GameLoopContext => _contexts.gameLoop;
        public MythosCardContext MythosCardContext => _contexts.mythosCard;
      

        private readonly Contexts _contexts;

        public override void Enter()
        {
            HLogger.LogError($"Enter {this.GetType().Name}");
        }

        public override void Exit()
        {
            HLogger.LogError($"Exit {this.GetType().Name}");
        }

        public MainGamePlayState(Contexts gameLoopContext)
        {
            _contexts = gameLoopContext;
          
        }

        public int CompareTo(object obj)
        {
            if (obj is MainGamePlayState state)
            {
                return this.Order.CompareTo(state.Order);
            }
            return 1;
        }
    }
}