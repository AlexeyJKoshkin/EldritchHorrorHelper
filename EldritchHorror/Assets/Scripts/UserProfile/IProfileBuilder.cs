using System.Threading.Tasks;

namespace EldritchHorror.UserProfile
{
    public interface IUserProfilePartBuilder<TDataWrapper>
    {
        void SaveTo(string folderInfoFullName, TDataWrapper saveobject);
        Task LoadFrom(string folderInfoFullName, TDataWrapper result);
    }
}