using EldritchHorror.Data.Provider;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    [AllowMultiItems]
    public class MythosInfluenceTypeHolder : DataBox<MythosInfluenceTypeSO>
    {
        #if UNITY_EDITOR
        [Button,ShowIf("Count",0)]
        void CreateAll()
        {
            foreach (MythosInfluenceType influenceName in GameKit.Editor.EnumExtension.GetAllEnumElements(MythosInfluenceType.None))
            {
                var item = GameKit.Editor.EditorUtils.CreateSubAsset<MythosInfluenceTypeSO>(influenceName.ToString(), this);
                item.InfluenceType = influenceName;
                this._collection.Add(item);
            }
            UnityEditor.EditorUtility.SetDirty(this);
        }
        #endif
    }

    [Flags]
    public enum MythosInfluenceType
    {
        None = 0,
        AdvanceOmen = 1<<1,
        SpawnGates = 1<<2,
        MonsterSurge = 1<<3,
        Reckoning = 1 << 4,
        SpawnClues= 1 <<5,
        PlaceRumorToken =1 <<6,
        PlaceEldritchTokens=1<<7,
    }
}