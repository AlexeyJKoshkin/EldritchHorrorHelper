#region

using EldritchHorror.Entitas.Components;
using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EldritchHorror.EntitasSystems
{
    internal class SetClickedMythosCardToPreview : ReactiveSystem<EldritchCardEntity>
    {
        private readonly Contexts _context;

        public SetClickedMythosCardToPreview(Contexts context) : base(context.eldritchCard)
        {
            _context  = context;
   
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
            Debug.LogError("SetPreviewIfPossible");
            /*if (fe.mythosState.State != MythosStateCardType.Open)
            {
                return;
            }

            if (_provider.Window.PreviewCardImage.Current == fe) // значит клик прошел по вревьюшке
            {
                _provider.Window.PreviewCardImage.ClearView();
                return;
            }

            _provider.Window.PreviewCardImage.Bind(fe);*/
        }
    }
    
    internal class SetClickedEncounterCardToPreview : ReactiveSystem<EldritchCardEntity>
    {
        private readonly Contexts _context;


        public SetClickedEncounterCardToPreview(Contexts context) : base(context.eldritchCard)
        {
            _context  = context;

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
            Debug.LogError("SetClickedEncounterCardToPreview");
            /*if (_provider.Window.PreviewCardImage.Current == fe) // значит клик прошел по вревьюшке
            {
                _provider.Window.PreviewCardImage.ClearView();
                return;
            }
            _provider.Window.PreviewCardImage.Bind(fe);*/
        }
    }
}