using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    class OmenEntityUpdateUIHandler : EntityUpdateUIHandlerMainWindow<GameLoopEntity>
    {

        public override void ClearFromEntity(GameLoopEntity entity)
        {
        }

        public override void UpdateEntityUI(GameLoopEntity omenEntity, int index, IComponent component)
        {
            Window.OmenView.CurrentPlace = omenEntity.omenState.CurrentState;
        }

        public OmenEntityUpdateUIHandler(ICurrentWindowProvider<MainGameUIWindow> windowProvider) : base(windowProvider)
        {
        }
    }
}