using GameKit;
using GameKit.Editor;
using System.Collections.Generic;
using UnityEngine;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    //типы карты мифов
    public class MythosCardTypeSO : BaseGameCartSO
    {
        public Sprite Back;
        public List<MythosInfluenceTypeSO> InfluenceTypeSos = new List<MythosInfluenceTypeSO>();
    }
}