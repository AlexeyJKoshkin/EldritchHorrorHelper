using Editor.EldrtichHorrorEditorEcosystem.EldritchCards.Data;
using System;
using System.Collections.Generic;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    [Serializable]
    public class MythosCardGeneratorSettings : ICardGenerateSettings
    {
        public CardType Type => CardType.Mythos;

        public List<SubMythosCardGenerationParameter> SubCardsData = new List<SubMythosCardGenerationParameter>();
    }

    [Serializable]
    public class SubMythosCardGenerationParameter
    {
        public int Count;
        public MythosCardTypeSO TypeSo;
    }
}