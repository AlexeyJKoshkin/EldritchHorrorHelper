using EldritchHorror.Data.Provider;
using Sirenix.OdinInspector;
using System;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    public class DifficultTypesHolder : DataBox<DifficultTypeSO>
    {
#if UNITY_EDITOR
        [Button,ShowIf("Count",0)]
        void CreateAll()
        {
            foreach (MythosDifficultType influenceName in GameKit.Editor.EnumExtension.GetAllEnumElements<MythosDifficultType>())
            {
                var item = GameKit.Editor.EditorUtils.CreateSubAsset<DifficultTypeSO>(influenceName.ToString(), this);
                item.DifficultType = influenceName;
                this._collection.Add(item);
            }
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }
    
    [Flags]
    public enum MythosDifficultType
    {
        Simple = 0,
        Easy = 1 <<1,
        Hard = 2 <<2,
    }
}