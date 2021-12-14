#region

using GameKit;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class GameBoxDef : BaseGameCartSO
    {
        [FoldoutGroup("Cards")] public List<AncientCardDataDefinition> AncientCards;
        [FolderPath] public string FolderPath;
        [FoldoutGroup("Sprites")] public Sprite Icon;
        [FoldoutGroup("Sprites")] public Sprite MainSprite;
        [FoldoutGroup("Cards")] public List<MythosCardDataDefinition> MythosCards;
        [FoldoutGroup("Cards/Encounter")] public List<EncounterCardDefinition> EuropeEncounterCard;
        [FoldoutGroup("Cards/Encounter")] public List<EncounterCardDefinition> AmericaEncounterCard;
        [FoldoutGroup("Cards/Encounter")] public List<EncounterCardDefinition> Asia_AustraliaEncounterCard;
        [FoldoutGroup("Cards/Encounter")] public List<EncounterCardDefinition> GeneralEncounterCard;
        [FoldoutGroup("Cards/Encounter")] public List<EncounterCardDefinition> OtherWorldEncounterCard;
        
        
        public GameVersion Version;
    }
}