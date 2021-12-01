using GameKit;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class GameBoxDef : BaseGameCartSO
    {
        [FoldoutGroup("Cards")] public List<AncientCardDataDefinition> AncientCards;
        [FolderPath] public string FolderPath;
        public Sprite Icon;
        public Sprite MainSprite;
        [FoldoutGroup("Cards")] public List<MythosCardDataDefinition> MythosCards;
        public GameVersion Version;
    }
}