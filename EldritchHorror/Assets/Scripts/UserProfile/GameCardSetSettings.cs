using EldritchHorror.Cards;
using System;

namespace EldritchHorror.UserProfile
{
    [Serializable]
    public class GameCardSetSettings
    {
        public string AncientName = "";
        public GameVersion GameVersion = GameVersion.BaseBox;
    }
}