#region

using EldritchHorror;
using EldritchHorror.Data.Provider;
using GameKit.Editor;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#endregion

namespace EldritchHorrorEditorEcosystem
{
    public class EcoSystemSettingsInstaller : BaseCustomEditorInstaller
    {
        [SerializeField] private EldritchHorrorDataStorage _dataStorage;

        [SerializeField] private List<ScriptableObjectInstaller> _installers = new List<ScriptableObjectInstaller>();
        [SerializeField] private EditorProjectPathSettings _settings;

        public override void Initialize(DiContainer diContainer)
        {
            base.Initialize(diContainer);
            _installers.ForEach(diContainer.Inject);
            EditorUtils.CreateAssetFolder(_settings.DataPath.DataFolderPath);
        }

        public override void InstallBindings()
        {
            _installers.ForEach(e => e.InstallBindings());

            BindEditorGUI();
        }

        private void BindEditorGUI()
        {
            ReflectionHelper.GetAllTypesInSolutionWithInterface<IEldritchHorrorEditorEcosystemGUI>()
                            .ForEach(e => { Container.BindInterfacesTo(e).AsSingle(); });
        }
    }
}