#region

using EldritchHorror.Cards;
using EldritchHorror.Entitas.Components;
using EldritchHorror.EntitasSystems;
using System;
using UnityEngine;

#endregion

namespace EldritchHorror.GameplayStateMachine
{
    public class MythosPhase : MainGamePlayState
    {
        public override int Order => 40;
        private readonly IEldritchOmen _omen;

        public MythosPhase(IEldritchOmen omen,IEldritchUIController uiControllerHandler, Contexts gameLoopContext) : base(gameLoopContext,uiControllerHandler)
        {
            _omen = omen;
        }

        public override void Enter(GameLoopEntity stateEntity)
        {
            base.Enter(stateEntity);
            UIControllerHandler.EnterGamePhase(this, stateEntity);
            if (EldritchCardContext.isIsActiveMythos)
            {
                EldritchCardContext.isActiveMythosEntity.isIsActiveMythos = false;
            }

            //взять следующую карту
            var current = GameLoopContext.inGameMythosDeck.List.Dequeue();
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
            GameLoopContext.ReplaceInGameMythosDeck(GameLoopContext.inGameMythosDeck.History, GameLoopContext.inGameMythosDeck.List);
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
        public override void Exit(GameLoopEntity stateEntity)
        {
            base.Exit(stateEntity);
            UIControllerHandler.ExitGamePhase(this,stateEntity);
        }
    }

    //фейковый подготовительный стейт
    public class PrepareGamePhase : MainGamePlayState
    {
        public override int Order => 10;
       
        public override void Enter(GameLoopEntity stateEntity)
        {
            base.Enter(stateEntity);
            GameLoopContext.ReplaceTurnCounter(GameLoopContext.turnCounter.Turn +1);
            stateEntity.isPhaseReady = true;
        }

        public PrepareGamePhase(Contexts gameLoopContext, IEldritchUIController uiControllerHandler) : base(gameLoopContext, uiControllerHandler) { }
    }

    //фейковый окончательный стейт
    public class EndTurnGamePhase : MainGamePlayState
    {
        public override int Order => 50;

        public EndTurnGamePhase(Contexts gameLoopContext, IEldritchUIController uiControllerHandler) : base(gameLoopContext, uiControllerHandler) { }
    }

    public class ActionGamePhase : MainGamePlayState {
        public override int Order => 20;

        public ActionGamePhase(Contexts gameLoopContext, IEldritchUIController uiControllerHandler) : base(gameLoopContext, uiControllerHandler) { }
    }

    public class EncounterGamePhase : MainGamePlayState
    {
        public override int Order => 30;
      
  

        public override void Enter(GameLoopEntity stateEntity)
        {
            base.Enter(stateEntity);
            UIControllerHandler.EnterGamePhase(this,stateEntity);
            stateEntity.isPhaseReady = true;
        }

        public override void Exit(GameLoopEntity stateEntity)
        {
            base.Exit(stateEntity);
            UIControllerHandler.ExitGamePhase(this,stateEntity);
        }

        public EncounterGamePhase(Contexts gameLoopContext, IEldritchUIController uiControllerHandler) : base(gameLoopContext, uiControllerHandler) { }
    }
}