#region

using GameKit;
using System.Collections.Generic;
using UnityEngine;

#endregion

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