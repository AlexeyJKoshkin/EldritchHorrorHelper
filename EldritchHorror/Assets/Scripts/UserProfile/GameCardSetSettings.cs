#region

using EldritchHorror.Cards;
using System;

#endregion

namespace EldritchHorror.UserProfile
{
    [Serializable]
    public class GameCardSetSettings
    {
        public string AncientName = "";
        public GameVersion GameVersion = GameVersion.BaseBox;
    }
}