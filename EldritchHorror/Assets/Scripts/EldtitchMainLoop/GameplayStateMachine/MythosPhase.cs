using EldritchHorror.UI;

namespace EldritchHorror.GameplayStateMachine
{
    public class MythosPhase : MainGamePlayState
    {
        private readonly IEldritchOmen _omen;


        public override void Enter()
        {
            MainGameUiWindow.Show();
            
            GameLoopContext.masterEntityEntity.ReplaceOmenUI(MainGameUiWindow.OmenView);
            
            //взять следующую карту
            GetNextCard();
        }

        private void GetNextCard()
        {
            MythosCardContext.isIsActiveMythos = false;
            var mythosQueue = GameLoopContext.inGameMythosCards.List; 
            var current = mythosQueue.Dequeue();
            MainGameUiWindow.MythosDeckView.SetCurrent(current);
            MainGameUiWindow.MythosDeckView.MythosCardCounter =(mythosQueue.Count);
            
            MainGameUiWindow.PreviewCardImage.UpdateView(current);
            _omen.MoveNext();
            
            current.isIsActiveMythos = true;
            //todo: обработать карту
        }

        public override void Exit()
        {
          //  MainGameUiWindow.Hide();
            GameLoopContext.ReplaceTurnCounter(GameLoopContext.turnCounter.Turn+1);
        }


        public MythosPhase(IEldritchWindowUIProvider provider, IEldritchOmen omen, Contexts gameLoopContext) : base(provider, gameLoopContext)
        {
            _omen = omen;
        }
    }
}