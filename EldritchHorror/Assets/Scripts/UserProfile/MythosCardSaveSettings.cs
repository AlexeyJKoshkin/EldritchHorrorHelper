using EldritchHorror.Cards;
using System;
using System.Collections.Generic;

namespace EldritchHorror.UserProfile
{
    [Serializable]
    public class MythosCardSaveSettings
    {
        // карты каких типов исполись
        public MythosDifficultType DifficultType = MythosDifficultType.Easy | MythosDifficultType.Hard | MythosDifficultType.Simple;

        public List<string> ExcludedCards = new List<string>();

        public override string ToString()
        {
            return $"{DifficultType} {ExcludedCards.Count}";
        }
    }
}