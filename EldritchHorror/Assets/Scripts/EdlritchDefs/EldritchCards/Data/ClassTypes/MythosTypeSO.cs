#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

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