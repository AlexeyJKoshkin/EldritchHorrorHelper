using System.Linq;
using EldritchHorror.Cards;
using EldritchHorror.Data.Provider;
using EldritchHorror.EntitasSystems;

namespace EldritchHorror {
    public class GameSettingsSelectionState : MainLoopState
    {
        private readonly IDataStorage _dataStorage;
        public override int Order => 20;

        public GameSettingsSelectionState(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        protected override void OnEnter(MainLoopEntity entity)
        {
            base.OnEnter(entity);
            var profile = entity.userProfile;
            var gameboxes = _dataStorage.All<GameBoxDef>()
                                        .Where(e => profile.GameSetCards.GameVersion.HasFlag(e.Version))
                                        .ToList();
            
            var ancientCard = gameboxes.FindBoss(profile.GameSetCards.AncientName);
            
            entity.ReplaceGameBoxes(gameboxes);
            entity.ReplaceSelectedBox(ancientCard);
            entity.isIsReady = true;
        }
    }
}