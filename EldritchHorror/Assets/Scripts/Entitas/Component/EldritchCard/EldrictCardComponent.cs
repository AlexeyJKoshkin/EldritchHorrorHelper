#region

using EldritchHorror.Cards;
using EldritchHorror.Cards.Data;
using Entitas;
using UnityEngine;

#endregion

namespace EldritchHorror.Entitas.Components
{
    [EldritchCard]
    public class EncounterComponent : IComponent
    {
        public EncounterCardDefinition CardDefinition;
        public EncounterTypeSO Type => CardDefinition.EncounterType;
    }

    [EldritchCard]
    public class ClickComponent : IComponent { }

    public abstract class SpriteComponent : IComponent
    {
        public Sprite Sprite;
    }

    [EldritchCard]
    public class FrontSpriteComponent : SpriteComponent { }

    [EldritchCard]
    public class BackSpriteComponent : SpriteComponent { }
}