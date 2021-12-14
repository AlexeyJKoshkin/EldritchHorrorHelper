#region

using EldritchHorror.Core;
using EldritchHorror.EntitasSystems;
using System;

#endregion

namespace EldritchHorror.GameplayStateMachine
{
    public interface IGameRoundPhase : IStateMachineState<GameLoopEntity>, IComparable { }

    public abstract class MainGamePlayState : AbstractStateMachineState<GameLoopEntity>, IGameRoundPhase
    {
        protected readonly IEldritchUIController UIControllerHandler;
        
        private readonly Contexts _contexts;

        public MainGamePlayState(Contexts gameLoopContext, IEldritchUIController uiControllerHandler)
        {
            _contexts = gameLoopContext;
            UIControllerHandler = uiControllerHandler;
        }

        public GameLoopContext GameLoopContext => _contexts.gameLoop;
        public EldritchCardContext EldritchCardContext => _contexts.eldritchCard;

        public override void Enter(GameLoopEntity stateEntity)
        {
            HLogger.LogError($"Enter {GetType().Name}");
        }

        public override void Exit(GameLoopEntity stateEntity)
        {
            HLogger.LogError($"Exit {GetType().Name}");
        }

        public int CompareTo(object obj)
        {
            if (obj is MainGamePlayState state)
            {
                return Order.CompareTo(state.Order);
            }

            return 1;
        }
    }
}