using Sirenix.OdinInspector;
using UnityEngine;

namespace EldritchHorror.Cards
{
    //настройки карты типа мифы
    public class MythosTypeSO : CardTypeSO
    {
        [PreviewField(100, ObjectFieldAlignment.Center)]
        public Sprite BackSprite;
        public override CardType Type => CardType.Mythos;
    }
}