using EdlritchDefs.EldritchCards.Data.ClassTypes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EldritchHorror.Cards {
    [Serializable]
    public class EncounterGeneratorSettings : ICardGeneratorSettings
    {
        public CardType Type => CardType.EncounterCards;
        public List<SimpleEncounterGeneratorSettings> SimpleEncounter= new List<SimpleEncounterGeneratorSettings>();
        
       // public List<ExpeditionEncounterGeneratorSettings> ExpeditionEncounter = new List<ExpeditionEncounterGeneratorSettings>();
    }

    [Serializable]
    public class SimpleEncounterGeneratorSettings
    {
        public EncounterTypeSO Type;
        public Texture2D Texture;
    }

    [Serializable]
    public class ExpeditionEncounterGeneratorSettings
    {
        public ExpeditionTypeSo ExpeditionTypeSo;
        public Texture2D Texture2D;
        public string CardIndexes;
    }
}