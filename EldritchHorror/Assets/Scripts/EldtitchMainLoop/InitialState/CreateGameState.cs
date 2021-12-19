using System;
using System.Collections.Generic;
using System.Linq;
using EldritchHorror.Cards;
using EldritchHorror.EntitasSystems;

namespace EldritchHorror {
    public class CreateGameState : MainLoopState
    {
        private readonly Contexts _contexts;
        public override int Order => 30;
        
        private readonly IMythosCardEntityGenerator _mythosCardEntityGenerator;

        public CreateGameState(Contexts contexts, IMythosCardEntityGenerator mythosCardEntityGenerator)
        {
            _contexts                  = contexts;
            _mythosCardEntityGenerator = mythosCardEntityGenerator;
        }

        protected override void OnEnter(MainLoopEntity entity)
        {
            base.OnEnter(entity);

            CreateMasterEntity(_contexts.gameLoop);
            CreateMythosEntity(entity);
            CreateEncounters(entity.gameBoxes.GameBoxes);
            entity.isIsReady = true;
        }

        private void CreateMythosEntity(MainLoopEntity e)
        {
            // cгeненерировали entity -карты мифов для игры
            var                       mythosCardDef = _mythosCardEntityGenerator.GenerateBySave(e.gameBoxes.GameBoxes, e.AncientCardDefinition.AncientCard, e.userProfile.MythosCards);
            Queue<EldritchCardEntity> queue         = new Queue<EldritchCardEntity>();
            //из даннных карты мифа создали entity и впихнули его в очередь
            mythosCardDef.Select(_contexts.eldritchCard.CreateMythosCard).ForEach(queue.Enqueue);

            _contexts.gameLoop.masterEntityEntity.ReplaceInGameMythosDeck(new Stack<EldritchCardEntity>(), queue);
        }
        
        private void CreateEncounters(List<GameBoxDef> gameboxes)
        {
            var me = _contexts.gameLoop.masterEntityEntity;
            AddCard(me.AddAmericaCardDeck, gameboxes.SelectMany(o => o.AmericaEncounterCard).ToList());
            AddCard(me.AddAsiaAustraliaCardDeck, gameboxes.SelectMany(o => o.Asia_AustraliaEncounterCard).ToList());
            AddCard(me.AddGeneralCardDeck, gameboxes.SelectMany(o => o.GeneralEncounterCard).ToList());
            AddCard(me.AddOtherWorldCardDeck, gameboxes.SelectMany(o => o.OtherWorldEncounterCard).ToList());
            AddCard(me.AddEuropeCardDeck, gameboxes.SelectMany(o => o.EuropeEncounterCard).ToList());
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

        private void CreateMasterEntity(GameLoopContext contextsGameLoop)
        {
            if (contextsGameLoop.isMasterEntity)
            {
                contextsGameLoop.masterEntityEntity.Destroy();
            }
            contextsGameLoop.isMasterEntity = true;
        }
    }
}