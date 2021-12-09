using EldritchHorror.EntitasSystems;
using Luncher;
using Sirenix.OdinInspector;

namespace EldritchHorror
{
    public class MainSceneContext : EldritchHorrorSceneContext<IEldritchHorrorSceneLauncher>
    {
        private ITurnPhaseSwitcherSystem _mythosPhase;
        
        protected override void LunchScene(IEldritchHorrorSceneLauncher launcher)
        {
            base.LunchScene(launcher);
            launcher.ActivateScene();
            _mythosPhase = Container.Resolve<ITurnPhaseSwitcherSystem>();
        }

        [Button]
        void NewTurn()
        {
            _mythosPhase.NewTurn();
        }

        
    }
}