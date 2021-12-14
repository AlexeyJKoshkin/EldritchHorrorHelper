#region

using EldritchHorror.Cards;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

#endregion

namespace EldritchHorrorEditorEcosystem.Helpers
{
    public static class CardGeneratorUtility
    {
        public static List<Sprite> LoadSprites(Texture2D texture2D)
        {
            var list = EditorUtils.LoadAllAssetsFrom<Sprite>(texture2D).ToList();
            list.Sort((o1, o2) => HumanStringSorter.InnerCompare(o1.name, o2.name));
            return list;
        }
    }

    public abstract class CardGenerator<TSettings, TTypeSo> : ScriptableObject where TTypeSo : CardTypeSO 
    {
        public List<GameBoardGeneratorSettings> BoardSettings = new List<GameBoardGeneratorSettings>();
        public TTypeSo CardTypeSo;
        [SerializeField] public GameBoxDef gameBoxDef;

        [GameKit.ReadOnly] public string RootFolderPath = "";

        public abstract string PropertyName { get; }

        [Button]
        public void Generate()
        {
            if (CardTypeSo == null)
            {
                return;
            }

            var current = BoardSettings.Find(o => o.GamePart == gameBoxDef);
            if (current.GamePart == null)
            {
                return;
            }

            GenerateCurrent(current);
        }

        [Button]
        public void UpdatePartSOWithData()
        {
            if (CardTypeSo == null)
            {
                return;
            }

            UpdateCardList();
            EditorUtility.SetDirty(gameBoxDef);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }


        public abstract void GenerateCurrent(GameBoardGeneratorSettings current);

        public static T LoadAssetOrCreate<T>(string path) where T : BaseCardDataSO
        {
            var asset = EditorUtils.LoadAsset<T>(path, true);
            asset.Type = EditorUtils.FindAsset<TTypeSo>();
            return asset;
        }
        
        
        public  T CreateCard<T>( string spriteName) where T : BaseCardDataSO
        {
            string nameObject = $"{RootFolderPath}/{spriteName}.asset";
            return LoadAssetOrCreate<T>(nameObject);
        }


        public virtual void UpdateCardList()
        {
            SerializedObject serializedObject = new SerializedObject(gameBoxDef);
            var              proprety         = serializedObject.FindProperty(PropertyName);
            if (proprety == null) throw new NullReferenceException(PropertyName + " Is null");
            proprety.ClearArray();
            var list = EditorUtils.LoadAllAssetsAtPath<ScriptableObject>(RootFolderPath, true).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                proprety.InsertArrayElementAtIndex(i);
                proprety.GetArrayElementAtIndex(i).objectReferenceValue = list[i];
            }

            serializedObject.ApplyModifiedProperties();
        }


        protected virtual void GenerateFolder(string folderName)
        {
            RootFolderPath = $"{gameBoxDef.FolderPath}/{folderName}";
            EditorUtils.CreateAssetFolder(RootFolderPath);
        }

        [Serializable]
        public struct GameBoardGeneratorSettings
        {
            public GameBoxDef GamePart;
            public TSettings Settings;
        }
    }
}