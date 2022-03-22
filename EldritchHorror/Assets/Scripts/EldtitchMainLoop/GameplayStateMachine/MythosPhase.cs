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

        /// <summary>
        /// Обработкать действие карты мифа 
        /// </summary>
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
}