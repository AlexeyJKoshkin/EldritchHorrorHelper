#region

using EdlritchDefs.EldritchCards.Data.ClassTypes;
using EldritchHorror.Cards;
using Entitas;
using Entitas.CodeGeneration.Attributes;
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