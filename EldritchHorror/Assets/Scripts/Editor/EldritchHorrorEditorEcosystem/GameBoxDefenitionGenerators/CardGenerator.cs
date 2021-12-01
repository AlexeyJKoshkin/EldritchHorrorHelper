using EldritchHorror.Cards;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

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

    public abstract class CardGenerator<TCardDefinition, TSettings, TTypeSo> : ScriptableObject where TTypeSo : CardTypeSO where TCardDefinition : BaseCardDataSO
    {
        public List<GameBoardGeneratorSettings> BoardSettings = new List<GameBoardGeneratorSettings>();
        public TTypeSo CardTypeSo;
        [SerializeField] private GameBoxDef gameBoxDef;

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

        public static TCardDefinition LoadAssetOrCreate(string path)
        {
            var asset = EditorUtils.LoadAsset<TCardDefinition>(path, true);
            asset.Type = EditorUtils.FindAsset<TTypeSo>();
            return asset;
        }


        public void UpdateCardList()
        {
            SerializedObject serializedObject = new SerializedObject(gameBoxDef);
            var proprety = serializedObject.FindProperty(PropertyName);
            proprety.ClearArray();
            var list = EditorUtils.LoadAllAssetsAtPath<TCardDefinition>(RootFolderPath, true).ToList();
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