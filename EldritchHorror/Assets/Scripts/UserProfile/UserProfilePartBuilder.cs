#region

using System.Threading.Tasks;

#endregion

namespace EldritchHorror.UserProfile
{
    public abstract class UserProfilePartBuilder<TData> : IUserProfilePartBuilder<UserProfileData> where TData : new()
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly IJsonFileOperation _jsonFileOperation;

        public UserProfilePartBuilder(IJsonFileOperation jsonFileOperation, IJsonConverter jsonConverter)
        {
            _jsonFileOperation = jsonFileOperation;
            _jsonConverter     = jsonConverter;
        }

        protected abstract string FileName { get; }


        public void SaveTo(string folderInfoFullName, UserProfileData saveobject)
        {
            var item = GetItemToSave(saveobject);
            var json = _jsonConverter.SerializeObject(item);
            var path = $"{folderInfoFullName}/{FileName}.json";
            _jsonFileOperation.Save(path, json);
        }


        public async Task LoadFrom(string folderInfoFullName, UserProfileData result)
        {
            var path = $"{folderInfoFullName}/{FileName}.json";
            var json = await _jsonFileOperation.LoadText(path);
            var item = string.IsNullOrEmpty(json) ? new TData() : _jsonConverter.Deserialize<TData>(json);
            SetItemToResult(result, item);
        }

        protected abstract TData GetItemToSave(UserProfileData saveobject);

        protected abstract void SetItemToResult(UserProfileData result, TData item);
    }

    public class MythosCardSaveSettingsBuilder : UserProfilePartBuilder<MythosCardSaveSettings>
    {
        public MythosCardSaveSettingsBuilder(IJsonFileOperation jsonFileOperation, IJsonConverter jsonConverter) : base(jsonFileOperation, jsonConverter) { }

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

    public class GameCardSetSettingsBuilder : UserProfilePartBuilder<GameCardSetSettings>
    {
        public GameCardSetSettingsBuilder(IJsonFileOperation jsonFileOperation, IJsonConverter jsonConverter) : base(jsonFileOperation, jsonConverter) { }

        protected override string FileName => "GameSetCards";

        protected override GameCardSetSettings GetItemToSave(UserProfileData saveobject)
        {
            return saveobject.GameSetCards;
        }

        protected override void SetItemToResult(UserProfileData result, GameCardSetSettings item)
        {
            result.GameSetCards = item;
        }
    }
}