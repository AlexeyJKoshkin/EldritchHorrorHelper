#region

using System.IO;

#endregion

namespace EldritchHorror.UserProfile
{
    public interface IUserProfileData
    {
        MythosCardSaveSettings MythosCards { get; }
        GameCardSetSettings GameSetCards { get; }
    }

    public class UserProfileData : IUserProfileData
    {
        public string AncientName;
        public DirectoryInfo FolderPath;

        public MythosCardSaveSettings MythosCards { get; set; } = new MythosCardSaveSettings();
        public GameCardSetSettings GameSetCards { get; set; } = new GameCardSetSettings();
    }
}