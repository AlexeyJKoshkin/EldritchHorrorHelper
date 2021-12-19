#region

using EldritchHorror.Cards;
using EldritchHorror.Core;
using EldritchHorror.Entitas.Components;
using EldritchHorror.EntitasSystems;
using EldritchHorror.UI;
using System;
using UnityEngine;

#endregion

namespace EldritchHorror.GameplayStateMachine
{
    public class MythosPhase : MainGamePlayState
    {
        public override int Order => 40;
        private readonly IEldritchOmen _omen;


        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
            if (EldritchCardContext.isIsActiveMythos)
            {
                EldritchCardContext.isActiveMythosEntity.isIsActiveMythos = false;
            }

            //взять следующую карту
            var current = GameLoopContext.inGameMythosDeck.CardOrder.Dequeue();
            UpdateCardEntity(current);
        }

        private void UpdateCardEntity(EldritchCardEntity current)
        {
            current.ReplaceMythosState(MythosStateCardType.Open);
            current.isIsActiveMythos = true;
            Handle(current.mythos.Def);
            if (current.mythos.Def.IsProcess)
            {
                current.isInProcessType = true;
            }
            else
            {
                GameLoopContext.inGameMythosDeck.History.Push(current);
            }
            GameLoopContext.ReplaceInGameMythosDeck(GameLoopContext.inGameMythosDeck.History, GameLoopContext.inGameMythosDeck.CardOrder);
        }

        private void Handle(MythosCardDataDefinition def)
        {
            foreach (var influenceTypeSo in def.MythosCardType.InfluenceTypeSos)
                switch (influenceTypeSo.InfluenceType)
                {
                    case MythosInfluenceType.None: return;
                    case MythosInfluenceType.AdvanceOmen:
                        _omen.MoveNext();
                        break;
                    case MythosInfluenceType.SpawnGates:
                        break;
                    case MythosInfluenceType.MonsterSurge:
                        break;
                    case MythosInfluenceType.Reckoning:
                        break;
                    case MythosInfluenceType.SpawnClues:
                        break;
                    case MythosInfluenceType.PlaceRumorToken:
                        break;
                    case MythosInfluenceType.PlaceEldritchTokens:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }


        /// <summary>
        /// заканчиваем фазу мифов
        /// </summary>
        /// <param name="stateEntity"></param>
        protected override void OnExit(GameLoopEntity stateEntity)
        {
            base.OnExit(stateEntity);
        }

        public MythosPhase(Contexts gameLoopContext,  IEldritchOmen omen) : base(gameLoopContext)
        {
            _omen = omen;
        }
    }

    //фейковый подготовительный стейт
    public class PrepareGamePhase : MainGamePlayState
    {
        public override int Order => 10;

        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
            GameLoopContext.ReplaceTurnCounter(GameLoopContext.turnCounter.Turn +1);
            stateEntity.isPhaseReady = true;
        }


        public PrepareGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }

    //фейковый окончательный стейт
    public class EndTurnGamePhase : MainGamePlayState
    {
        public override int Order => 50;


        public EndTurnGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }

    public class ActionGamePhase : MainGamePlayState {
        public override int Order => 20;


        public ActionGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }

    public class EncounterGamePhase : MainGamePlayState
    {
        public override int Order => 30;


        protected override void OnEnter(GameLoopEntity stateEntity)
        {
            base.OnEnter(stateEntity);
          
            stateEntity.isPhaseReady = true;
        }

        protected override void OnExit(GameLoopEntity stateEntity)
        {
            base.OnExit(stateEntity);

        }


        public EncounterGamePhase(Contexts gameLoopContext) : base(gameLoopContext) { }
    }
}