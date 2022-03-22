namespace EldritchHorror.GameplayStateMachine 
{
    //фейковый окончательный стейт
    public class EndTurnGamePhase : MainGamePlayState
    {
        public override int Order => 50;


        public EndTurnGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }
}