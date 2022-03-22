namespace EldritchHorror.GameplayStateMachine 
{
    //фейковый подготовительный стейт
    public class PrepareGamePhase : MainGamePlayState
    {
        public override int Order => 10;

        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
            GameLoopContext.ReplaceTurnCounter(GameLoopContext.turnCounter.Turn +1);
            stateEntity.isPhaseReady = true;
        }


        public PrepareGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }
}