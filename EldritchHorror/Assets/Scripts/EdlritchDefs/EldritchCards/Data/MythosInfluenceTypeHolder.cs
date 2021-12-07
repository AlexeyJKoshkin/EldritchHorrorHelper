using EldritchHorror.Data.Provider;
using GameKit;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using UnityEditor;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class MythosInfluenceTypeHolder : DataBox<MythosInfluenceTypeSO>
    {
#if UNITY_EDITOR
        [Button, ShowIf("Count", 0)]
        private void CreateAll()
        {
            foreach (MythosInfluenceType influenceName in EnumExtension.GetAllEnumElements(MythosInfluenceType.None))
            {
                var item = EditorUtils.CreateSubAsset<MythosInfluenceTypeSO>(influenceName.ToString(), this);
                item.InfluenceType = influenceName;
                _collection.Add(item);
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }

    [Flags]
    public enum MythosInfluenceType
    {
        None = 0,
        AdvanceOmen = 1 << 1,
        SpawnGates = 1 << 2,
        MonsterSurge = 1 << 3,
        Reckoning = 1 << 4,
        SpawnClues = 1 << 5,
        PlaceRumorToken = 1 << 6,
        PlaceEldritchTokens = 1 << 7
    }
}