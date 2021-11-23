using System.IO;

namespace EldrtichHorror.UserProfile
{
    public interface IUserProfileSave
    {
        string Name { get; }

        UserProfileData UserProfileData { get; }
        void Save();
    }
    
    public class UserProfileSave :IUserProfileSave
    {
        private UserProfileData _userProfileData;
        private readonly IDataFromJsonBuilder<UserProfileData> _builder;
        private DirectoryInfo FolderInfo => _userProfileData.FolderPath;

        public UserProfileSave(UserProfileData userProfileData,IDataFromJsonBuilder<UserProfileData> builder)
        {
            _userProfileData = userProfileData;
            _builder = builder;
            if (!FolderInfo.Exists)
                FolderInfo.Create();
            else
            {
                _builder.BuildFrom(_userProfileData, FolderInfo.FullName);
            }
        }

        public string Name => FolderInfo.Name;
        public UserProfileData UserProfileData => _userProfileData;

        public void Save()
        {
            _builder.SaveTo(FolderInfo.FullName, _userProfileData);
        }
    }
}