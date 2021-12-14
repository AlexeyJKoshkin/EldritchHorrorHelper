#region

using GameKit;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class MythosInfluenceTypeSO : BaseGameCartSO
    {
        [PreviewField(70, ObjectFieldAlignment.Right)]
        public Sprite Icon;
        [GameKit.ReadOnly] public MythosInfluenceType InfluenceType;
    }
}