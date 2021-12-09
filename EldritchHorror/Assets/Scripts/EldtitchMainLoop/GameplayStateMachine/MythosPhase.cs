
namespace EldritchHorror.GameplayStateMachine
{
    public class MythosPhase : MainGamePlayState
    {
        private readonly IEldritchOmen _omen;

        public override void Enter()
        {
            base.Enter();
            //MainGameUiWindow.Show(); //
            
           // GameLoopContext.masterEntityEntity.ReplaceOmenUI(MainGameUiWindow.OmenView);
            
            //взять следующую карту
            GetNextCard();
        }

        private void GetNextCard()
        {
            MythosCardContext.isIsActiveMythos = false;
            var mythosQueue = GameLoopContext.inGameMythosCards.List; 
            var current = mythosQueue.Dequeue();
            GameLoopContext.ReplaceInGameMythosCards(GameLoopContext.inGameMythosCards.Draft, mythosQueue);
            _omen.MoveNext();
            current.isIsActiveMythos = true;
            HLogger.LogError("Обработка действия карты");
        }

        public override void Exit()
        {
            base.Exit();
          //  MainGameUiWindow.Hide();
          //  GameLoopContext.ReplaceTurnCounter(GameLoopContext.turnCounter.Turn+1);
          
        }


        public MythosPhase(IEldritchOmen omen, Contexts gameLoopContext) : base(gameLoopContext)
        {
            _omen = omen;
        }
    }
}