using GameKit;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class MythosInfluenceTypeSO : BaseGameCartSO
    {
        [PreviewField(70, ObjectFieldAlignment.Right)]
        public Sprite Icon;
        [GameKit.ReadOnly] public MythosInfluenceType InfluenceType;
    }
}