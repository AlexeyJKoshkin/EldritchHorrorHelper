using EldritchHorror.GameplayStateMachine;
using Entitas;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{
    public interface ITurnPhaseSwitcherSystem
    {
        void NewTurn();
    }


    public class TurnPhaseSwitcherSystem : ReactiveSystem<GameLoopEntity>,ITurnPhaseSwitcherSystem
    {
        private readonly GameLoopContext _context;
        private readonly List<IGameRoundPhase> _phases;
        private int _currentIndexPhase;
        public TurnPhaseSwitcherSystem(GameLoopContext context,IGameRoundPhase[] phases) : base(context)
        {
            _context = context;
            _phases = phases.ToList();
            _phases.Sort();
        }

        protected override ICollector<GameLoopEntity> GetTrigger(IContext<GameLoopEntity> context)
        {
            return context.CreateCollector(Matcher<GameLoopEntity>.AllOf(GameLoopMatcher.PhaseReady, GameLoopMatcher.CurrentGamePhase));
        }

        protected override bool Filter(GameLoopEntity entity)
        {
            return entity.isPhaseReady;
        }

        protected override void Execute(List<GameLoopEntity> entities)
        {
            var e = entities.SingleEntity();
            NextPhase(e);
        }

        private void NextPhase(GameLoopEntity gameLoopEntity)
        {
            _currentIndexPhase++;
            if (_currentIndexPhase >= _phases.Count)
            {
                gameLoopEntity.RemoveCurrentGamePhase();
                gameLoopEntity.Destroy();
                this._context.ReplaceTurnCounter(this._context.turnCounter.Turn+1);
            }
            else
            {
                gameLoopEntity.ReplaceCurrentGamePhase(_phases[_currentIndexPhase]);
            }
        }

        public void NewTurn()
        {
            _currentIndexPhase = -1;
            var entity = _context.CreateEntity();
            NextPhase(entity);
        }
    }
  
}