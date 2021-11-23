using System.Threading.Tasks;

namespace EldrtichHorror.UserProfile
{
    public interface IDataFromJsonBuilder<TData> where TData : new()
    {
        void SaveTo(string folderInfoFullName, TData saveobject);
        Task BuildFrom(TData result, string folderInfoFullName);
    }
}