using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem.Helpers
{
    public interface IGameBoxContentsDefinitionGenerator
    {
        void Generate();
    }

    public abstract class CardGenerator<TSettings> : ScriptableObject ,IGameBoxContentsDefinitionGenerator where TSettings: ICardGenerateSettings
    {
        public GamePartSO GamePartSo;

       protected string RootFolderPath = "";

        public Texture2D Texture2D;
        
        [Button]
        public void Generate()
        {
            GenerateFolder();
            var settings = GamePartSo.CardGenerateSettingses.FirstOrDefault(o => o is TSettings);
            if(settings == default) return;
            var list = LoadSprites();
            GenerateCards(list, (TSettings)(settings));
        }

        protected abstract void GenerateCards(List<Sprite> list, TSettings settings);
        

        private void GenerateFolder()
        {
            RootFolderPath = $"{GamePartSo.FolderPath}/Mythos";
            EditorUtils.CreateAssetFolder(RootFolderPath);
        }
        
        private List<Sprite> LoadSprites()
        {
            var list = EditorUtils.LoadAllAssetsFrom<Sprite>(Texture2D).ToList();
            list.Sort((o1,o2)=> HumanStringSorter.InnerCompare(o1.name, o2.name));
            return list;
        }
    }

    public class MythosCardGenerator : CardGenerator<MythosCardGeneratorSettings>
    {
        private void CreateCard(MythosCardTypeSO mythosCardTypeSo, Sprite sprite)
        {
            string nameObject = $"{RootFolderPath}/{sprite.name}.asset" ;
            var card = EditorUtils.LoadAsset<MytosCardDataSO>(nameObject, true);
            card.FrontSprite = sprite;
            card.MythosCardType = mythosCardTypeSo;
            EditorUtility.SetDirty(card);
        }


        protected override void GenerateCards(List<Sprite> list, MythosCardGeneratorSettings settings)
        {
            int currentIndex = 0;
            foreach (var mythosCard in settings.SubCardsData)
            {
                for (var i = 0; i < mythosCard.Count; i++)
                {
                    CreateCard(mythosCard.TypeSo, list[currentIndex]);
                    currentIndex++;
                }
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
    
}