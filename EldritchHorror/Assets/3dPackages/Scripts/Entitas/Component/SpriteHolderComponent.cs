using Entitas;
using System;
using UnityEngine;

namespace EldritchHorror.Entitas.Components
{
    [Serializable]
    [EldritchWorldMap]
    public class SpriteHolderComponent : IComponent
    {
        public Sprite Sprite;
    }
}