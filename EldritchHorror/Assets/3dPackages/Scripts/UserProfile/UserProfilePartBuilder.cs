using System.Threading.Tasks;

namespace EldrtichHorror.UserProfile
{
    public abstract class UserProfilePartBuilder<TData> : IUserProfilePartBuilder<UserProfileData> where TData :new()
    {
        private readonly IJsonFileOperation _jsonFileOperation;
        private readonly IJsonConverter _jsonConverter;

        protected abstract string FileName { get; }

        public UserProfilePartBuilder(IJsonFileOperation jsonFileOperation, IJsonConverter jsonConverter)
        {
            _jsonFileOperation = jsonFileOperation;
            _jsonConverter = jsonConverter;
        }


        public void SaveTo(string folderInfoFullName, UserProfileData saveobject)
        {
            var item = GetItemToSave(saveobject);
            var json = _jsonConverter.SerializeObject(item);
            var path = $"{folderInfoFullName}/{FileName}.json";
            _jsonFileOperation.Save(path, json);
        }

        protected abstract TData GetItemToSave(UserProfileData saveobject);
        

        public async Task LoadFrom(string folderInfoFullName, UserProfileData result)
        {
            var path = $"{folderInfoFullName}/{FileName}.json";
            var json = await _jsonFileOperation.LoadText(path);
            var item = string.IsNullOrEmpty(json) ? new TData() : _jsonConverter.Deserialize<TData>(json);
            SetItemToResult(result, item);
        }

        protected abstract void SetItemToResult(UserProfileData result, TData item);

    }
    
    public class MythosCardSaveSettingsBuilder :UserProfilePartBuilder<MythosCardSaveSettings>
    {
        public MythosCardSaveSettingsBuilder(IJsonFileOperation jsonFileOperation, IJsonConverter jsonConverter) : base(jsonFileOperation, jsonConverter)
        {
        }

        protected override string FileName => "Mythos";
        protected override MythosCardSaveSettings GetItemToSave(UserProfileData saveobject)
        {
            return saveobject.MythosCards;
        }

        protected override void SetItemToResult(UserProfileData result, MythosCardSaveSettings item)
        {
            result.MythosCards = item;
        }
    }
}