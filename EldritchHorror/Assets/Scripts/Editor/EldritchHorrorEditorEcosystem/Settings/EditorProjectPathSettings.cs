using EldritchHorror.Cards;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace EldritchHorror
{
    public class EditorProjectPathSettings : SingletonSettings<EditorProjectPathSettings>
    {
        [SerializeField] private DataPathSettings _dataSettings;
        public DataPathSettings DataPath => _dataSettings;

        [Serializable]
        public class DataPathSettings
        {
            [FolderPath] public string DataFolderPath;

            public string MapPawnSettingsPath => BuildPath("MapPawnData");

            private string BuildPath(string folder)
            {
                return DataFolderPath + "/" + folder;
            }

            public string GetPartGameFolderPath(GameBoxDef part)
            {
                if (part == null)
                {
                    return DataFolderPath;
                }

                return BuildPath(part.UniqueID);
            }
        }
    }
}