using EldritchHorror.Data.Provider;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using UnityEditor;

namespace EldritchHorror.Cards
{
    public class DifficultTypesHolder : DataBox<DifficultTypeSO>
    {
#if UNITY_EDITOR
        [Button, ShowIf("Count", 0)]
        private void CreateAll()
        {
            foreach (MythosDifficultType influenceName in EnumExtension.GetAllEnumElements(MythosDifficultType.None))
            {
                var item = EditorUtils.CreateSubAsset<DifficultTypeSO>(influenceName.ToString(), this);
                item.DifficultType = influenceName;
                _collection.Add(item);
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }

    [Flags]
    public enum MythosDifficultType
    {
        None = 0,
        Simple = 1 << 1,
        Easy = 1 << 2,
        Hard = 1 << 3
    }
}