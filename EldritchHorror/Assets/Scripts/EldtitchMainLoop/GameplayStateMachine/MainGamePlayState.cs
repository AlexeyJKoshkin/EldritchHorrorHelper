using EldritchHorror.Core;
using EldritchHorror.UI;

namespace EldritchHorror.GameplayStateMachine
{
    public interface IMainGamePlayState : IStateMachineState
    {
        
    }

    public abstract class MainGamePlayState : AbstractStateMachineState,IMainGamePlayState
    {
        public GameLoopContext GameLoopContext => _contexts.gameLoop;
        public MythosCardContext MythosCardContext => _contexts.mythosCard;
        public MainGameUIWindow MainGameUiWindow { get; }

        private readonly Contexts _contexts;

        public MainGamePlayState(IEldritchWindowUIProvider provider, Contexts gameLoopContext)
        {
            _contexts = gameLoopContext;
            MainGameUiWindow = provider.GetWindow<MainGameUIWindow>();
        }
    }
}