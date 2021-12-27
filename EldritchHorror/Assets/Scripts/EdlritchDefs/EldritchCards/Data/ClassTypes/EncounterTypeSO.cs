using EldritchHorror.Cards;
using GameKit;
using UnityEngine;

namespace EldritchHorror.Cards.Data {
    [AllowMultiItems]
    public class EncounterTypeSO : BaseGameCartSO
    {
        [CenteredSpriteDrawer(100, 250)]
        public Sprite Back;
    }
}