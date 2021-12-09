using EldritchHorror.UI;
using Entitas;

namespace EldritchHorror.EntitasSystems
{
    class CurrentMythosEntityUpdateUIHandler : EntityUpdateUIHandlerMainWindow<MythosCardEntity>
    {

        public override void ClearFromEntity(MythosCardEntity currentMythosCard)
        {
            Window.MythosDeckView.SetCurrent(currentMythosCard);
            Window.PreviewCardImage.UpdateView(currentMythosCard);
        }

        public override void UpdateEntityUI(MythosCardEntity entity, int index, IComponent component)
        {
            Window.MythosDeckView.SetCurrent(null);
            Window.PreviewCardImage.UpdateView(null);
        }

        public CurrentMythosEntityUpdateUIHandler(ICurrentWindowProvider<MainGameUIWindow> windowProvider) : base(windowProvider)
        {
        }
    }
}