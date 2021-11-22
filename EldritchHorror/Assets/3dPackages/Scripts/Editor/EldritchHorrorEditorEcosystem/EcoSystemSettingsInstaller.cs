using EldritchHorror;
using EldritchHorror.Data.Provider;
using GameKit.Editor;
using GameKit.EditorContext;
using Sirenix.Utilities;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class  EcoSystemSettingsInstaller: BaseCustomEditorInstaller
    {
        [SerializeField]
        private EditorProjectPathSettings _settings;
        
        [SerializeField]
        private EldritchHorrorScriptableProviderStorage _dataStorage;

        public override void Initialize()
        {
            base.Initialize();
            EditorUtils.CreateAssetFolder(_settings.DataPath.DataFolderPath);
        }

        public override void InstallBindings()
        {
            Container.Bind<EditorProjectPathSettings>().FromInstance(_settings).AsSingle();
            _dataStorage.Collection.ForEach(e => Container.BindInterfacesTo(e.GetType()).FromInstance(e).AsSingle());

            Container.BindInterfacesTo<EldritchHorrorEditorPathProvider>().AsSingle();
            Container.BindInstance(_dataStorage).AsSingle();
            Container.BindInterfacesTo<LocalDataBoxStorage>().AsSingle();
        }
    }
}