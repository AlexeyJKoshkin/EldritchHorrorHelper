#region

using EldritchHorror.Cards;
using EldritchHorror.UserProfile;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public static class HelperExtensions
    {
        public static List<MythosCardDataDefinition> SelectMythos(this IEnumerable<GameBoxDef> gameboxes, MythosCardSaveSettings profileMythosCards)
        {
            var mythosCards = gameboxes.SelectMany(o => o.MythosCards)
                                       .Where(o => profileMythosCards.DifficultType.HasFlag(o.DifficultType.DifficultType))
                                       .ToList();

            if (profileMythosCards.ExcludedCards.Count != 0)
            {
                profileMythosCards.ExcludedCards.ForEach(ec => mythosCards.RemoveAll(o => o.UniqueID == ec));
            }

            return mythosCards;
        }

        public static void AddFrom(this List<MythosCardDataDefinition> allCards, Dictionary<MythosCardTypeSO, List<MythosCardDataDefinition>> mythosCards, MythosTypeCount[] first)
        {
            var actMythosCard = ActsMythos(mythosCards, first);
            while (actMythosCard.Count > 0) allCards.Add(actMythosCard.GetRandom(true));
        }

        private static List<MythosCardDataDefinition> ActsMythos(Dictionary<MythosCardTypeSO, List<MythosCardDataDefinition>> mythosCards, MythosTypeCount[] typeCounts)
        {
            List<MythosCardDataDefinition> acts = new List<MythosCardDataDefinition>();
            foreach (var def in typeCounts)
            {
                var list = mythosCards[def.TypeSo];
                for (int i = 0; i < def.Count; i++) acts.Add(list.GetRandom(true));
            }

            return acts;
        }

        public static AncientCardDataDefinition FindBoss(this IEnumerable<GameBoxDef> gameBoxes, string ancientName)
        {
            var ancientCardDef = AncientCardDef(gameBoxes);
            if (string.IsNullOrWhiteSpace(ancientName))
            {
                return ancientCardDef.FirstOrDefault();
            }

            foreach (var card in ancientCardDef.Where(card => card.UniqueID == ancientName)) return card;
            return ancientCardDef.FirstOrDefault();
        }

        public static MythosCardDataDefinition[] MytosCardDef(this IEnumerable<GameBoxDef> gameBoxes)
        {
            return gameBoxes.SelectMany(e => e.MythosCards).ToArray();
        }

        public static AncientCardDataDefinition[] AncientCardDef(this IEnumerable<GameBoxDef> gameBoxes)
        {
            return gameBoxes.SelectMany(e => e.AncientCards).ToArray();
        }
    }
}