using EldritchHorror.Cards.Data;
using GameKit;
using UnityEngine;

namespace EldritchHorror.Cards {
    /// <summary>
    /// Базовые карты испытаний
    /// </summary>
    public class EncounterCardDefinition : BaseCardDataSO
    {
      //  [FoldoutGroup("Sprites")]
      //  [PreviewField(50,ObjectFieldAlignment.Left)]
        [CenteredSpriteDrawer(300,500)]
        public Sprite FrontSprite;
        public EncounterTypeSO EncounterType;
    }
}