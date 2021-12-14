#region

using EldritchHorror;
using EldritchHorror.Cards;
using EldritchHorror.Data.Provider;
using GameKit.Editor;

#endregion

namespace EldritchHorrorEditorEcosystem
{
    public interface IEldritchHorrorEditorPathProvider
    {
        void CreateInfrastructure();
    }

    public class EldritchHorrorEditorPathProvider : IEldritchHorrorEditorPathProvider
    {
        private readonly EditorProjectPathSettings _projectPathSettings;
        private readonly IDataStorage _storage;

        public EldritchHorrorEditorPathProvider(IDataStorage storage, EditorProjectPathSettings projectPathSettings)
        {
            _storage             = storage;
            _projectPathSettings = projectPathSettings;
        }

        public void CreateInfrastructure()
        {
            CreateFolders();
        }

        private void CreateFolders()
        {
            foreach (var part in _storage.All<GameBoxDef>())
            {
                var folderPath = _projectPathSettings.DataPath.GetPartGameFolderPath(part);
                part.FolderPath = folderPath;
                EditorUtils.CreateAssetFolder(folderPath);
                foreach (var cardType in _storage.All<CardTypeSO>())
                {
                    folderPath = $"{folderPath}/{cardType.UniqueID}";
                    EditorUtils.CreateAssetFolder(folderPath);
                }
            }
        }
    }
}