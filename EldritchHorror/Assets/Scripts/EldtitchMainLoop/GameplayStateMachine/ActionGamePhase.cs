namespace EldritchHorror.GameplayStateMachine
{
    public class ActionGamePhase : MainGamePlayState
    {
        public ActionGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
        public override int Order => 20;
    }
}