namespace EldrtichHorror.UserProfile
{
    public interface IUserProfileSaveFactory
    {
        UserProfileSave Create(UserProfileData userProfileData);
    }
    
    public class UserProfileSaveFactory : IUserProfileSaveFactory
    {
        private readonly IDataFromJsonBuilder<UserProfileData> _builder;

        UserProfileSaveFactory(IDataFromJsonBuilder<UserProfileData> builder)
        {
            _builder = builder;
        }

        public UserProfileSave Create(UserProfileData userProfileData)
        {
            return new UserProfileSave(userProfileData,_builder );
        }
    }
}