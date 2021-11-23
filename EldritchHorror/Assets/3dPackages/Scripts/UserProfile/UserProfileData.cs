
using System.IO;

namespace EldrtichHorror.UserProfile
{
    public interface IUserProfileData
    {
        MythosCardSaveSettings MythosCards { get; }
    }
    public class UserProfileData :IUserProfileData
    {
        public DirectoryInfo FolderPath;
        public MythosCardSaveSettings MythosCards { get; set; } = new MythosCardSaveSettings();
    }
}