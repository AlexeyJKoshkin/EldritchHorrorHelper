#region

using EldritchHorror.EntitasSystems;
using Luncher;
using Sirenix.OdinInspector;

#endregion

namespace EldritchHorror
{
    public class MainSceneContext : EldritchHorrorSceneContext<IEldritchHorrorSceneLauncher>
    {
        protected override void LunchScene(IEldritchHorrorSceneLauncher launcher)
        {
            base.LunchScene(launcher);
            launcher.ActivateScene();
        }
    }
}