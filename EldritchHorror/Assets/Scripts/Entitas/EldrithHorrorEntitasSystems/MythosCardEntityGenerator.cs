using EldritchHorror.Cards;
using EldritchHorror.Data.Provider;
using EldritchHorror.UserProfile;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{
    public interface IMythosCardEntityGenerator
    {
        List<MythosCardDataDefinition> GenerateBySave(IUserProfileData profile);
    }

    public class MythosCardEntityGenerator : IMythosCardEntityGenerator
    {
        private readonly Contexts _contexts;
        private readonly IDataStorage _dataStorage;

        public MythosCardEntityGenerator(Contexts contexts, IDataStorage dataStorage)
        {
            _contexts = contexts;
            _dataStorage = dataStorage;
        }

        public List<MythosCardDataDefinition> GenerateBySave(IUserProfileData profile)
        {
            var gameboxes = _dataStorage.All<GameBoxDef>()
                                        .Where(e => profile.GameSetCards.GameVersion.HasFlag(e.Version))
                                        .ToList();
            var ancientCard = gameboxes.FindBoss(profile.GameSetCards.AncientName);
            var mythosCards = gameboxes.SelectMythos(profile.MythosCards)
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