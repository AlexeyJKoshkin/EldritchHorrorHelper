using EldritchHorror.EntitasSystems;

namespace EldritchHorror 
{
    public class GameLoopGameState : MainLoopState
    {
        private readonly ITurnPhaseSwitcherSystem _turnPhaseSwitcher;
        private readonly GameLoopContext _context;

        public override int Order => 100;

        public GameLoopGameState(ITurnPhaseSwitcherSystem turnPhaseSwitcher, GameLoopContext context)
        {
            _turnPhaseSwitcher = turnPhaseSwitcher;
            _context = context;
        }

        protected override void OnEnter(MainLoopEntity entity)
        {
            base.OnEnter(entity);
            _context.masterEntityEntity.AddTurnCounter(0);
            _context.masterEntityEntity.AddOmenState(0);
            _turnPhaseSwitcher.NewTurn();
        }
    }
}