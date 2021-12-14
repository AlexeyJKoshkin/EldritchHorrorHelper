#region

using EdlritchDefs.EldritchCards.Data.ClassTypes;
using EldritchHorror.Cards;
using EldritchHorror.Data.Provider;
using EldritchHorror.UserProfile;
using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace EldritchHorror.EntitasSystems
{
    /// <summary>
    ///     Инициализация игрового состояния.
    ///     запускается после того как MainLoop стал IsReady
    /// </summary>
    public class GameLoopInitializeSystem : ReactiveSystem<MainLoopEntity>
    {
        private readonly Contexts _contexts;
        private readonly IDataStorage _dataStorage;
        private readonly IMythosCardEntityGenerator _mythosCardEntityGenerator;

        public GameLoopInitializeSystem(Contexts contexts, IDataStorage dataStorage, IMythosCardEntityGenerator mythosCardEntityGenerator) : base(contexts.mainLoop)
        {
            _contexts                  = contexts;
            _dataStorage = dataStorage;
            _mythosCardEntityGenerator = mythosCardEntityGenerator;
        }


        protected override ICollector<MainLoopEntity> GetTrigger(IContext<MainLoopEntity> context)
        {
            return context.CreateCollector(MainLoopMatcher.AllOf(MainLoopMatcher.UserProfile, MainLoopMatcher.IsReady));
        }

        protected override bool Filter(MainLoopEntity entity)
        {
            return true;
        }

        protected override void Execute(List<MainLoopEntity> entities)
        {
            var profile       = entities.SingleEntity().userProfile;
            CreateMainLoopEntity();
            
            var gameboxes = _dataStorage.All<GameBoxDef>()
                                        .Where(e => profile.GameSetCards.GameVersion.HasFlag(e.Version))
                                        .ToList();
            var ancientCard = gameboxes.FindBoss(profile.GameSetCards.AncientName);
            
            CreateMythosEntity(gameboxes, ancientCard, profile.MythosCards);
            
            CreateEncounters(gameboxes);
        }

        private void CreateEncounters(List<GameBoxDef> gameboxes)
        {
            AddCard(_contexts.gameLoop.masterEntityEntity.AddAmericaCardDeck, gameboxes.SelectMany(o => o.AmericaEncounterCard).ToList());
            AddCard(_contexts.gameLoop.masterEntityEntity.AddAsiaAustraliaCardDeck, gameboxes.SelectMany(o => o.Asia_AustraliaEncounterCard).ToList());
            AddCard(_contexts.gameLoop.masterEntityEntity.AddGeneralCardDeck, gameboxes.SelectMany(o => o.GeneralEncounterCard).ToList());
            AddCard(_contexts.gameLoop.masterEntityEntity.AddOtherWorldCardDeck, gameboxes.SelectMany(o => o.OtherWorldEncounterCard).ToList());
            AddCard(_contexts.gameLoop.masterEntityEntity.AddEuropeCardDeck, gameboxes.SelectMany(o => o.EuropeEncounterCard).ToList());
        }

        private void AddCard(Action<Queue<EldritchCardEntity>> addComponent, List<EncounterCardDefinition> cardDefinitions)
        {
            Queue<EldritchCardEntity> encounters = new Queue<EldritchCardEntity>();
            while (cardDefinitions.Count > 0)
            {
                encounters.Enqueue(_contexts.eldritchCard.CreateEncounter(cardDefinitions.GetRandom(true)));
            }
            addComponent(encounters);
        }

        private void CreateMythosEntity(List<GameBoxDef> gameboxes, AncientCardDataDefinition ancientCard, MythosCardSaveSettings profileMythosCards)
        {
            var mythosCardDef = _mythosCardEntityGenerator.GenerateBySave(gameboxes,ancientCard, profileMythosCards); // cгeненерировали entity -карты мифов для игры
            
            Queue<EldritchCardEntity> queue = new Queue<EldritchCardEntity>();
            //из даннных карты мифа создали entity и впихнули его в очередь
            mythosCardDef.Select(_contexts.eldritchCard.CreateMythosCard).ForEach(queue.Enqueue);

            _contexts.gameLoop.masterEntityEntity.ReplaceInGameMythosDeck(new Stack<EldritchCardEntity>(), queue);
        }

        private void CreateMainLoopEntity()
        {
            _contexts.gameLoop.masterEntityEntity.AddOmenState(0);
        }
    }
}