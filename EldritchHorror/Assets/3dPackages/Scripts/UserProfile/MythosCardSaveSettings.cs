using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using System;
using System.Collections.Generic;

namespace EldrtichHorror.UserProfile
{
    [Serializable]
    public class MythosCardSaveSettings
    {
        // карты каких типов исполись
        public MythosDifficultType DifficultType;
        public GameVersion GameVersion;
        public List<string> ExcludedCards = new List<string>();
    }
    
    
}