using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EldrtichHorror.UserProfile
{
    public interface IUserSaveProfileStorage
    {
        IUserProfileSave  Current { get; }
        IReadOnlyCollection<IUserProfileSave> AllSaves { get; }
        IUserProfileSave CreateNew();
        IUserProfileSave GetSave(string folderName = null);
    }
    
    public class UserSaveProfileStorage : IUserSaveProfileStorage
    {
        public IUserProfileSave Current => _current;
        public IReadOnlyCollection<IUserProfileSave> AllSaves => _saves;
       

        private readonly UserSavePathSettings _savePathSettings;
        private readonly IUserProfileSaveFactory _saveFactory;
        private readonly UserProfileSave _current;
        
        private readonly List<IUserProfileSave> _saves = new List<IUserProfileSave>();

        public UserSaveProfileStorage(UserSavePathSettings savePathSettings,IUserProfileSaveFactory saveFactory)
        {
            _savePathSettings = savePathSettings;
            _saveFactory = saveFactory;
            var root= LoadDirectory();
            _current = FactoryCreateSave("Current");
            foreach (var saveFolder in root.EnumerateDirectories())
            {
                GetSave(saveFolder.Name);
            }
        }
        
        public IUserProfileSave CreateNew()
        {
            return GetSave($"Game_{_saves.Count}");
        }

        public IUserProfileSave GetSave(string saveFolderName)
        {
            if (string.IsNullOrEmpty(saveFolderName)) return null;

            if (_current.Name == saveFolderName) return _current;
            var result = _saves.FirstOrDefault(o => o.Name == saveFolderName);
            if (result == null)
            {
                result = FactoryCreateSave(saveFolderName);
                _saves.Add(result);
            }
            return result;
        }
        private UserProfileSave FactoryCreateSave(string nameSave)
        {
            return _saveFactory.Create(new UserProfileData() {FolderPath = new DirectoryInfo($"{_savePathSettings.RootPath}/{nameSave}")});
        }

        private DirectoryInfo LoadDirectory()
        {
            return !Directory.Exists(_savePathSettings.RootPath) ? Directory.CreateDirectory(_savePathSettings.RootPath) : new DirectoryInfo(_savePathSettings.RootPath);
        }
    }
}