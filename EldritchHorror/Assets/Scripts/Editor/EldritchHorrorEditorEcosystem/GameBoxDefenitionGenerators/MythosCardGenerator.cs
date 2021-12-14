#region

using EdlritchDefs.EldritchCards.Data.ClassTypes;
using EldritchHorror.Cards;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

#endregion

namespace EldritchHorrorEditorEcosystem.Helpers
{
    public interface IGameBoxContentsDefinitionGenerator
    {
        void Generate();
    }

    public class MythosCardGenerator : CardGenerator<MythosCardGeneratorSettings, MythosTypeSO>, IGameBoxContentsDefinitionGenerator
    {
        [SerializeField] private DifficultTypesHolder _difficultTypesHolder;
        public Texture2D Texture2D;

        public override string PropertyName => "MythosCards";


        public override void GenerateCurrent(GameBoardGeneratorSettings current)
        {
            GenerateFolder("Mythos");
            var settings = current.Settings;
            if (settings == null)
            {
                return;
            }

            var tempSpiteList = CardGeneratorUtility.LoadSprites(Texture2D);
            GenerateCards(settings, tempSpiteList);
        }

        protected void GenerateCards(MythosCardGeneratorSettings settings, List<Sprite> sprites)
        {
            int currentIndex = 0;
            foreach (var parameter in settings.SubCardsData)
                for (var i = 0; i < parameter.Count; i++)
                {
                    BuildCard(parameter, sprites[currentIndex], i);
                    currentIndex++;
                }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private void BuildCard(SubMythosCardGenerationParameter parameter, Sprite sprite, int index)
        {
            var card = CreateCard<MythosCardDataDefinition>(sprite.name);

            var mythosType         = parameter.TypeSo;
            var createTypeSelector = CreateTypeSelector(parameter.DifficultMythosCardSettings);
            var difficcultType     = createTypeSelector.FirstOrDefault(o => o.indexex.Contains(index)).type;
            difficcultType = difficcultType == MythosDifficultType.None ? MythosDifficultType.Simple : difficcultType;
            var difficultSO = _difficultTypesHolder.Collection.FirstOrDefault(o => o.DifficultType == difficcultType);

            SetData(card, mythosType, difficultSO, sprite);
            EditorUtility.SetDirty(card);
        }

        private List<(MythosDifficultType type, List<int> indexex)> CreateTypeSelector(List<DifficultMythosCardSettings> parameterDifficultMythosCardSettings)
        {
            List<(MythosDifficultType type, List<int> indexex)> result = new List<(MythosDifficultType type, List<int> indexex)>();
            foreach (var param in parameterDifficultMythosCardSettings)
            {
                int[] indexes = param.CardIndexes
                                     .Split(',')
                                     .Where(e => !string.IsNullOrWhiteSpace(e))
                                     .Select(int.Parse)
                                     .ToArray();
                result.Add((param.DifficultType, new List<int>(indexes)));
            }

            return result;
        }

        private void SetData(MythosCardDataDefinition card, MythosCardTypeSO mythosType, DifficultTypeSO difficcultType, Sprite sprite)
        {
            card.FrontSprite    = sprite;
            card.MythosCardType = mythosType;
            card.DifficultType  = difficcultType;
        }

       
    }

    public abstract class EncounterCardGenerator : CardGenerator< EncounterGeneratorSettings, EncounterCardTypeSO>
    {
      
    }

}
     