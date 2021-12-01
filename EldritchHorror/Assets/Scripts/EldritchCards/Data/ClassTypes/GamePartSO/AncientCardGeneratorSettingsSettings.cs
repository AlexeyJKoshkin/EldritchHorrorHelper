using System;

namespace EldritchHorror.Cards
{
    [Serializable]
    public class AncientCardGeneratorSettingsSettings : ICardGeneratorSettings
    {
        public CardType Type => CardType.Mythos;
    }
}