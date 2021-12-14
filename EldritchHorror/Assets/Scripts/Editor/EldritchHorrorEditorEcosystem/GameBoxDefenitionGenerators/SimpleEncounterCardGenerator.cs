using EdlritchDefs.EldritchCards.Data.ClassTypes;
using EldritchHorror.Cards;
using GameKit.Editor;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem.Helpers
{
    [CreateAssetMenu]
    public class SimpleEncounterCardGenerator : EncounterCardGenerator
    {
        public override string PropertyName => _propertyName;

        private string _propertyName;

        public override void GenerateCurrent(GameBoardGeneratorSettings current)
        {
            GenerateFolder("Encounter");
            var settings = current.Settings;
            if (settings == null)
            {
                return;
            }

            CreateSimpleEncounter(settings.SimpleEncounter);
        //    CreateExpedition(settings.ExpeditionEncounter);
        }

        private void CreateExpedition(List<ExpeditionEncounterGeneratorSettings> settingsExpeditionEncounter)
        {
            foreach (var binding in settingsExpeditionEncounter)
            {
                RootFolderPath = $"{gameBoxDef.FolderPath}/Encounter/Expedition";
                EditorUtils.CreateAssetFolder(RootFolderPath);
                var tempSpiteList = CardGeneratorUtility.LoadSprites(binding.Texture2D);
                
                int[] indexes = binding.CardIndexes
                                       .Split(',')
                                       .Where(e => !string.IsNullOrWhiteSpace(e))
                                       .Select(int.Parse)
                                       .ToArray();

            }
        }
        private void CreateSimpleEncounter(List<SimpleEncounterGeneratorSettings> settingsSimpleEncounter)
        {
            foreach (var binding in settingsSimpleEncounter)
            {
                SetCurrentRoot(binding.Type);
                EditorUtils.CreateAssetFolder(RootFolderPath);
                var tempSpiteList = CardGeneratorUtility.LoadSprites(binding.Texture);
                foreach (var sprite in tempSpiteList)
                {
                    BuildSimpleCard(sprite, binding.Type);
                }
            }
        }

        private void BuildSimpleCard(Sprite sprite, EncounterTypeSO bindingType)
        {
            var card = CreateCard<EncounterCardDefinition>(sprite.name);
            card.EncounterType = bindingType;
            card.FrontSprite   = sprite;
            EditorUtility.SetDirty(card);
        }

        public override void UpdateCardList()
        {
            var current = BoardSettings.Find(o => o.GamePart == gameBoxDef);
            if (current.GamePart == null)
            {
                return;
            }

            var settings = current.Settings;
            if (settings == null)
            {
                return;
            }

            foreach (var binding in settings.SimpleEncounter)
            {
                _propertyName = binding.Type.name + "EncounterCard";
                SetCurrentRoot(binding.Type);
                base.UpdateCardList();
            }
        }

        void SetCurrentRoot(EncounterTypeSO type)
        {
            RootFolderPath = $"{gameBoxDef.FolderPath}/Encounter/{type.UniqueID}";
        }
    }

    public class EncounterCardGeneratorComposite : ScriptableObject { }
}