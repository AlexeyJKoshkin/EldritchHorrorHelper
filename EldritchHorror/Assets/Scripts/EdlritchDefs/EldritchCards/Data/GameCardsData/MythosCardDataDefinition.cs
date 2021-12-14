using Sirenix.OdinInspector;
using UnityEngine;

namespace EldritchHorror.Cards
{
    public class MythosCardDataDefinition : BaseCardDataSO
    {
        [FoldoutGroup("Sprites")]
        [PreviewField(50,ObjectFieldAlignment.Left)]
        public Sprite FrontSprite;
        public DifficultTypeSO DifficultType;
        public bool IsProcess;
        public MythosCardTypeSO MythosCardType;
    }
}