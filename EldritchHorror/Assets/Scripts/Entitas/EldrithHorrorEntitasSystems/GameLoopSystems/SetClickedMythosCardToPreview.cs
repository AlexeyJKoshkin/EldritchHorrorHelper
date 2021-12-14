#region

using EldritchHorror.Entitas.Components;
using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;

#endregion

namespace EldritchHorror.EntitasSystems
{
    internal class SetClickedMythosCardToPreview : ReactiveSystem<EldritchCardEntity>
    {
        private readonly Contexts _context;
        private readonly ICurrentWindowProvider<MainGameUIWindow> _provider;

        public SetClickedMythosCardToPreview(Contexts context, ICurrentWindowProvider<MainGameUIWindow> provider) : base(context.eldritchCard)
        {
            _context  = context;
            _provider = provider;
        }

        protected override ICollector<EldritchCardEntity> GetTrigger(IContext<EldritchCardEntity> context)
        {
            return context.CreateCollector(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Click, EldritchCardMatcher.MythosState).NoneOf(EldritchCardMatcher.IsDraftMythos));
        }

        protected override bool Filter(EldritchCardEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EldritchCardEntity> entities)
        {
            entities.ForEach(e => e.isClick = false);
            if (!_context.gameLoop.hasInGameMythosDeck)
            {
                return;
            }

            SetPreviewIfPossible(entities[0]);
        }

        private void SetPreviewIfPossible(EldritchCardEntity fe)
        {
            if (fe.mythosState.State != MythosStateCardType.Open)
            {
                return;
            }

            if (_provider.Window.PreviewCardImage.Current == fe) // значит клик прошел по вревьюшке
            {
                _provider.Window.PreviewCardImage.ClearView();
                return;
            }

            _provider.Window.PreviewCardImage.Bind(fe);
        }
    }
    
    internal class SetClickedEncounterCardToPreview : ReactiveSystem<EldritchCardEntity>
    {
        private readonly Contexts _context;
        private readonly ICurrentWindowProvider<MainGameUIWindow> _provider;

        public SetClickedEncounterCardToPreview(Contexts context, ICurrentWindowProvider<MainGameUIWindow> provider) : base(context.eldritchCard)
        {
            _context  = context;
            _provider = provider;
        }

        protected override ICollector<EldritchCardEntity> GetTrigger(IContext<EldritchCardEntity> context)
        {
            return context.CreateCollector(Matcher<EldritchCardEntity>.AllOf(EldritchCardMatcher.Click, EldritchCardMatcher.Encounter));
        }

        protected override bool Filter(EldritchCardEntity entity)
        {
            return true;
        }

        protected override void Execute(List<EldritchCardEntity> entities)
        {
            entities.ForEach(e => e.isClick = false);
            SetPreviewIfPossible(entities[0]);
        }

        private void SetPreviewIfPossible(EldritchCardEntity fe)
        {
            if (_provider.Window.PreviewCardImage.Current == fe) // значит клик прошел по вревьюшке
            {
                _provider.Window.PreviewCardImage.ClearView();
                return;
            }
            _provider.Window.PreviewCardImage.Bind(fe);
        }
    }
}