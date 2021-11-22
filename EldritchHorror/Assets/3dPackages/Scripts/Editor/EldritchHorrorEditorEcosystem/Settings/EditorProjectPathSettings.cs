using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace EldritchHorror
{
    public class EditorProjectPathSettings : SingletonSettings<EditorProjectPathSettings>
    {
        public DataPathSettings DataPath => _dataSettings;
        [SerializeField]
        private DataPathSettings _dataSettings;
        
        [Serializable]
        public class DataPathSettings
        {
            [FolderPath]
            public string DataFolderPath;

            public string MapPawnSettingsPath => BuildPath("MapPawnData");

            private string BuildPath(string folder)
            {
                return DataFolderPath + "/" + folder;
            }

            public string GetPartGameFolderPath(GamePartSO part)
            {
                if (part == null) return DataFolderPath;
                return BuildPath(part.UniqueID);
            }
        }
    }
}
