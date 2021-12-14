#region

using Sirenix.OdinInspector;
using System;
using UnityEngine;

#endregion

namespace EldritchHorror.Cards
{
    public class AncientCardDataDefinition : BaseCardDataSO
    {
        public AncientActMythosCardSettings AncientActMythosSettings;
        public Sprite BackSprite;
    }

    [Serializable]
    public class AncientActMythosCardSettings
    {
        [SerializeField] public MythosTypeCount[] First = new MythosTypeCount[3];

        [SerializeField] public MythosTypeCount[] Second = new MythosTypeCount[3];

        [SerializeField, MaxValue(3)] public MythosTypeCount[] Third = new MythosTypeCount[3];
    }

    [Serializable]
    public struct MythosTypeCount
    {
        public MythosCardTypeSO TypeSo;
        public int Count;
    }
}