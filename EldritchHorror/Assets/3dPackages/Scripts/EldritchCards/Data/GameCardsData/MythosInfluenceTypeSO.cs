using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    [AllowMultiItems]
    public class MythosInfluenceTypeSO : BaseGameCartSO
    {
        [GameKit.ReadOnly]
        public MythosInfluenceType InfluenceType;

        [PreviewField(70,ObjectFieldAlignment.Right)]
        public Sprite Icon;
    }
}