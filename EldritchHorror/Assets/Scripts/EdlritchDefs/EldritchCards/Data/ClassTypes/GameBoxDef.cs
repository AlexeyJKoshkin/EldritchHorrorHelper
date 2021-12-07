using GameKit;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class GameBoxDef : BaseGameCartSO
    {
        [FolderPath] public string FolderPath;
        public GameVersion Version;
        [FoldoutGroup("Sprites")] 
        public Sprite Icon;
        [FoldoutGroup("Sprites")] 
        public Sprite MainSprite;
        
        [FoldoutGroup("Cards")] public List<AncientCardDataDefinition> AncientCards;
        [FoldoutGroup("Cards")] public List<MythosCardDataDefinition> MythosCards;
    }
}