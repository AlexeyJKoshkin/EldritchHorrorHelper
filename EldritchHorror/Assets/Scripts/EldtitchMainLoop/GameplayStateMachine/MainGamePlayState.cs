#region

using EldritchHorror.Core;
using EldritchHorror.EntitasSystems;
using EldritchHorror.UI;
using System;

#endregion

namespace EldritchHorror.GameplayStateMachine
{
    public interface IGameRoundPhase : IStateMachineState<GameLoopEntity>, IComparable
    {

    }

    public abstract class MainGamePlayState : AbstractStateMachineState<GameLoopEntity>, IGameRoundPhase
    {
        public int Turn => _contexts.gameLoop.turnCounter.Turn;
        
        private readonly Contexts _contexts;

        public MainGamePlayState(Contexts gameLoopContext) : base()
        {
            _contexts = gameLoopContext;
          
        }

        public GameLoopContext GameLoopContext => _contexts.gameLoop;
        public EldritchCardContext EldritchCardContext => _contexts.eldritchCard;

        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            HLogger.LogInfo($"Enter {GetType().Name}");
        }

        protected override void OnExit(GameLoopEntity stateEntity)
        {
            HLogger.LogInfo($"Exit {GetType().Name}");
        }

    }
}