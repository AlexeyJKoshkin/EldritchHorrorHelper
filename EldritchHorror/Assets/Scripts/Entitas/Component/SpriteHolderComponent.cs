#region

using System;
using Entitas;
using UnityEngine;

#endregion

namespace EldritchHorror.Entitas.Components
{
    [Serializable, EldritchWorldMap]
    public class SpriteHolderComponent : IComponent
    {
        public Sprite Sprite;
    }
}