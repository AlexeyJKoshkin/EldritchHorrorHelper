using EldritchHorror.Entitas.Components;
using UnityEngine;

namespace EldritchHorror.UI
{
    public class GameMasterCardDeckPanelView : MonoBehaviour
    {
        public CurrentCardDeckView AmericaDeckView;
        public CurrentCardDeckView AsiaAustraliaDeckView;
        public CurrentCardDeckView EuropeDeckView;
        public CurrentCardDeckView ExpeditionDeckView;
        public CurrentCardDeckView GeneralWorldDeckView;
        /// <summary>
        ///     Колода мифов
        /// </summary>
        [SerializeField] public CurrentCardDeckView MythosDeckView;
        public CurrentCardDeckView OtherWorldDeckView;
        public CurrentCardDeckView ResearchWorldDeckView;
        public CurrentCardDeckView SpecialDeckView;


        private CurrentCardDeckView GetDeck(int index)
        {
            switch (index)
            {
                case GameLoopComponentsLookup.AmericaCardDeck:       return AmericaDeckView;
                case GameLoopComponentsLookup.AsiaAustraliaCardDeck: return AsiaAustraliaDeckView;
                case GameLoopComponentsLookup.EuropeCardDeck:        return EuropeDeckView;
                case GameLoopComponentsLookup.OtherWorldCardDeck:    return OtherWorldDeckView;
                case GameLoopComponentsLookup.GeneralCardDeck:       return GeneralWorldDeckView;
                case GameLoopComponentsLookup.InGameMythosDeck:      return MythosDeckView;
            }

            return null;
        }

        public void TryUpdateDeckView(GameLoopEntity entity, int index)
        {
            var deck = GetDeck(index);
            if (deck == null)
            {
                return;
            }

            EncounterDeckComponent component = entity.GetComponent(index) as EncounterDeckComponent;
            if (component == null)
            {
                return;
            }

            deck.CardCounter = component.Count;
        }

        public void UpdateAllDeck(GameLoopEntity e)
        {
            foreach (var index in e.GetComponentIndices())
            {
                var component = e.GetComponent(index);
                if (component is EncounterDeckComponent)
                {
                    TryUpdateDeckView(e, index);
                }
            }
        }
    }
}