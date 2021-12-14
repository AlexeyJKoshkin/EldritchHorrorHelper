using EldritchHorror.Entitas.Components;

namespace EldritchHorror.UI
{
    public class EncountersPanelView : EldrtichUIComponent
    {
        public CurrentCardDeckView AmericaDeckView;
        public CurrentCardDeckView AsiaAustraliaDeckView;
        public CurrentCardDeckView EuropeDeckView;
        public CurrentCardDeckView OtherWorldDeckView;
        public CurrentCardDeckView GeneralWorldDeckView;
        public CurrentCardDeckView ResearchWorldDeckView;
        public CurrentCardDeckView ExpeditionDeckView;
        public CurrentCardDeckView SpecialDeckView;

        public void UpdateView(int index, EncounterDeckComponent component)
        {
            CurrentCardDeckView deckView = GetDeck(index);
            if(deckView == null) return;
            deckView.CardCounter = component.Count;
            deckView.CurrentCardPreview.Bind(component.CurrentCard);
        }

        private CurrentCardDeckView GetDeck(int index)
        {
            switch (index)
            {
                case GameLoopComponentsLookup.AmericaCardDeck:       return AmericaDeckView;
                case GameLoopComponentsLookup.AsiaAustraliaCardDeck: return AsiaAustraliaDeckView;
                case GameLoopComponentsLookup.EuropeCardDeck:        return EuropeDeckView;
                case GameLoopComponentsLookup.OtherWorldCardDeck:    return OtherWorldDeckView;
                case GameLoopComponentsLookup.GeneralCardDeck:       return GeneralWorldDeckView;
            }

            return null;
        }
    }
}