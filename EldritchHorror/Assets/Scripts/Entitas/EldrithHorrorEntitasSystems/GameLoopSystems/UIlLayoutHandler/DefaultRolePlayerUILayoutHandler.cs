#region

using EldritchHorror.Entitas.Components;
using Entitas;
using System;
using UnityEngine;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public class DefaultRolePlayerUILayoutHandler : AbstractRolePlayerUILayoutHandler
    {
        public DefaultRolePlayerUILayoutHandler(Contexts context) : base(context) { }

        protected override void UpdateCurrentMythos(EldritchCardEntity currentEldritchCard, int index, IComponent component)
        {
            if (!currentEldritchCard.mythos.Def.IsProcess)
            {
                Window.MythosDeckView.CurrentCardPreview.Bind(currentEldritchCard);
            }

            Window.PreviewCardImage.Bind(currentEldritchCard);
        }

        protected override void RemoveCurrentMythosHandler(EldritchCardEntity entity, int index)
        {
            Window.MythosDeckView.CurrentCardPreview.Bind(null);
            Window.PreviewCardImage.Bind(null);
        }

        protected override void RemoveProcessCard(EldritchCardEntity currentEldritchCard, int index)
        {
            foreach (var view in Window.RumorCardViews)
                if (view.Current == currentEldritchCard)
                {
                    view.ClearView();
                }
        }

        protected override void OnAddProcessCard(EldritchCardEntity currentEldritchCard, int index, IComponent component)
        {
            foreach (var view in Window.RumorCardViews)
            {
                if (view.Current != null)
                {
                    continue;
                }

                view.Bind(currentEldritchCard);
                return;
            }
        }

        protected override void UpdateEncounterCard(GameLoopEntity entity, int index, IComponent component)
        {
            Debug.Log(index);
            Window.EncountersPanelView.UpdateView(index,component as EncounterDeckComponent);
            switch (index)
            {
                case GameLoopComponentsLookup.AmericaCardDeck:
                    Window.TurnCounter = entity.turnCounter.Turn;
                    break;
                case GameLoopComponentsLookup.OmenState:
                    Window.OmenView.CurrentPlace = entity.omenState.CurrentState;
                    break;
                case GameLoopComponentsLookup.InGameMythosDeck:
                    Window.MythosDeckView.CardCounter = entity.inGameMythosDeck.List.Count;
                    break;
            }
        }

        protected override void UpdateGeneralGameStateUI(GameLoopEntity entity, int index, IComponent component)
        {
            switch (index)
            {
                case GameLoopComponentsLookup.TurnCounter:
                    Window.TurnCounter = entity.turnCounter.Turn;
                    break;
                case GameLoopComponentsLookup.OmenState:
                    Window.OmenView.CurrentPlace = entity.omenState.CurrentState;
                    break;
                case GameLoopComponentsLookup.InGameMythosDeck:
                    Window.MythosDeckView.CardCounter = entity.inGameMythosDeck.List.Count;
                    break;
            }
        }
    }
}