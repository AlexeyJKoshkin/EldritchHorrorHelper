using System;
using System.Collections.Generic;

namespace EldritchHorror.Cards
{
    [Serializable]
    public class MythosCardGeneratorSettings : ICardGeneratorSettings
    {
        public List<SubMythosCardGenerationParameter> SubCardsData = new List<SubMythosCardGenerationParameter>();
        public CardType Type => CardType.Mythos;
    }

    [Serializable]
    public class SubMythosCardGenerationParameter
    {
        public int Count;
        public List<DifficultMythosCardSettings> DifficultMythosCardSettings;
        public MythosCardTypeSO TypeSo;
    }

    [Serializable]
    public class DifficultMythosCardSettings
    {
        public string CardIndexes;
        public MythosDifficultType DifficultType;
    }
}