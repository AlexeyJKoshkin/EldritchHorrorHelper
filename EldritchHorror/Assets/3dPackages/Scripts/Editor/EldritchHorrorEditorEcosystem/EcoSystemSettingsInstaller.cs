using EldritchHorror;
using EldritchHorror.Data.Provider;
using GameKit.Editor;
using GameKit.EditorContext;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EldritchHorrorEditorEcosystem
{
    public class  EcoSystemSettingsInstaller: BaseCustomEditorInstaller
    {
        [SerializeField]
        private EditorProjectPathSettings _settings;
        
        [SerializeField]
        private EldritchHorrorScriptableProviderStorage _dataStorage;
        
        [SerializeField]
        List<ScriptableObjectInstaller> _installers = new List<ScriptableObjectInstaller>();

        public override void Initialize(DiContainer diContainer)
        {
            base.Initialize(diContainer);
            _installers.ForEach(diContainer.Inject);
            EditorUtils.CreateAssetFolder(_settings.DataPath.DataFolderPath);
        }

        public override void InstallBindings()
        {
            _installers.ForEach(e=> e.InstallBindings());
            
            Container.Bind<EditorProjectPathSettings>().FromInstance(_settings).AsSingle();
            _dataStorage.Collection.ForEach(e => Container.BindInterfacesTo(e.GetType()).FromInstance(e).AsSingle());
            Container.BindInterfacesTo<EldritchHorrorEditorPathProvider>().AsSingle();
            Container.BindInstance(_dataStorage).AsSingle();
            Container.BindInterfacesTo<LocalDataBoxStorage>().AsSingle();
        }
    }
}