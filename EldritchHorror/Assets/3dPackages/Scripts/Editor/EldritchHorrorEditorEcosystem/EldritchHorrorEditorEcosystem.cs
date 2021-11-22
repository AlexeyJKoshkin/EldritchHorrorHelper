using EldritchHorror.Data.Provider;
using EldritchHorrorEditorEcosystem.Helpers;
using GameKit.Editor;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystem : IEldritchHorrorEditorEcosystem
    {
        private readonly IDataStorage _dataStorage;
        private readonly IEldritchHorrorEditorPathProvider _editorPathProvider;
        public event Action OnFinishWorkingEvent;

        public EldritchHorrorEditorEcosystem(IDataStorage dataStorage, EldritchHorrorScriptableProviderStorage editorStorage, IEldritchHorrorEditorPathProvider editorPathProvider)
        {
            _dataStorage = dataStorage;
            _editorPathProvider = editorPathProvider;
            FixEditorStorage(editorStorage);
        }

        private void FixEditorStorage(EldritchHorrorScriptableProviderStorage editorStorage)
        {
             if (editorStorage.CreateNewIfMissed)
                  CreateMissed(editorStorage);
                  
        }
        private void CreateMissed(EldritchHorrorScriptableProviderStorage editorStorage)
        {
            var possibleTypes = ReflectionHelper.GetAllTypesInSolution<DataBox>(false);
            foreach (var type in possibleTypes)
            {
                if(editorStorage.Collection.Any(o=> o.GetType() == type)) continue;
                string path = editorStorage.Path + $"/{type.Name}.asset";
                EditorUtils.LoadAsset(type, path, true, true);
            }
            editorStorage.Reload();
            EditorUtility.SetDirty(editorStorage);
        }

        public void StartWork()
        {
            Debug.LogError("Hello World");
        }

        public void StopWork()
        {
            Debug.LogError("StopWork World");
            OnFinishWorkingEvent?.Invoke();
        }

        public void CreateInfrastructure()
        {
            _editorPathProvider?.CreateInfrastructure();
        }
    }
}