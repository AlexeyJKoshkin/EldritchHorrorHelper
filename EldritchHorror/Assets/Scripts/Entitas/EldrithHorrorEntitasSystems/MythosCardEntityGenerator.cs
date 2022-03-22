#region

using System.Collections.Generic;
using System.Linq;
using EldritchHorror.Cards;
using EldritchHorror.Data.Provider;
using EldritchHorror.UserProfile;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public interface IMythosCardEntityGenerator
    {
        List<MythosCardDataDefinition> GenerateBySave(List<GameBoxDef> gameboxes, AncientCardDataDefinition ancientCard, MythosCardSaveSettings mythosCardSaveSettings);
    }

    public class MythosCardEntityGenerator : IMythosCardEntityGenerator
    {
        private readonly IDataStorage _dataStorage;

        public MythosCardEntityGenerator(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }


        public List<MythosCardDataDefinition> GenerateBySave(List<GameBoxDef> gameboxes, AncientCardDataDefinition ancientCard, MythosCardSaveSettings mythosCardSaveSettings)
        {
            var mythosCards = gameboxes.SelectMythos(mythosCardSaveSettings)
                                       .GroupBy(o => o.MythosCardType)
                                       .ToDictionary(o => o.Key, o => o.ToList());
            return Generate(ancientCard.AncientActMythosSettings, mythosCards);
        }


        public List<MythosCardDataDefinition> Generate(AncientActMythosCardSettings ancientCardAncientActMythosSettings, Dictionary<MythosCardTypeSO, List<MythosCardDataDefinition>> mythosCards)
        {
            List<MythosCardDataDefinition> allCards = new List<MythosCardDataDefinition>();
            allCards.AddFrom(mythosCards, ancientCardAncientActMythosSettings.First);
            allCards.AddFrom(mythosCards, ancientCardAncientActMythosSettings.Second);
            allCards.AddFrom(mythosCards, ancientCardAncientActMythosSettings.Third);
            return allCards;
        }
    }
}