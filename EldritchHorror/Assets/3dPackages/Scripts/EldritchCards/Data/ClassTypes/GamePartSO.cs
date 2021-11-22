using Editor.EldrtichHorrorEditorEcosystem.EldritchCards.Data;
using GameKit.Editor;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    [AllowMultiItems]
    public class GamePartSO : BaseGameCartSO
    {
        public Sprite MainSprite;
        public Sprite Icon;
        public GameVersion Version;
        [FolderPath]
        public string FolderPath;
        [FoldoutGroup("Cards")]
        [SerializeReference]
        public List<ICardGenerateSettings> CardGenerateSettingses = new List<ICardGenerateSettings>();
    }

  
}