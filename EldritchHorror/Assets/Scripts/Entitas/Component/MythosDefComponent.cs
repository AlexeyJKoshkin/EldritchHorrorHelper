using EldritchHorror.Cards;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace EldritchHorror.Entitas.Components
{
    [MythosCard]
    public class MythosDefComponent : IComponent
    {
        public MythosCardDataDefinition Def;
        public DifficultTypeSO DifficultType => Def.DifficultType;
        public MythosCardTypeSO MythosType => Def.MythosCardType;
    }

    [MythosCard, Unique]
    public class IsActiveMythosComponent : IComponent
    {
    }

    [MythosCard]
    public class IsDraftMythosComponent : IComponent
    {
    }

    public enum MythosStateCardType
    {
        Lock,
        Open,
        Resolved
    }

    [MythosCard]
    public class MythosStateComponent : IComponent
    {
        public MythosStateCardType State;
    }
}