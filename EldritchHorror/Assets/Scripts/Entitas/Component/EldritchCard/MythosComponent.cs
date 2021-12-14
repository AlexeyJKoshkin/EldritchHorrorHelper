using EldritchHorror.Cards;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace EldritchHorror.Entitas.Components {
    [EldritchCard]
    public class MythosComponent : IComponent
    {
        public MythosCardDataDefinition Def;
        public DifficultTypeSO DifficultType => Def.DifficultType;
        public MythosCardTypeSO MythosType => Def.MythosCardType;
    }
    
    [EldritchCard, Unique]
    public class IsActiveMythosComponent : IComponent { }
    
    /// <summary>
    /// Миф- процесс. т.е. карта остается на столе, пока ее не снимут
    /// </summary>
    [EldritchCard]
    public class InProcessTypeComponent : IComponent { }

    [EldritchCard]
    public class IsDraftMythosComponent : IComponent { }
    [EldritchCard]
    public class MythosStateComponent : IComponent
    {
        public MythosStateCardType State;
    }
}