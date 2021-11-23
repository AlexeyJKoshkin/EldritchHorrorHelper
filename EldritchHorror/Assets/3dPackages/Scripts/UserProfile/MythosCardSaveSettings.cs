using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using System;
using System.Collections.Generic;

namespace EldrtichHorror.UserProfile
{
    [Serializable]
    public class MythosCardSaveSettings
    {
        // карты каких типов исполись
        public MythosDifficultType DifficultType = MythosDifficultType.Easy | MythosDifficultType.Hard | MythosDifficultType.Simple;
        public GameVersion GameVersion = GameVersion.BaseBox;
        public List<string> ExcludedCards = new List<string>();

        public override string ToString()
        {
            return $"{DifficultType} {GameVersion} {ExcludedCards.Count}";
        }
    }
}