using System.Threading.Tasks;

namespace EldrtichHorror.UserProfile
{
    public class UserProfileDataCompositeBuilder :IDataFromJsonBuilder<UserProfileData>
    {
        private IUserProfilePartBuilder<UserProfileData>[] _builders;

        public UserProfileDataCompositeBuilder(IUserProfilePartBuilder<UserProfileData>[] builders)
        {
            _builders = builders;
        }


        public void SaveTo(string folderInfoFullName, UserProfileData saveobject)
        {
            foreach (var builder in _builders)
            {
                builder.SaveTo(folderInfoFullName, saveobject);
            }
        }

        public async Task BuildFrom(UserProfileData result, string folderInfoFullName)
        {
            foreach (var builder in _builders)
            {
              await  builder.LoadFrom(folderInfoFullName,result);
            }
        }
    }
}