using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using EldritchHorror.Data.Provider;
using EldritchHorrorEditorEcosystem.Helpers;
using EldrtichHorror;
using EldrtichHorror.UserProfile;
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
        public event Action OnFinishWorkingEvent;

        public EldritchHorrorEditorEcosystem(IDataStorage dataStorage,
                                             EldritchHorrorScriptableProviderStorage editorStorage)
        {
            _dataStorage = dataStorage;
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
            Debug.LogError("Start Editor Eco System");
        }
        public void StopWork()
        {
            Debug.LogError("StopWork World");
            OnFinishWorkingEvent?.Invoke();
        }
    }
}