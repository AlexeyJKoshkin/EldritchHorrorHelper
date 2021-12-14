#region

using EldritchHorror.Cards;
using System.Linq;
using UnityEngine;

#endregion

namespace EldritchHorrorEditorEcosystem.Helpers
{
    [CreateAssetMenu]
    public class AncientCardGenerator : CardGenerator<AncientCardGeneratorSettingsSettings, AncientTypeSO>
    {
        public MythosCardTypesHolder MythosCardTypesHolder;
        public override string PropertyName => "AncientCards";

        public override void GenerateCurrent(GameBoardGeneratorSettings current)
        {
            GenerateFolder("Ancient");
            if (MythosCardTypesHolder == null)
            {
                return;
            }

            CreateOne("Ktulhu");
        }

        private void CreateOne(string bossName)
        {
            string path = $"{RootFolderPath}/{bossName}.asset";
            var    item = LoadAssetOrCreate<AncientCardDataDefinition>(path);
            SetDefaultSettings(item);
        }

        private void SetDefaultSettings(AncientCardDataDefinition item)
        {
            item.AncientActMythosSettings = new AncientActMythosCardSettings
                                            {
                                                First  = CreateDefault(),
                                                Second = CreateDefault(),
                                                Third  = CreateDefault()
                                            };
        }

        private MythosTypeCount[] CreateDefault()
        {
            return MythosCardTypesHolder.Collection.Select(o => new MythosTypeCount {TypeSo = o, Count = 3})
                                        .ToArray();
        }
    }
}