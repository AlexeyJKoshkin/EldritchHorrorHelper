namespace EldritchHorror.GameplayStateMachine
{
    /// <summary>
    /// Фаза столкновений. Когда игроки могут проходить всякие проверки
    /// </summary>
    public class EncounterGamePhase : MainGamePlayState
    {
        public EncounterGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
        public override int Order => 30;


        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
        }

        protected override void OnExit(GameLoopEntity stateEntity)
        {
            base.OnExit(stateEntity);
        }
    }
}