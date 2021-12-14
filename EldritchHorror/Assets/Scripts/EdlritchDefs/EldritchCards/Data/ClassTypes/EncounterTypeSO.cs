using EldritchHorror.Cards;
using GameKit;
using UnityEngine;

namespace EdlritchDefs.EldritchCards.Data.ClassTypes {
    [AllowMultiItems]
    public class EncounterTypeSO : BaseGameCartSO
    {
        [CenteredSpriteDrawer(100, 250)]
        public Sprite Back;
    }
}